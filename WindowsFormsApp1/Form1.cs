
using MaterialSkin.Controls;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Compression;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 f=new Form2();
        private void Form1_Load(object sender, EventArgs e)
        {
         
            backgroundWorker1.RunWorkerAsync();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
          
          //  materialTabControl1.SelectedIndex = 1;//从0开始哦，第一个tabpage
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Form2 f= new Form2();
            f.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            if(pack_text.Text!="")
                {
                qsz.pack=pack_text.Text;
            }
            else
            {
                qsz.pack="pic";
            }
            DirectoryInfo folder3 = new DirectoryInfo(@AppDomain.CurrentDomain.BaseDirectory + "pic\\");

            foreach (DirectoryInfo file in folder3.GetDirectories())
            {
                string[] name = file.FullName.Split('\\');
                pack_text.Items.Add(name.Last());
            }
            DirectoryInfo folder = new DirectoryInfo(@AppDomain.CurrentDomain.BaseDirectory + "pic\\"+qsz.pack+"\\hun\\");
            foreach (FileInfo file in folder.GetFiles("*.png"))
            {
                string[] name = file.FullName.Split('\\');
                jgz_xz_1.Items.Add(name.Last());
                jgz_ban_1.Items.Add(name.Last());
                jgz_ban_2.Items.Add(name.Last());
                jgz_ban_3.Items.Add(name.Last());
            }
            DirectoryInfo folder1 = new DirectoryInfo(@AppDomain.CurrentDomain.BaseDirectory + "pic\\"+qsz.pack+"\\sur\\");
            foreach (FileInfo file in folder1.GetFiles("*.png"))
            {
                string[] name = file.FullName.Split('\\');
                qsz_ban_1.Items.Add(name.Last());
                qsz_ban_2.Items.Add(name.Last());
                qsz_ban_3.Items.Add(name.Last());
                qsz_ban_4.Items.Add(name.Last());
                qsz_ban_5.Items.Add(name.Last());
                qsz_ban_6.Items.Add(name.Last());
                qsz_xz_1.Items.Add(name.Last());
                qsz_xz_2.Items.Add(name.Last());
                qsz_xz_3.Items.Add(name.Last());
                qsz_xz_4.Items.Add(name.Last());
               
            }
            DirectoryInfo folder2 = new DirectoryInfo(@AppDomain.CurrentDomain.BaseDirectory + "pic\\"+qsz.pack+"\\map\\");
            foreach (FileInfo file in folder2.GetFiles("*.png"))
            {
                string[] name = file.FullName.Split('\\');
                map_set.Items.Add(name.Last());
                
            }
            InstalledFontCollection MyFont = new InstalledFontCollection();
            FontFamily[] MyFontFamilies = MyFont.Families;
            int Count = MyFontFamilies.Length;
            for (int i = 0; i < Count; i++)
            {
                font_text.Items.Add(MyFontFamilies[i].Name);
            }
        
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

        //static extern Int32 GetShortPathName(String path, StringBuilder shortPath, Int32 shortPathLength);
        void Play(string path)
        {
            mciSendString("open " + path + " alias media", null, 0, Handle, 0);
            mciSendString("play media", null, 0, Handle, 0);
        }
        private void materialComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void qsz_xz_1_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.qsz_xz_1.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\sur\\" + qsz_xz_1.Text);
       
        }

        private void qsz_xz_2_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.qsz_xz_2.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\sur\\" + qsz_xz_2.Text);

        }

        private void qsz_xz_3_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.qsz_xz_3.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\sur\\" + qsz_xz_3.Text);

        }

        private void qsz_xz_4_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.qsz_xz_4.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\sur\\" + qsz_xz_4.Text);

        }

        private void jgz_ban_1_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.jgz_ban_1.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\hun\\" + jgz_ban_1.Text);
        }

        private void jgz_ban_2_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.jgz_ban_2.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\hun\\" + jgz_ban_2.Text);
        }

        private void jgz_ban_3_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.jgz_ban_3.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\hun\\" + jgz_ban_3.Text);
        }

        private void qsz_ban_1_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.qsz_ban_1.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\sur\\" + qsz_ban_1.Text);
        }

        private void qsz_ban_2_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.qsz_ban_2.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\sur\\" + qsz_ban_2.Text);
        }

        private void qsz_ban_3_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.qsz_ban_3.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\sur\\" + qsz_ban_3.Text);
        }

        private void qsz_ban_4_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.qsz_ban_4.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\sur\\" + qsz_ban_4.Text);
        }

        private void qsz_ban_5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void qsz_ban_5_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.qsz_ban_5.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\sur\\" + qsz_ban_5.Text);
        }

        private void qsz_ban_6_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.qsz_ban_6.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\sur\\" + qsz_ban_6.Text);
        }

        private void jgz_xz_1_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.jgz_xz_1.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\hun\\" + jgz_xz_1.Text);
        }

        private void materialMaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.name_1.Text = materialMaskedTextBox1.Text;

              }

        private void materialMaskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.name_2.Text = materialMaskedTextBox2.Text;
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            (materialMaskedTextBox1.Text, materialMaskedTextBox2.Text) = (materialMaskedTextBox2.Text, materialMaskedTextBox1.Text);
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            qsz.font_name = font_text.Text;
            qsz.font_size=font_size.Text;
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {

            OpenFileDialog openfile = new OpenFileDialog();

            if (openfile.ShowDialog() == DialogResult.OK && openfile.FileName!="") ;
            {
                pictureBox1.ImageLocation = openfile.FileName;
                img_path.Text = openfile.FileName;
                qsz.img_path= openfile.FileName;
            }

            openfile.Dispose();
        }
        /// <summary>
        /// 发送Get请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="dic">请求参数定义</param>
        /// <returns></returns>
        public static string Get(string url)
        {
            string result = "";
            StringBuilder builder = new StringBuilder();
            builder.Append(url);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(builder.ToString());
            //添加参数
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            try
            {
                //获取内容
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            finally
            {
                stream.Close();
            }
            return result;
        }

         private async void  timer1_Tick(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    string str = Post(adress_set.Text+"/api/get", "token=" + token_text.Text);
                    JObject obj1 = JObject.Parse(str);
                    string banq1 = obj1["banq1"].ToString();
                    string banq2 = obj1["banq2"].ToString();
                    string banq3 = obj1["banq3"].ToString();
                    string banq4 = obj1["banq4"].ToString();
                    string banq5 = obj1["banq5"].ToString();
                    string banq6 = obj1["banq6"].ToString();
                    string bang1 = obj1["bang1"].ToString();
                    string bang2 = obj1["bang2"].ToString();
                    string bang3 = obj1["bang3"].ToString();
                    string xuanq1 = obj1["xuanq1"].ToString();
                    string xuanq2 = obj1["xuanq2"].ToString();
                    string xuanq3 = obj1["xuanq3"].ToString();
                    string xuanq4 = obj1["xuanq4"].ToString();
                    string xuanj1 = obj1["xuanj1"].ToString();
                    qsz_ban_1.Text = banq1+".png";
                    qsz_ban_2.Text = banq2 + ".png";
                    qsz_ban_3.Text = banq3 + ".png";
                    qsz_ban_4.Text = banq4 + ".png";
                    qsz_ban_5.Text = banq5 + ".png";
                    qsz_ban_6.Text = banq6 + ".png";
                    jgz_ban_1.Text = bang1 + ".png";
                    jgz_ban_2.Text = bang2 + ".png";
                    jgz_ban_3.Text = bang3 + ".png";
                    qsz_xz_1.Text = xuanq1 + ".png";
                    qsz_xz_2.Text = xuanq2 + ".png";
                    qsz_xz_3.Text = xuanq3 + ".png";
                    qsz_xz_4.Text = xuanq4 + ".png";
                    jgz_xz_1.Text= xuanj1 + ".png";

                }
                catch
                {
                }
            });
            thread.Start();
            
          
        }

        /// <summary>
        /// 发送一个post请求
        /// </summary>
        /// <param name="url">请求的url</param>
        /// <param name="content">参数 D:/1.zip </param>
        public static string Post(string url, string content)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            #region 添加Post 参数
            byte[] data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
           string token_th= Get(adress_set.Text+"/api/token/get?bo="+bo.Text);
            JObject obj1 = JObject.Parse(token_th);
             string banq1 = obj1["token"].ToString();
            token_text.Text= banq1;


        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            timer1.Start();
        }

        private async void yclj_kg_CheckedChanged(object sender, EventArgs e)
        {
            if(yclj_kg.Checked==true)
            {
                
               timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void map_set_TextChanged(object sender, EventArgs e)
        {
            Form2.form2.map_p.BackgroundImage = Image.FromFile(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\map\\" + map_set.Text);

        }

        private void materialButton7_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择bp包";
            dialog.Filter = "BP包文件(*.luolan)|*.luolan|BP图片包(*.ASG)|*.ASG";
       
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string file = dialog.FileName;
                    string filename = System.IO.Path.GetFileNameWithoutExtension(file);//文件名  “Default.aspx”
                    if (!Directory.Exists(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + filename))
                    {
                        Directory.CreateDirectory(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + filename);
                    }
                    ZipFile.ExtractToDirectory(file, @AppDomain.CurrentDomain.BaseDirectory + "pic\\" + filename);
                    MessageBox.Show("导入成功！");
                }
                catch (Exception ex)
                { 
                    MessageBox.Show("导入失败,"+ex.Message);
                }
                pack_text.Items.Clear();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void pack_text_TextChanged(object sender, EventArgs e)
        {
            qsz.pack=pack_text.Text;
            backgroundWorker3.RunWorkerAsync();
        }

        private void pack_text_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            qsz_ban_1.Items.Clear();
            qsz_ban_2.Items.Clear();
            qsz_ban_3.Items.Clear();
            qsz_ban_4.Items.Clear();
            qsz_ban_5.Items.Clear();
            qsz_ban_6.Items.Clear();
            jgz_ban_1.Items.Clear();
            jgz_ban_2.Items.Clear();
            jgz_ban_3.Items.Clear();
            qsz_xz_1.Items.Clear();
            qsz_xz_2.Items.Clear();
            qsz_xz_3.Items.Clear();
            qsz_xz_4.Items.Clear();
            jgz_xz_1.Items.Clear();
            DirectoryInfo folder = new DirectoryInfo(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\hun\\");
            foreach (FileInfo file in folder.GetFiles("*.png"))
            {
                string[] name = file.FullName.Split('\\');
                jgz_xz_1.Items.Add(name.Last());
                jgz_ban_1.Items.Add(name.Last());
                jgz_ban_2.Items.Add(name.Last());
                jgz_ban_3.Items.Add(name.Last());
            }
            DirectoryInfo folder1 = new DirectoryInfo(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\sur\\");
            foreach (FileInfo file in folder1.GetFiles("*.png"))
            {
                string[] name = file.FullName.Split('\\');
                qsz_ban_1.Items.Add(name.Last());
                qsz_ban_2.Items.Add(name.Last());
                qsz_ban_3.Items.Add(name.Last());
                qsz_ban_4.Items.Add(name.Last());
                qsz_ban_5.Items.Add(name.Last());
                qsz_ban_6.Items.Add(name.Last());
                qsz_xz_1.Items.Add(name.Last());
                qsz_xz_2.Items.Add(name.Last());
                qsz_xz_3.Items.Add(name.Last());
                qsz_xz_4.Items.Add(name.Last());

            }
            DirectoryInfo folder2 = new DirectoryInfo(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + qsz.pack + "\\map\\");
            foreach (FileInfo file in folder2.GetFiles("*.png"))
            {
                string[] name = file.FullName.Split('\\');
                map_set.Items.Add(name.Last());

            }
            InstalledFontCollection MyFont = new InstalledFontCollection();
            FontFamily[] MyFontFamilies = MyFont.Families;
            int Count = MyFontFamilies.Length;
            for (int i = 0; i < Count; i++)
            {
                font_text.Items.Add(MyFontFamilies[i].Name);
            }
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + pack_text.Text);
            }
            catch (Exception ex){
                MessageBox.Show("打开包失败！"+ex.Message);
            }
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            if (pack_text.Text != "")
            {
                SaveFileDialog file = new SaveFileDialog();//定义新的文件保存位置控件
                file.Filter = "BP包文件(*.luolan)|*.luolan|BP图片包(*.ASG)|*.ASG";//设置文件后缀的过滤

                if (file.ShowDialog() == DialogResult.OK)//如果有文件保存路径
                {
                    string save = file.FileName;
                    CompressDirectoryZip(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + pack_text.Text, save);
                }
            }
            else
            {
                MessageBox.Show("请先选择你要导出的包名称");
            }

           
        }

    

        /// <summary>
        /// 将指定目录压缩为Zip文件
        /// </summary>
        /// <param name="folderPath">文件夹地址 D:/1/ </param>
        /// <param name="zipPath">zip地址 D:/1.zip </param>
        public static void CompressDirectoryZip(string folderPath, string zipPath)
        {
         
            ZipFile.CreateFromDirectory(folderPath, zipPath, CompressionLevel.Optimal, false);
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.Delete(@AppDomain.CurrentDomain.BaseDirectory + "pic\\" + pack_text.Text,true);
                MessageBox.Show("删除成功！");
            }
            catch(Exception ex) 
            {
                MessageBox.Show("删除失败," + ex.Message);
            }
            backgroundWorker3.RunWorkerAsync();
            DirectoryInfo folder3 = new DirectoryInfo(@AppDomain.CurrentDomain.BaseDirectory + "pic\\");
            pack_text.Items.Clear();
            foreach (DirectoryInfo file in folder3.GetDirectories())
            {
                string[] name = file.FullName.Split('\\');
                pack_text.Items.Add(name.Last());
            }
        }

        private void materialButton12_Click(object sender, EventArgs e)
        {

            OpenFileDialog openfile = new OpenFileDialog();

            if (openfile.ShowDialog() == DialogResult.OK && openfile.FileName != "") ;
            {
                try
                {
                    pictureBox1.ImageLocation = openfile.FileName;
                    File.Copy(openfile.FileName, @AppDomain.CurrentDomain.BaseDirectory + "music\\", true);
                    MessageBox.Show("导入成功！");
                }
                catch
                {
                    MessageBox.Show("导入失败");
                }
            }

            openfile.Dispose();
        }

        private void qsz_xz_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            Play(@AppDomain.CurrentDomain.BaseDirectory + "music\\bp.mp3");
        }

        private void materialButton13_Click(object sender, EventArgs e)
        {

        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton13_Click_1(object sender, EventArgs e)
        {

        }

        private void materialTextBox22_Click(object sender, EventArgs e)
        {

        }

        private void materialButton19_Click(object sender, EventArgs e)
        {
           
        }

        private void materialButton19_Click_1(object sender, EventArgs e)
        {
            chouqian chouqian = new chouqian();
            chouqian.Show();
            chouqian.web.webView21.Source= new Uri($"file:///{@AppDomain.CurrentDomain.BaseDirectory}web/chouqian/index.html");
        }

        private void materialButton20_Click(object sender, EventArgs e)
        {
            chouqian chouqian = new chouqian();
            chouqian.Show();
            chouqian.web.webView21.Source = new Uri($"file:///{@AppDomain.CurrentDomain.BaseDirectory}web/jingup/index.html");

        }
    }
}
