using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
   
    public partial class Form2 : Form
    {


        public static Form2 form2;


        [DllImport("user32.dll")]
        public static extern int ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        public Form2()
        {
            InitializeComponent();
            form2 = this;
        }
        // <summary>
        /// 使用API
        /// </summary>
        static uint SND_ASYNC = 0x0001; // play asynchronously
        static uint SND_FILENAME = 0x00020000; // name is file name
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(
             String command,
             StringBuilder buffer,
             Int32 bufferSize,
             IntPtr hwndCallback,
             uint hWndCallback);

        [DllImport("Kernel32", CharSet = CharSet.Auto)]
        static extern Int32 GetShortPathName(String path, StringBuilder shortPath, Int32 shortPathLength);

        void Play(string path)
        {
            mciSendString("open " + path + " alias media", null, 0, Handle, 0);
            mciSendString("play media repeat", null, 0, Handle, 0);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
          //  pieChart1.Series.Add(new PieSeries { Title="ceshi",Values= new ChartValues<double> { Convert.ToInt32(77) } });
         //   pieChart1.Series.Add(new PieSeries { Title = "ces33hi", Values = new ChartValues<double> { Convert.ToInt32(22) } });

            Play(@AppDomain.CurrentDomain.BaseDirectory + "music\\bp.mp3");
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
            AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);

            qsz_xz_1.Parent = pictureBox1;
            qsz_xz_2.Parent = pictureBox1;
            qsz_xz_3.Parent = pictureBox1;
            qsz_xz_4.Parent = pictureBox1;
            jgz_ban_1.Parent = pictureBox1;
            jgz_ban_2.Parent = pictureBox1;
            jgz_ban_3.Parent = pictureBox1;
            jgz_ban_4.Parent = pictureBox1;
            qsz_ban_1.Parent = pictureBox1;
            qsz_ban_2.Parent = pictureBox1;
            qsz_ban_3.Parent = pictureBox1;
            qsz_ban_4.Parent = pictureBox1;
            qsz_ban_5.Parent = pictureBox1;
            qsz_ban_6.Parent = pictureBox1;
            jgz_xz_1.Parent = pictureBox1;
            name_1.Parent = pictureBox1;
            name_2.Parent = pictureBox1;
            map_p.Parent = pictureBox1;
    
            if(qsz.img_path!=null)
                pictureBox1.BackgroundImage = Image.FromFile(qsz.img_path);
            if (qsz.font_size!=null|qsz.font_size!=null)
            name_2.Font=name_1.Font = new Font(qsz.font_name, Convert.ToInt32(qsz.font_size));
        }






        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        /// <summary>
        /// 窗体动画函数
        /// </summary>
        /// <param name="hwnd">指定产生动画的窗口的句柄</param>
        /// <param name="dwTime">指定动画持续的时间</param>
        /// <param name="dwFlags">指定动画类型，可以是一个或多个标志的组合。</param>
        /// <returns></returns>
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        //下面是可用的常量，根据不同的动画效果声明自己需要的
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


      

        

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        public static void maxh()
        {
         
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Process[] processes = Process.GetProcesses();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

        private void name_1_Click(object sender, EventArgs e)
        {

        }

        private void qsz_xz_1_Click(object sender, EventArgs e)
        {

        }

        private void jgz_ban_1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
