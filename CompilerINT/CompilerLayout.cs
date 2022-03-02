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
    }
}
