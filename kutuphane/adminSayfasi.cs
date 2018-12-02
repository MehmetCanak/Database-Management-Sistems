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
    public partial class adminSayfasi : Form
    {
        string ad1;
        string soyad1;
        string sifre1;
        int tc1;
        string email1;
        int id1;
        string tel1;
       private int yonetici;
       private string ysifre;
        public int yntc { get { return yonetici; }
                        set
                        {
                yonetici = value;
                         } }
        public string sfr
        { get { return ysifre; } set { ysifre = value; }
        }

        int oduncUye;
        string oduncKitap;
        public adminSayfasi()
        {
            InitializeComponent();
        }
        
        private void ekleKullanici_Click(object sender, EventArgs e)
        {
            ad1 = textBox1.Text;
            soyad1 = textBox2.Text;
            tc1 = int.Parse(textBox3.Text);
            if (tc1.ToString().Length != 9)
            {
                MessageBox.Show("tc numarası 9 haneli olmalidir: ");
                textBox3.Text="";
            }
            email1 = textBox4.Text;
            Random rm = new Random();
            sifre1 = (rm.Next(123456, 989789).ToString());
            tel1 = rm.Next(1111111, 9999999).ToString();
            DateTime zaman = DateTime.Now;
            
           
            using (DataClasses1DataContext dcdc=new DataClasses1DataContext())
            {
                var idbul = dcdc.uye.Max(k=>k.id);
                var ybul = (from i in dcdc.admin
                            join j in dcdc.kutuphane on i.kutuphaneID equals j.id
                            where i.kutuphaneID==j.id && i.id == yonetici && i.sifre == ysifre
                            select j.id).FirstOrDefault();
                id1 = idbul;
                id1 = id1 + 1;
                var tcVrmi = dcdc.uye.Where(s => s.tc == tc1).Select(s => s.tc).Any();
                if (tcVrmi == true)
                {
                    MessageBox.Show("bu tc de üye var tekrar deneyiniz :");
                }
                uye uyeSinifi = new uye()
                {
                    id = id1,
                    ad = ad1,
                    soyad = soyad1,
                    tc = tc1,
                    email = email1,
                    sifre = sifre1,
                    tel = tel1,
                    
    
                };
                kayıt kyt = new kayıt()
                {
                    kayit_tarihi = zaman.Date,
                    kutuphaneID = 1,
                    uyeID = id1,
                    

                };


                dcdc.uye.InsertOnSubmit(uyeSinifi);
                dcdc.kayıt.InsertOnSubmit(kyt);
                dcdc.SubmitChanges();
               
            }
            textBox1.Text = "";textBox2.Text = "";textBox3.Text="";
            textBox4.Text = "";
            
        }

        private void listeleKullanici_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataClasses1DataContext dkct=new DataClasses1DataContext())
                {
                    var uyeyazdir = dkct.uye.Select(s => s);
                    dataGridView1.DataSource = uyeyazdir;
                }
            }
            catch (Exception hata)
            {
                label12.Text = hata.ToString();
            }
            
        }

      
    

        private void kullaniciSil_Click(object sender, EventArgs e)
        {
            int sil;
            if (textBox3.Text == "")
            {
                MessageBox.Show("SİLMEK İSTEDİGİN TC Yİ GİR: ");
            }

            try
            {
                sil = int.Parse(textBox3.Text);
            }
            catch(Exception hata)
            {
                MessageBox.Show("tekrar dene");
                sil = 123456789;
                textBox3.Text = hata.ToString();
            };
            
            try
            {
                using(DataClasses1DataContext dkkls=new DataClasses1DataContext())
                {

                    var sill = (from i in dkkls.uye
                                where i.tc == sil
                                select i).FirstOrDefault();

                    if (sill != null)
                    {
                        var dondurId = (from i in dkkls.uye
                                        join j in dkkls.kayıt on i.id equals j.uyeID
                                        where i.tc == sil && i.id == j.uyeID
                                        select j).FirstOrDefault();
                        
                        if(dondurId!= null)
                        {
                            dkkls.kayıt.DeleteOnSubmit(dondurId);
                        }
                        dkkls.SubmitChanges();
                       
                        dkkls.uye.DeleteOnSubmit(sill);
                        dkkls.SubmitChanges();
                        
                    }
                    else
                    {
                        textBox3.Text = "HATA VAR";
                    }
                    dkkls.SubmitChanges();
                    
                }
            }
            catch
            {

            }
            textBox3.Text = "";
        }

        private void oduncVer_Click(object sender, EventArgs e)
        {
            oduncKitap = textBox5.Text;
            oduncUye = int.Parse(textBox6.Text);
            DateTime zaman = DateTime.Now;
            DateTime zaman2 = zaman.AddDays(20);
            string durum = "ödünc ";

            using (DataClasses1DataContext dc=new DataClasses1DataContext())
            {
                var varmiUye = dc.uye.Where(s => s.tc == oduncUye).Select(s => s.ad).Any();
                var varmiKitap = dc.kitap.Where(s => s.isbn == oduncKitap).Select(s => s.ad).Any();
                var maxId = dc.odunc.Select(s => s.id).Max();
                if (varmiUye == true && varmiKitap==true)
                {
                    var uyeİdBul = dc.uye.Where(s => s.tc == oduncUye).Select(s => s.id).FirstOrDefault();
                    var kitapİdBul = dc.kitap.Where(s => s.isbn == oduncKitap).Select(s => s.id).FirstOrDefault();

                    odunc odn = new odunc()
                    {
                        id=maxId+1,
                        kutuphaneID = 1,
                        uyeID = uyeİdBul,
                        kitapID = kitapİdBul,
                        odunc_alma_tarihi = zaman.Date,
                        son_teslim_tarihi = zaman2.Date
                    };
                  
                   
                    dc.odunc.InsertOnSubmit(odn);
                    dc.SubmitChanges();
                   
                    
                }
                else
                {
                    MessageBox.Show("böyle bir uye yoktur veya isbn yoktur");
                }

                textBox6.Text = "";textBox5.Text = "";
                dc.SubmitChanges();
            }
            
            
        }

        private void kitabiAl_Click(object sender, EventArgs e)
        {
            string isbnKitap = textBox7.Text;
            using(DataClasses1DataContext dc =new DataClasses1DataContext())
            {
                var varmi = (from i in dc.kitap
                             join j in dc.odunc on i.id equals j.kitapID
                             where i.isbn == isbnKitap && i.id == j.kitapID
                             select j).FirstOrDefault();
                if(varmi!= null)
                {
                    dc.odunc.DeleteOnSubmit(varmi);
                    dc.SubmitChanges();
                }
                else
                {
                    MessageBox.Show("yalnis isbn tekrar dene ");
                }
                dc.SubmitChanges();
            }
            textBox7.Text = "";
        }
    }
    
}

