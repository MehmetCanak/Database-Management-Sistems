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

        private void yoneticiGirisi_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length != 6 )
            {
                MessageBox.Show("kullanıcı adı 6 haneli olmalıdır. tekrar deneyin.. ");
            }
            else
            {
                
            }
        }
    }
}
