using CompilerINT.Helpers;
using CompilerINT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompilerINT
{
    public partial class CompilerLayout : Form
    {
        // FILE MENU
        private FileElement FE = new FileElement();
        private IFileHelper _FileHelper = new FileHelper();
        private bool _IsAFileOpen;
        public CompilerLayout()
        {
            _IsAFileOpen = false;
            InitializeComponent();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _IsAFileOpen = true;
            FE = _FileHelper.OpenFile();
            txtFileContent.Text = FE.FileContent;
            txtFileName.Text = FE.FilePath;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void txtFileName_Click(object sender, EventArgs e)
        {

        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFileContent.Text) || _IsAFileOpen)
            {
                SaveFile();
                txtFileName.Text = "";
                txtFileContent.Text = "";
                FE=new FileElement();
                _IsAFileOpen=false;
            }
           
        }
        private void SaveFile()
        {
            bool FileSaved = false;
            DialogResult dialogResult = MessageBox.Show("Guardar", "Desea Guardar los cambios?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                if (_IsAFileOpen)
                {
                    //Guardar cambios del mismo archivo
                    FE.NewFileChanges = txtFileContent.Text;
                    if (FE.FileContent != FE.NewFileChanges)
                    {
                        FileSaved = _FileHelper.SaveFile(FE).FileSaved;
                    }
                    else
                    {
                        FileSaved = true;
                    }

                }
                else
                {
                    FE.NewFileChanges = txtFileContent.Text;
                    FE.FileContent = txtFileContent.Text;
                    FE.IsNewFile = true;
                    //Guardar nuevo archivo
                    FileSaved = _FileHelper.SaveFile(FE).FileSaved;
                }

                if (FileSaved)
                {
                    //si se guardo bien
                    MessageBox.Show("Archivo Guardado correctamente");
                    //si se sigue editando
                    if (!_IsAFileOpen)
                    {
                        _IsAFileOpen = true;
                        FE.IsNewFile = false;
                    }
                    txtFileName.Text = FE.FilePath;

                }
                else
                {
                    //Si mamó
                    MessageBox.Show("Error al guardar el archivo");

                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        public int getWidth()
        {
            int w = 25;
            // num. total de lineas de richTextBox
            int line = txtFileContent.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)txtFileContent.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)txtFileContent.Font.Size;
            }
            else
            {
                w = 50 + (int)txtFileContent.Font.Size;
            }

            return w;
        }

        public void AddLineNumbers()
        {
            Point pt = new Point(0, 0);
            int First_Index = txtFileContent.GetCharIndexFromPosition(pt);
            int First_Line = txtFileContent.GetLineFromCharIndex(First_Index);
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            int Last_Index = txtFileContent.GetCharIndexFromPosition(pt);
            int Last_Line = txtFileContent.GetLineFromCharIndex(Last_Index);
            numLines.SelectionAlignment = HorizontalAlignment.Center;
            numLines.Text = "";
            numLines.Width = getWidth();
            for (int i = First_Line; i <= Last_Line + 1; i++)
            {
                numLines.Text += i + 1 + "\n";
            }
        }

        private void CompilerLayout_Load(object sender, EventArgs e)
        {
            numLines.Font = txtFileContent.Font;
            txtFileContent.Select();
            AddLineNumbers();
        }

        private void txtFileContent_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = txtFileContent.GetPositionFromCharIndex(txtFileContent.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void txtFileContent_VScroll(object sender, EventArgs e)
        {
            numLines.Text = "";
            AddLineNumbers();
            numLines.Invalidate();
        }

        private void txtFileContent_TextChanged(object sender, EventArgs e)
        {
            if (txtFileContent.Text == "")
            {
                AddLineNumbers();
            }

            CheckKeyword("program", Color.IndianRed, 0);
            CheckKeyword("if", Color.Orange, 0);
            CheckKeyword("else", Color.Orange, 0);
            CheckKeyword("fi", Color.Orange, 0);
            CheckKeyword("do", Color.Yellow, 0);
            CheckKeyword("until", Color.Yellow, 0);
            CheckKeyword("while", Color.Yellow, 0);
            CheckKeyword("read", Color.LightGreen, 0);
            CheckKeyword("write", Color.LightGreen, 0);
            CheckKeyword("float", Color.Aqua, 0);
            CheckKeyword("int", Color.Aqua, 0);
            CheckKeyword("bool", Color.Aqua, 0);
            CheckKeyword("not", Color.LightPink, 0);
            CheckKeyword("and", Color.LightPink, 0);
            CheckKeyword("or", Color.LightPink, 0);
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (txtFileContent.Text.Contains(word))
            {
                int index = -1;
                int selectStart = txtFileContent.SelectionStart;

                while ((index = txtFileContent.Text.IndexOf(word, (index + 1))) != -1)
                {
                    txtFileContent.Select((index + startIndex), word.Length);
                    txtFileContent.SelectionColor = color;
                    txtFileContent.Select(selectStart, 0);
                    txtFileContent.SelectionColor = Color.White;
                }
            }

        }

        private void txtFileContent_FontChanged(object sender, EventArgs e)
        {
            numLines.Font = txtFileContent.Font;
            txtFileContent.Select();
            AddLineNumbers();
        }

        private void numLines_MouseDown(object sender, MouseEventArgs e)
        {
            txtFileContent.Select();
            numLines.DeselectAll();
        }

        private void CompilerLayout_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }
    }
}
