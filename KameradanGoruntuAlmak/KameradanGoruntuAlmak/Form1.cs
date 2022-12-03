using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KameradanGoruntuAlmak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webCamCapture1.Start(0); //webkamerasından görüntü alınmaya başlanıyor
        }

        private void webCamCapture1_ImageCaptured(object source, WebCam_Capture.WebcamEventArgs e)
        {
            pictureBox1.Image = e.WebCamImage;  //picturebox'un image özelliğine bu olayın
                                                //WebCamImage özelliği atanarak görüntü akışı sağlanıyor
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webCamCapture1.CaptureWidth = 640; //form yüklenmesi esnasında alınan görüntü genişliği 640px
            webCamCapture1.CaptureHeight = 480;//form yüklenmesi esnasında alınan görüntü genişliği 640px
            webCamCapture1.Start(0); //Başlat düğmesine gerek kalmadan form
                                       //yüklenirken görüntü akışı alınmaya başlanıyor
            timer1.Enabled = true;  //timer varsayılan olarak devre dışı halde olur, program açılışında
            //etkindeştiriyoruz
            timer1.Interval = 20000;//timer1'in tick olayının çalışması için gereken süre (ms)
            timer2.Enabled = true;//timer varsayılan olarak devre dışı halde olur, program açılışında
            //etkindeştiriyoruz
            timer2.Interval = 1000;//timer2'in tick olayının çalışması için gereken süre (ms)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webCamCapture1.Stop(); //Görüntü akışını durduruyoruz
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close(); //çıkış tuşuna çıkış işlevini ekliyoruz
        }

        int a=0;
        int b = 0; //timer2 bloğunda işe yarayacak
        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(string.Format("picture{0}.png",a)); //picturebox'un image
                        //özelliğinin save alt özelliğini kullanarak resmi kaydedebiliyoruz.
            a=a++;  //isimler aynı isimle kaydedilmesin diye tuşa her tıklandığında 1 arttırıyoruz.
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(string.Format("picture{0}.png", a)); //timer1'in tick olayı
            a = a++;        //her 20 saniyede bir görüntü kaydetmesi kaydetmesi için formun
                            //başlangıç olayındaki invertal'e 20000 atadık
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            b = b + 1; //her saniye bir arttırması için
            if (b < 60) //eğer b, 60'tan küçükse
            {
                this.Text = b.ToString() + " saniyedir kayıtta"; //diye yazdırdık
            }
            else //değilse yani b 60'tan büyükse dakikayı yazmak için
                this.Text = (b / 60).ToString() + " dakikadır kayıtta"; //b'yi 60'a bölüp
            //this.text'e yani Form1.ActiveForm.Text'e, yani form başlığına yazdırdık
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = trackBar1.Value / 100.0; //pencere saydamlığını ayarlamak için
            //bir trackbar ekledik ve trackbar maximumu 100, minumum'y 10, value'yi 100
            //yaptık ve 100.0'a böldük
        }
    }
}
