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

        // ----- PUBLIC ENTRY POINTS ------------------------------------------------

        /// <summary>
        /// Get recommended (PFSH, PMSH, PSSH) for a player given position + raw height/weight.
        /// </summary>
        public static (sbyte PFSH, sbyte PMSH, sbyte PSSH)
            GetBodySizeFromPlayerData(int ppos /* PPOS */, int heightInches, int weightLbs)
        {
            double bmi = ComputeBmi(heightInches, weightLbs);
            var pfsh = RecommendPfsh(ppos, bmi);
            var pmsh = RecommendPmsh(bmi);
            var pssh = RecommendPssh(bmi);
            return (pfsh, pmsh, pssh);
        }


        // ----- BMI / MAPPING LOGIC ------------------------------------------------

        /// <summary>BMI = (lbs / in^2) * 703</summary>
        public static double ComputeBmi(int heightInches, int weightLbs)
        {
            if (heightInches <= 0) return 0;
            weightLbs += 160;
            return (weightLbs / (heightInches * heightInches / 1.0)) * 703.0;
        }

        /// <summary>
        /// PFSH by position + BMI (archetype channel). Derived from original roster.
        /// </summary>
        public static sbyte RecommendPfsh(int ppos, double bmi)
        {
            // QB
            if (ppos == 0)
            {
                if (bmi < 26) return -1;
                if (bmi < 28) return 0;
                return 1;
            }
            // HB / FB
            if (ppos == 1 || ppos == 2)
            {
                if (bmi < 26) return -1;
                if (bmi < 30) return 0;
                return 1;
            }
            // WR
            if (ppos == 3)
            {
                return (bmi < 25) ? (sbyte)-1 : (sbyte)0;
            }
            // TE
            if (ppos == 4)
            {
                return (bmi < 30) ? (sbyte)0 : (sbyte)1;
            }
            // OL (LT..RT = 5..9)
            if (ppos >= 5 && ppos <= 9)
            {
                return (bmi < 38) ? (sbyte)3 : (sbyte)4;
            }
            // DL (LE..DT = 10..12)
            if (ppos >= 10 && ppos <= 12)
            {
                if (bmi < 32) return 0;   // lean DE
                if (bmi < 38) return 1;   // DT
                return 2;                 // NT / very large
            }
            // LB (13..15)
            if (ppos >= 13 && ppos <= 15)
            {
                return (bmi < 31) ? (sbyte)0 : (sbyte)1;
            }
            // DB (CB/FS/SS = 16..18)
            if (ppos >= 16 && ppos <= 18)
            {
                return (bmi < 26) ? (sbyte)-1 : (sbyte)0;
            }
            // K / P
            if (ppos == 19 || ppos == 20)
            {
                return (bmi < 27) ? (sbyte)0 : (sbyte)1;
            }

            return 0; // safe default
        }

        /// <summary>
        /// PMSH (muscle/bulk) by BMI. Derived from original roster distributions.
        /// </summary>
        public static sbyte RecommendPmsh(double bmi)
        {
            if (bmi < 24) return -1;
            if (bmi < 26) return 0;
            if (bmi < 28) return 1;
            if (bmi < 30) return 2;
            if (bmi < 32) return 3;
            if (bmi < 34) return 3;
            if (bmi < 36) return 4;
            if (bmi < 38) return 4;
            return 5;
        }

        /// <summary>
        /// PSSH (size/“fatness”) by BMI — inverse of leanness. Derived from roster.
        /// </summary>
        public static sbyte RecommendPssh(double bmi)
        {
            if (bmi < 24) return 5;
            if (bmi < 26) return 4;
            if (bmi < 28) return 3;
            if (bmi < 30) return 2;
            if (bmi < 32) return 1;
            if (bmi < 34) return 1;
            if (bmi < 36) return 0;
            if (bmi < 38) return 0;
            return -1;
        }


    }

}
