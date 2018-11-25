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
    public partial class anasayfa : Form
    {
       public string kutup;
        public string aranan;
        public string kategor;
        

        public anasayfa()
        {
            InitializeComponent();
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {

            using (DataClasses1DataContext dc = new DataClasses1DataContext())
            {
                var kitapad = (from i in dc.kutuphane
                               select i.ad);
                foreach (var k in kitapad)
                {
                    comboBox1.Items.Add(k.ToString());
                }
                
            }
        }
        private void aramayap_Click(object sender, EventArgs e)
        {
            kutup = comboBox1.Text;
            aranan = textBox1.Text;
            kategor = comboBox2.Text;
            AramaYapmaSinifi ays = new AramaYapmaSinifi();
            ays.kutup = kutup;
            ays.aranan = aranan;
            ays.kategori = kategor;
            ays.ShowDialog();
        }

        // var ara= dt.kitap.Where(s => s.ad.Contains(aranan)).Select(s=>s.ad);
        //var ara = from i in dt.kitap
        //          where i.ad.Contains(aranan)
        //          select new { i.isbn,i.ad } ;
        //          ; //like '%aranan%' 
        //var ara2 = dt.kategori.Where(s => s.id == 3 ).Select(s => new { s.ad ,s.id});
        //dataGridView1.DataSource = ara2;

        //label3.Text = ara2.ToString();
        //if (kutup == "Tümü")
        //{
        //    if (kategor == "Eser Adı")
        //    {
        //      var ara = dt.kitap.Where(s => s.ad.Contains(aranan));
        //       dataGridView1.DataSource = ara;
        //    }
        //}




        //anasayfa asd = new anasayfa();
        //asd.dispose();
        //asd.close();
        //aramayapmasinifi ays = new aramayapmasinifi();
        //ays.kutup = kutup;
        //ays.aranan = aranan;
        //ays.kategori = kategor;
        //ays.showdialog();



    }
                
                //var yazar = (from i in con.kitap
                //             where i.ad.Contains(aranan)
                //             select i.ad);
                //for (int i = 0; i == 1; i++)
                //{
                //    label3.Text = yazar[].ToString();
                //}
                //foreach (var d in yazar)
                //{
                //    label3.Text = d.ToString();
                //}

                //label3.Text = yazar.ToString();
                //label3.Text = kutup + aranan + kategori;
            
        

    
}

