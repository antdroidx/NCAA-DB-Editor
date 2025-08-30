using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
// using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

    



            // ---- Public one-call API -------------------------------------------------

            /// <summary>
            /// Builds a PSU from a raw PS2 save folder. Ensures icon.sys exists first.
            /// </summary>
            /// <param name="inputFolder">Raw save folder (contains files like icon.sys, icon.icn, etc.).</param>
            /// <param name="outputPsuPath">Destination .psu path.</param>
            /// <param name="directoryNameInPsu">Top-level directory name inside PSU (default = folder name).</param>
            /// <param name="title">icon.sys title (default = directoryNameInPsu, capped at 32 ASCII chars).</param>
            /// <param name="bgColors">8 RGB triplets for bgcol0..7 (null => all 0,0,0).</param>
            /// <param name="alpha">RGB triplet for bgcola (null => 0,0,0).</param>
            /// <param name="iconName">Icon filename referenced by copy0/del0 (default "icon.icn"). Not required to exist.</param>
            /// <param name="overwriteIconSys">If true, (re)write icon.sys even if present. Default: true.</param>
            public static void BuildPsuFromFolder(
                string inputFolder,
                string outputPsuPath,
                string? directoryNameInPsu = null,
                string? title = null,
                (byte R, byte G, byte B)[]? bgColors = null,
                (byte R, byte G, byte B)? alpha = null,
                string iconName = "icon.icn",
                bool overwriteIconSys = false)
            {
                if (!Directory.Exists(inputFolder))
                    throw new DirectoryNotFoundException(inputFolder);

                string rootName = string.IsNullOrWhiteSpace(directoryNameInPsu)
                    ? new DirectoryInfo(inputFolder).Name
                    : directoryNameInPsu!;
                string titleText = string.IsNullOrWhiteSpace(title) ? rootName : title!;

                // 1) Ensure icon.sys
                string iconSysPath = Path.Combine(inputFolder, "icon.sys");
                if (overwriteIconSys || !File.Exists(iconSysPath))
                {
                    MessageBox.Show("Missing icon.sys", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
                // 2) Build PSU
                PsuWriter.CreateFromFolder(inputFolder, outputPsuPath + "\\" + directoryNameInPsu, rootName);
            }


            // ---- PSU writer ----------------------------------------------------------

            private static class PsuWriter
            {
                private const ushort IdDirOrDot = 0x2784;
                private const ushort IdFile = 0x9784;

                public static void CreateFromFolder(string inputFolder, string outputPsuPath, string directoryNameInPsu)
                {
                    var files = Directory.GetFiles(inputFolder, "*", SearchOption.TopDirectoryOnly)
                                         .OrderBy(p => p, StringComparer.OrdinalIgnoreCase)
                                         .ToArray();

                    int dirFileCount = 2 + files.Length; // "." + ".." + N files

                    using var fs = new FileStream(outputPsuPath, FileMode.Create, FileAccess.Write, FileShare.None);
                    using var bw = new BinaryWriter(fs);

                    // Root dir
                    WriteEntry(bw, IdDirOrDot, true, dirFileCount, directoryNameInPsu,
                        null, new DirectoryInfo(inputFolder).CreationTimeUtc, new DirectoryInfo(inputFolder).LastWriteTimeUtc);

                    // "."
                    WriteEntry(bw, IdDirOrDot, true, 0, ".",
                        null, new DirectoryInfo(inputFolder).CreationTimeUtc, new DirectoryInfo(inputFolder).LastWriteTimeUtc);

                    // ".."
                    WriteEntry(bw, IdDirOrDot, true, 0, "..",
                        null, new DirectoryInfo(inputFolder).CreationTimeUtc, new DirectoryInfo(inputFolder).LastWriteTimeUtc);

                    // Files
                    foreach (var path in files)
                    {
                        var fi = new FileInfo(path);
                        WriteEntry(bw, IdFile, false, checked((int)fi.Length), fi.Name,
                            w => { using var fr = File.OpenRead(path); fr.CopyTo(w.BaseStream); },
                            fi.CreationTimeUtc, fi.LastWriteTimeUtc);
                    }
                }

                private static void WriteEntry(
                    BinaryWriter bw,
                    ushort id,
                    bool isDirOrDot,
                    int fileSizeOrCount_BE,
                    string name,
                    Action<BinaryWriter>? contentWriter,
                    DateTime creationUtc,
                    DateTime modifiedUtc)
                {
                    byte[] header = new byte[32];

                    // ID (LE)
                    header[0] = (byte)(id & 0xFF);
                    header[1] = (byte)((id >> 8) & 0xFF);

                    // 2..4 = 0
                    // 5..8 = file size or count (BE)
                    uint be = (uint)Math.Max(0, fileSizeOrCount_BE);
                    header[5] = (byte)((be >> 24) & 0xFF);
                    header[6] = (byte)((be >> 16) & 0xFF);
                    header[7] = (byte)((be >> 8) & 0xFF);
                    header[8] = (byte)(be & 0xFF);

                    // creation timestamp (9..15), then 16..17 (start sector) = 0
                    WriteTimestamp(header, 9, creationUtc);
                    header[16] = 0;
                    header[17] = 0;

                    // 18..24 = 0
                    // modified timestamp (25..31)
                    for (int i = 18; i <= 24; i++) header[i] = 0;
                    WriteTimestamp(header, 25, modifiedUtc);

                    bw.Write(header);
                    bw.Write(new byte[32]); // zero block

                    // name (448 bytes ASCII, 0-padded)
                    byte[] nameBytes = Encoding.ASCII.GetBytes(name);
                    if (nameBytes.Length > 448)
                        throw new InvalidOperationException($"PSU name too long: {name}");
                    bw.Write(nameBytes);
                    if (nameBytes.Length < 448)
                        bw.Write(new byte[448 - nameBytes.Length]);

                    long contentStart = bw.BaseStream.Position;
                    if (!isDirOrDot && contentWriter != null)
                        contentWriter(bw);

                    long contentLen = bw.BaseStream.Position - contentStart;
                    if (!isDirOrDot)
                    {
                        int pad = PaddingTo(contentLen, 1024);
                        if (pad > 0) bw.Write(new byte[pad]);
                    }
                }

                private static void WriteTimestamp(byte[] buffer, int offset, DateTime utc)
                {
                    ushort year = (ushort)utc.Year;
                    buffer[offset + 0] = (byte)utc.Second;
                    buffer[offset + 1] = (byte)utc.Minute;
                    buffer[offset + 2] = (byte)utc.Hour;
                    buffer[offset + 3] = (byte)utc.Day;
                    buffer[offset + 4] = (byte)utc.Month;
                    buffer[offset + 5] = (byte)(year & 0xFF);        // LSB
                    buffer[offset + 6] = (byte)((year >> 8) & 0xFF); // MSB
                }

                private static int PaddingTo(long n, int blockSize)
                {
                    long mod = n % blockSize;
                    return (int)(mod == 0 ? 0 : (blockSize - mod));
                }
            }




        }
    

}
