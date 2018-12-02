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
    public partial class oturumAnasayfa : Form
    {
        public oturumAnasayfa()
        {
            InitializeComponent();
        }
        public int kullaniciAdi;
        public string sifre;

        private void yoneticiGirisi_Click(object sender, EventArgs e)
        {
            kullaniciAdi = int.Parse(textBox1.Text);
            var sifre = textBox2.Text;

            if(kullaniciAdi.ToString().Length != 6 )
            {
                MessageBox.Show("kullanıcı adı 6 haneli olmalıdır. tekrar deneyin.. ");
            }
            else
            {
                    using (DataClasses1DataContext dk1=new DataClasses1DataContext())
                {
                    var kullanici = (from i in dk1.admin
                                     where i.id.ToString()==kullaniciAdi.ToString() && i.sifre==sifre.ToString()
                                     select i.ad).Any();
                    label10.Text = kullanici.ToString();
                    if (kullanici == true)
                    {
                        oturumAnasayfa oas = new oturumAnasayfa();
                        oas.Close();
                        adminSayfasi asf = new adminSayfasi();
                        asf.yntc = kullaniciAdi;
                        asf.sfr = sifre;
                        asf.Show();
                        this.Hide();

                    }else
                    {
                        MessageBox.Show("kullanıcı adi veya parola yalnış");}}}
            textBox1.Text = "";textBox2.Text = ""; }

       

        private void uyeGirisi_Click(object sender, EventArgs e)
        {
            kullaniciAdi = int.Parse(textBox3.Text);
            sifre = textBox4.Text;
            try
            {
                if (kullaniciAdi.ToString().Length != 9)
                {
                    MessageBox.Show("kullanıcı adı 6 karekter uzunlugunda olmalidir ");
                }
                else
                {
                    using(DataClasses1DataContext dcdc=new DataClasses1DataContext())
                    {
                        var kullanici = (from i in dcdc.uye
                                         where i.tc.ToString() == kullaniciAdi.ToString() && i.sifre == sifre.ToString()
                                         select i.ad).Any();
                        label10.Text = kullanici.ToString();
                        if (kullanici == true)
                        {
                            oturumAnasayfa my= new oturumAnasayfa();
                            my.Close();
                            uyeSayfasi us = new uyeSayfasi();
                            us.sfr = sifre;
                            us.klnc = kullaniciAdi;
                            us.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("kullanıcı adi veya parola yalnış");
                        }
                    }
                }

            }
            catch(Exception hata)
            {
                MessageBox.Show("hata kodu: ", hata.ToString());
            }
            
        }
    }
}
