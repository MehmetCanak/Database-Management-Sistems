using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane
{
    public partial class uyeSayfasi : Form
    {
        private int kullanici;
        public int klnc { get { return kullanici; }
                          set { kullanici = value; } }
        private string sifre;
        public string sfr { get { return sifre; }
                            set { sifre = value; } }
        public uyeSayfasi()
        {
            InitializeComponent();
        }

        private void uyeSayfasi_Load(object sender, EventArgs e)
        {
            label1.Text = kullanici.ToString()+"   "+sifre;
            //try
            //{
            //    using 
            //}
        }
    }
}
