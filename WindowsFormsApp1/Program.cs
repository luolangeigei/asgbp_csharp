using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    string file = args[0];
                    string filename = System.IO.Path.GetFileNameWithoutExtension(file);//文件名  “Default.aspx”
                    if (!Directory.Exists(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + filename))
                    {
                        Directory.CreateDirectory(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + filename);
                    }
                    ZipFile.ExtractToDirectory(file, @AppDomain.CurrentDomain.BaseDirectory + "pic\\" + filename);
                    MessageBox.Show("导入成功！");
                }
            }
            catch
            {


            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            // Check if the program was launched with a ".luolan" file as an argument
           
        }
    }
}
