using System;
using System.ComponentModel;
using System.Windows.Forms;

// nuget http://stackoverflow.com/questions/433291/what-happened-to-the-taglib-library
// Install-Package taglib

namespace Mp4TagEditor
{
    public partial class Mp4TagEditor : Form
    {
        public Mp4TagEditor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        //http://stackoverflow.com/questions/4361587/where-can-i-find-tag-lib-sharp-examples/4361634#4361634
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            TagLib.File tagFile = TagLib.File.Create(openFileDialog1.FileName); // track is the name of the mp3
            //Then to get a tag value:
            uint year = tagFile.Tag.Year;
            string title = tagFile.Tag.Title;
            long length = tagFile.Length;
            richTextBox1.Text += "\n" + year.ToString();
            richTextBox1.Text += "\n" + title;
            richTextBox1.Text += "\n" + length.ToString();

            //You set the tags like this:
            //tagFile.Tag.Year = Convert.ToUInt32( DateTime.Now.Year);
            //and then save the changes:
            //tagFile.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            TagLib.File tagFile = TagLib.File.Create(openFileDialog2.FileName); // track is the name of the mp3
            //You set the tags like this:
            tagFile.Tag.Year = Convert.ToUInt32(DateTime.Now.Year);
            tagFile.Tag.Title = DateTime.Now.ToString();
            //and then save the changes:
            tagFile.Save();
        }
    }
}