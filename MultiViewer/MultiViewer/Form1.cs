using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Image viewer code block start.

        private void showButton_Click(object sender, EventArgs e)
        {
            //Open a FileDialog to search for an image file, if the User chooses OK,
            //load the image

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear the picture.
            pictureBox1.Image = null;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            // Show the color dialog box. If the user clicks OK, change the
            // PictureBox control's background to the color the user chose.
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.BackColor = colorDialog1.Color;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // If the user selects the Scale check box, 
            // change the PictureBox's
            // SizeMode property to "Zoom". If the user clears 
            // the check box, change it to "Normal".
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }
        //Image viewer code block end.

        //Text Viewer Code Block Start.

        private void chooseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "txt files (*.txt)|*.txt;|C# files(*.cs)|*.cs;|All files (*.*)|*.*";

            if (f.ShowDialog() == DialogResult.OK)

            //Make sure the listBox is empty
            //Populate the listBox with the chosen text file

            {
                listBox1.Items.Clear();
                List<string> lines = new List<string>();


                using (StreamReader r = new StreamReader(f.OpenFile()))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                        listBox1.Items.Add(line);
                }
            }

            //Should the user choose cancel on the file dialog

            else

            {
                listBox1.Items.Clear();
                MessageBox.Show(string.Format("No file chosen"));
            }

        }

        private void cleartextButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        //Text Viewer Code Block End


        //Closing the application code block.

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}