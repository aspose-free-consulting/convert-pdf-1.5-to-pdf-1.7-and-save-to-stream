using System;
using System.Windows.Forms;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using System.Collections.Generic;

namespace ConversionDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
            fd.InitialDirectory = @"C:\";
            fd.Title = "Please select a PDF file to upload.";
            fd.Multiselect = false;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = fd.FileName;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            
            if (txtFilePath.Text != String.Empty)
            {
                Document doc = new Document(txtFilePath.Text);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                bool flag = doc.Convert("ConversionLog.xml", PdfFormat.v_1_7, ConvertErrorAction.Delete);
                if (flag)
                {
                    doc.Save(ms);
                    MessageBox.Show("Conversion was successful.", "Success");
                }
                else
                {
                    MessageBox.Show("Conversion was not successful.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please Select a PDF File First.", "File Not Found");
            }
        }
    }
}
