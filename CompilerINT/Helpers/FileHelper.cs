using CompilerINT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompilerINT.Helpers
{
    public class FileHelper : IFileHelper
    {
        public FileElement OpenFile()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                //|All files (*.*)|*.*
                //Now is only text files
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            //            MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
            return new FileElement() {FileContent = fileContent, FilePath=filePath, IsNewFile=false };
        }

        public FileElement SaveFile(FileElement fe)
        {
            if (fe.IsNewFile)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                   // saveFileDialog.ShowDialog(); //Opens the Show File Dialog  
                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) //Check if it's all ok  
                    {
                        string name = saveFileDialog.FileName + ".txt"; //Just to make sure the extension is .txt
                        File.WriteAllText(name, fe.NewFileChanges); //Writes the text to the file and saves it
                        fe.FilePath = name;
                        fe.FileSaved = true;
                    }
                }
            }
            else
            {
                if (fe.FilePath!=null)
                {
                    File.WriteAllText(fe.FilePath, fe.NewFileChanges);
                    fe.FileSaved = true;
                }
            }
            return fe;
        }
    }
}
