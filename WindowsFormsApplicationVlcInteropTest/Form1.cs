using System;
using System.Windows.Forms;

//http://www.youtube.com/watch?v=Bh4qsHrk910

namespace WindowsFormsApplicationVlcInteropTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] op3 = { " :sout=#duplicate{dst=display,dst=std{access=file,mux=mp4,dst='C:\\Users\\stefan\\Desktop\\mytest2.mp4'}}", " " };
            //AXVLC.VLCPlugin test = new AXVLC.VLCPlugin();
            //test.addTarget("http://vthr.videolan.org/~dionoea/vlc-plugin-demo/streams/sw_h264.asf", op3, AXVLC.VLCPlaylistMode.VLCPlayListAppendAndGo, -666);
            //AXVLC.VLCPlugin2 test2 = new AXVLC.VLCPlugin2();
            //test.play();
        }
    }
}