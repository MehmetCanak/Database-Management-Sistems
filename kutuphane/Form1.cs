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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var ara = from i in dt.kitap
            //          where i.ad.Contains(aranan)
            //          select new { i.isbn, i.ad };
            //; //like '%aranan%' 
            //var ara2 = dt.kategori.Where(s => s.id == 3).Select(s => new { s.ad, s.id });
            //dataGridView1.DataSource = ara2;

            //label3.Text = ara2.ToString();

        }
        private void projeodevi_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Close();

            anasayfa ansyf= new anasayfa();
            ansyf.Show();
            this.Hide();


        }
    }
}
