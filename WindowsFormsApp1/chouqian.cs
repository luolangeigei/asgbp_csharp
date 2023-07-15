using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class chouqian : MaterialForm
    {
        public static chouqian web;

        public chouqian()
        {
            InitializeComponent();
            web = this;
        }

        private void chouqian_Load(object sender, EventArgs e)
        {
            webView21.Source = new Uri($"file:///{@AppDomain.CurrentDomain.BaseDirectory }web/chouqian/index.html");
        }
    }
}
