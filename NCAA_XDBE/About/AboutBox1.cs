using System.Reflection;

namespace DB_EDITOR
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;

            // Add a publish date label at runtime (uses assembly linker/build timestamp)
            try
            {
                var publishLabel = new Label();
                publishLabel.Name = "labelPublishDate";
                publishLabel.AutoSize = true;
                publishLabel.Text = "Built: " + AssemblyPublishDate;
                publishLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                // Add the label into the tableLayoutPanel in the last row, second column so it displays correctly
                // tableLayoutPanel has 2 columns; add to column index 1, row index 6 (last row)
                if (this.tableLayoutPanel != null)
                {
                    // Ensure the last row exists; the designer already defines 7 rows, so just add control into cell
                    this.tableLayoutPanel.Controls.Add(publishLabel, 1, Math.Max(0, this.tableLayoutPanel.RowCount - 1));
                }
                else
                {
                    // fallback to adding to the form if tableLayoutPanel is not available
                    publishLabel.Location = new System.Drawing.Point(8, this.textBoxDescription.Bottom + 6);
                    this.Controls.Add(publishLabel);
                }
            }
            catch
            {
                // ignore any errors adding the runtime label
            }
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyPublishDate
        {
            get
            {
                try
                {
                    var dt = GetAssemblyLinkerTime(Assembly.GetExecutingAssembly());
                    // If the linker timestamp looks invalid (too old or in the future), fall back to file last write time
                    if (dt.Year < 1980 || dt > DateTime.Now.AddDays(1))
                    {
                        var path = Assembly.GetExecutingAssembly().Location;
                        if (File.Exists(path))
                        {
                            return File.GetLastWriteTime(path).ToString("yyyy-MM-dd HH:mm");
                        }
                    }
                    return dt.ToString("yyyy-MM-dd HH:mm");
                }
                catch
                {
                    try
                    {
                        var path = Assembly.GetExecutingAssembly().Location;
                        if (File.Exists(path))
                        {
                            return File.GetLastWriteTime(path).ToString("yyyy-MM-dd HH:mm");
                        }
                    }
                    catch { }
                    return string.Empty;
                }
            }
        }

        private static DateTime GetAssemblyLinkerTime(Assembly assembly)
        {
            var filePath = assembly.Location;
            const int peHeaderOffset = 0x3C;
            const int linkerTimestampOffset = 8;

            byte[] b = new byte[4];
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                stream.Seek(peHeaderOffset, SeekOrigin.Begin);
                stream.Read(b, 0, 4);
                int headerPos = BitConverter.ToInt32(b, 0);
                stream.Seek(headerPos + linkerTimestampOffset, SeekOrigin.Begin);
                stream.Read(b, 0, 4);
            }

            int secondsSince1970 = BitConverter.ToInt32(b, 0);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(secondsSince1970).ToLocalTime();
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
