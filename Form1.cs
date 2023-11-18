using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneQRCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void siticoneTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            string ad = siticoneTextBox1.Text;
            string soyad = siticoneTextBox2.Text;
            string telefon = siticoneTextBox3.Text;
            string email = siticoneTextBox4.Text;

            string vcardText = $"BEGIN:VCARD\nVERSION:3.0\nN:{soyad};{ad}\nFN:{ad} {soyad}\nTEL:{telefon}\nEMAIL:{email}\nEND:VCARD";


            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(vcardText, QRCodeGenerator.ECCLevel.Q);
            QRCodeData qrCodeData1 = qrGenerator.CreateQrCode(vcardText, QRCodeGenerator.ECCLevel.Q);
            QRCodeData qrCodeData2 = qrGenerator.CreateQrCode(vcardText, QRCodeGenerator.ECCLevel.Q);
            QRCodeData qrCodeData3 = qrGenerator.CreateQrCode(vcardText, QRCodeGenerator.ECCLevel.Q);


            QRCode qrCode = new QRCode(qrCodeData);
            QRCode qrCode1 = new QRCode(qrCodeData1);
            QRCode qrCode2 = new QRCode(qrCodeData2);
            QRCode qrCode3 = new QRCode(qrCodeData3);

            Bitmap qrCodeImage = qrCode.GetGraphic(7);
            Bitmap qrCodeImage1 = qrCode1.GetGraphic(7);
            Bitmap qrCodeImage2 = qrCode2.GetGraphic(7);
            Bitmap qrCodeImage3 = qrCode3.GetGraphic(7);
            pictureBox1.Image = qrCodeImage;
            pictureBox1.Image = qrCodeImage1;
            pictureBox1.Image = qrCodeImage2;
            pictureBox1.Image = qrCodeImage3;



            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"PNG|*.png" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    pictureBox1.Image.Save(saveFileDialog.FileName);
                    MessageBox.Show("the file is saved");
                }
            }
            siticoneTextBox1.Text = "";
            siticoneTextBox2.Text = "";
            siticoneTextBox3.Text = "";
            siticoneTextBox4.Text = "";
            pictureBox1.Image = null;
        }
    }
    }

