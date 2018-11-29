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
            try
            {
                
                using(DataClasses1DataContext dc=new DataClasses1DataContext())
                {
                    var uyeBul = (from i in dc.uye
                                  join kyt in dc.kayıt on i.id equals kyt.uyeID
                                  //join kutup in dc.kutuphane on kyt.kutuphaneID equals kutup.id
                                  //join odnc in dc.odunc on i.id equals odnc.uyeID
                                  // join ktp in dc.kitap on odnc.kitapID equals ktp.id
                                  //join kat in dc.kategori on ktp.kategoriID equals kat.id
                                  //join yayin in dc.yayinevi on ktp.yayıneviID equals yayin.id
                                  where i.tc == kullanici && i.sifre == sifre
                                  select
                                       new
                                       {
                                           i.id,
                                           //kütüphane = kutup.ad,
                                           //ktp.isbn,
                                           //ktp.ad,
                                           //ktp.yazarAdi,
                                           // kategori_adi = kat.ad,
                                           // yayinevi_ad = yayin.ad,
                                           isim = i.ad,
                                           soyad = i.soyad,
                                           tc_no = i.tc,
                                           email = i.email,
                                           telefon = i.tel,
                                           i.sifre,
                                           kayit_tarihi = kyt.kayit_tarihi
                                       }
                                  ).FirstOrDefault();
                   // dataGridView1.DataSource = uyeBul;
                    
                    
                        //label12.Text = uyeBul.ad;
                        label11.Text = uyeBul.soyad.ToString();
                        label14.Text =kullanici.ToString();
                        comboBox1.Text = uyeBul.email.ToString();
                        comboBox3.Text = uyeBul.telefon.ToString();
                        comboBox2.Text = sifre.ToString();
                    
                    label11.Text = uyeBul.ToString();
                    //label12.Text = uyeBul.Select(s => s.ad).ToString();

                }
            }
            catch
            {

            }
        }

       
    }
}
