using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class Form1 : Form
    {
        string xmlPublicKey = "";
        string xmlKeys = "";
        RSACryption a = new RSACryption();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
            a.RSAKey(out xmlKeys,out xmlPublicKey);
            textBox1.Text = xmlPublicKey;
            textBox2.Text = xmlKeys;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = MachineCode.GetMachineCodeString();
            string b = "";
            a.GetHash(textBox3.Text,ref b);
            string b2 = "";
            a.SignatureFormatter(xmlKeys, b,ref b2);
            textBox4.Text = b2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = MachineCode.GetMachineCodeString();
            string b = "";
            a.GetHash(textBox3.Text, ref b);
            bool bo = a.SignatureDeformatter(xmlPublicKey, b, textBox4.Text);
            if (bo)
            {
                MessageBox.Show("验证成功！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = EncryptUtil.Des(textBox4.Text, EncryptUtil.Md532("INMES"), EncryptUtil.Md532("85609518"));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = EncryptUtil.AesStr(textBox4.Text, EncryptUtil.Md532("INMES"), EncryptUtil.Md532("85609518"));

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("xmlPublicKey", true))
            {
                sw.WriteLine(xmlPublicKey);
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("xmlKeys", true))
            {
                sw.WriteLine(xmlKeys);
            }
        }
    }
}