//var id = (from i in dkkls.uye
//          join j in dkkls.kayıt on i.id equals j.uyeID
//          where i.tc == sil && i.id == j.uyeID
//          select j.id
//        );
//var kytUye = dkkls.kayıt.Where(s => s.uyeID == id).Select(s => s).Single();
//dkkls.kayıt.DeleteOnSubmit(id);
//dkkls.SubmitChanges();
//var IdDondur2 = dkkls.uye.Where(s => s.tc == sil).Select(s => s).FirstOrDefault();


//var uyeBul = (from od in dc.odunc
//          join k in dc.kutuphane on od.kutuphaneID equals k.id
//          join i in dc.uye on od.uyeID equals i.id
//          join ktp in dc.kitap on od.kitapID equals ktp.id
//          where  i.tc==oduncUye && ktp.isbn==oduncKitap
//          select new {
//                      k.});
//var uyeId = (from i in dc.uye
//             where i.tc==oduncUye
//             select i.id
//             );
//var kitapId = (from k in dc.kitap
//               where k.isbn==oduncKitap
//               select k.id);

//odunc odc = new odunc()
//{
//    kutuphaneID = 1,
//    uyeID = uyeId.FirstOrDefault(),
//    kitapID = kitapId.FirstOrDefault(),
//    //odunc_alma_tarihi=DateTime.Now

//};

//dc.odunc.InsertOnSubmit(odc);
//dc.SubmitChanges();