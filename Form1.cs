using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Demo_Buoi5
{
    public partial class Form1 : Form
    {   
 
        public Form1()
        {
            InitializeComponent();
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            foreach (var size in new float[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 })
            {
                toolStripComboBox2.Items.Add(size);
            }
            toolStripComboBox1.SelectedItem = "Tahoma";
            toolStripComboBox2.SelectedItem = 14f;
            richTextBox1.Font = new Font("Tahoma", 14);
        }

        private void đỊnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fdl = new FontDialog();
            fdl.ShowColor = true;
            fdl.ShowApply = true;
            fdl.ShowEffects = true;
            fdl.ShowHelp = true;
            if (fdl.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.Font = fdl.Font;
                richTextBox1.ForeColor = fdl.Color;
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(richTextBox1.Text))
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Rich Text Format | *.rtf | Text File | *.txt | All file | *.*";
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    if (saveDlg.FileName.EndsWith(".rtf"))
                        richTextBox1.SaveFile(saveDlg.FileName, RichTextBoxStreamType.RichText);
                    else
                        richTextBox1.SaveFile(saveDlg.FileName, RichTextBoxStreamType.PlainText);
                    MessageBox.Show("Lưu thành công!", "Thông báo");
                }
                else
                {
                    richTextBox1.SaveFile(richTextBox1.Text, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Lưu thành công!", "Thông báo");
                }
            }
        }

        private void mởTệpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Rich Text Format | *.rtf | Text File | *.txt | All file | *.*";
            if(openDlg.ShowDialog() == DialogResult.OK)
            {
                if (openDlg.FileName.EndsWith(".rtf"))
                    richTextBox1.LoadFile(openDlg.FileName, RichTextBoxStreamType.RichText);
                else
                    richTextBox1.LoadFile(openDlg.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("Mở tệp tin thành công!", "Thông báo");
            }
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Rich Text Format (*.rtf)|*.rtf|Plain Text (*.txt)|*.txt|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FileName.EndsWith(".rtf"))
                    richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                else
                    richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;
                if (currentFont.Style.HasFlag(FontStyle.Bold))
                    newFontStyle = currentFont.Style & ~FontStyle.Bold;
                else
                    newFontStyle = currentFont.Style | FontStyle.Bold;
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;
                if (currentFont.Style.HasFlag(FontStyle.Italic))
                    newFontStyle = currentFont.Style & ~FontStyle.Italic;
                else
                    newFontStyle = currentFont.Style | FontStyle.Italic;
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;
                if (currentFont.Style.HasFlag(FontStyle.Underline))
                    newFontStyle = currentFont.Style & ~FontStyle.Underline;
                else
                    newFontStyle = currentFont.Style | FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), float.Parse(toolStripComboBox2.SelectedItem.ToString()));
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), float.Parse(toolStripComboBox2.SelectedItem.ToString()));
        }
    }
}
