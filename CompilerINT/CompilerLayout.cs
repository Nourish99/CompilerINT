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
using CompilerCLI.Helpers;
using CompilerCLI.Models;
using Antlr4.Runtime.Tree;
using CompilerCLI.ParserTools;
using CompilerCLI.GenerateCode;

namespace CompilerINT
{
    public partial class CompilerLayout : Form
    {
        // FILE MENU
        private FileElement FE = new FileElement();
        private IFileHelper _FileHelper = new FileHelper();
        private bool _IsAFileOpen;
        private ProceduresHelper proceduresHelper = new ProceduresHelper();
        public CompilerLayout()
        {
            _IsAFileOpen = false;
            InitializeComponent();
            SetupLexTable(lexicDataGridView);
            SetupSymbolsTable(symbolsDataGridView);
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
            numLines.ScrollBars = RichTextBoxScrollBars.None;
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

        private void MakeLexicalAnalisis()
        {
            
            //se realiza el analisis
            try
            {
                LexerResultModel lrm = proceduresHelper.GetLexerAnalisisFromText(txtFileContent.Text);
                //revisamos lo que obtuvimos
                if (lrm.Results == null)
                {
                    MessageBox.Show("Error al realizar el analisis lexico! \n Archivo vacio");
                    return;
                }
                
                //
                PopulateLexTable(lrm.Results);
                if (lrm.Errorrs == null)
                {
                    //Aqui meter en la pestaña de errores que no hubo
                    richTextBox1.Text += "\n No hay errores del lexico!";
                }
                else
                {
                    PopulateLexErrorsTable(lrm.Errorrs);
                }

                ParserResultModel prm = proceduresHelper.GetParserAnalisis(txtFileContent.Text);
                if (prm.Errors!=null)
                {
                    richTextBox1.Text = "";
                    richTextBox1.Text += "Mensaje   Linea   Columna";
                    foreach (var item in prm.Errors)
                    {
                        //"Mensaje\tLinea\tColumna"i.getMessage() + "\t" + i.getLine() + "\t" +  i.getCharPositionInLine()
                        richTextBox1.Text += $"\n{item.getMessage()}\t{item.getLine()}\t{item.getCharPositionInLine()}";
                    }
                }

                richTextBoxSintatic.Text = "";
                richTextBoxSintatic.ForeColor = Color.Blue;
                PrintTree(" ", false, false, richTextBoxSintatic, prm.semanticResult.ASTTree);

                richTextBoxSemanthic.Text = "";
                richTextBoxSemanthic.ForeColor = Color.Green;
                if (prm.semanticResult.SemanticErrors.Count == 0)
                    PrintTree(" ", false, true, richTextBoxSemanthic, prm.semanticResult.ASTTree);
                else
                {
                    foreach (string msg in prm.semanticResult.SemanticErrors)
                    {
                        StringBuilder sb = new StringBuilder(msg);
                        sb.Replace("Linea:", "      ");
                        sb.Replace("Columna:", "      ");
                        sb.Replace("Col:", "      ");
                        sb.Replace(".", " ");
                        sb.Replace(",", " ");
                        richTextBox1.Text += $"\n{sb.ToString()}";
                    }
                }

                PopulateSymbolsTable(prm.semanticResult.Variables);

                var intermediateCode = new IntermediateGenerator(prm.semanticResult.ASTTree);
                intermediateCode.genCode(prm.semanticResult.ASTTree);
                intCode.Text = intermediateCode.Intermediate_code;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el analisis lexico!");
            }
        }

        public void PrintTree(string indent, bool last, bool typed, RichTextBox textForm, ASTNode finalTree)
        {
            finalTree.tree = "";
            if (finalTree.Children == null)
            {
                return;
            }

            finalTree.tree += indent;
            if (last)
            {
                finalTree.tree += "\\_";
                indent += "   ";
            }
            else
            {
                finalTree.tree += "!_";
                indent += "|   ";
            }
            if (finalTree.Tipo != null && typed)
            {
                finalTree.tree += string.Format("{0}   -->   ( {1} ){2}", finalTree.Label, finalTree.Tipo, Environment.NewLine);
            }
            else
            {
                finalTree.tree += string.Format("{0}{1}", finalTree.Label, Environment.NewLine);
            }

            textForm.Text += finalTree.tree;

            if (finalTree.Children != null)
            {
                for (int i = 0; i < finalTree.Children.Count; i++)
                {
                    if (finalTree.Children[i] != null)
                    {
                        PrintTree(indent, i == finalTree.Children.Count - 1, typed, textForm, finalTree.Children[i]);
                    }
                }

            }
        }

        private void SetupLexTable(DataGridView dtgv)
        {
            dtgv.ColumnCount = 5;
            dtgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dtgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtgv.ColumnHeadersDefaultCellStyle.Font = new Font(lexicDataGridView.Font, FontStyle.Bold);

            dtgv.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dtgv.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dtgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dtgv.GridColor = Color.Black;
            dtgv.RowHeadersVisible = false;

            dtgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dtgv.Columns[0].Name = "N°";
            dtgv.Columns[1].Name = "Token";
            dtgv.Columns[2].Name = "Description";
            dtgv.Columns[3].Name = "Line";
            dtgv.Columns[4].Name = "Column";

            dtgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dtgv.MultiSelect = false;
            dtgv.Dock = DockStyle.Fill;
        }

        private void SetupSymbolsTable(DataGridView dtgv)
        {
            dtgv.ColumnCount = 3;
            dtgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dtgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtgv.ColumnHeadersDefaultCellStyle.Font = new Font(symbolsDataGridView.Font, FontStyle.Bold);

            dtgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dtgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dtgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dtgv.GridColor = Color.Black;
            dtgv.RowHeadersVisible = false;

            dtgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dtgv.Columns[0].Name = "N°";
            dtgv.Columns[1].Name = "Symbol";
            dtgv.Columns[2].Name = "Type";

            dtgv.SelectionMode =  DataGridViewSelectionMode.FullRowSelect;
            dtgv.MultiSelect = false;
            dtgv.Dock = DockStyle.Fill;
            dtgv.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void PopulateLexTable(List<TokenItem> ls)
        {
            lexicDataGridView.Rows.Clear();
            int i = 1;
            foreach (TokenItem item in ls)
            {
                lexicDataGridView.Rows.Add(new string[]{ i++.ToString(), item.TokenName, item.TokenDesc, item.TokenLine.ToString(),item.TokenCol.ToString()});
            }
        }

        private void PopulateSymbolsTable(Dictionary<string, SymTableItem> symbols)
        {
            symbolsDataGridView.Rows.Clear();
            int i = 1;
            foreach (var symbol in symbols.Values)
            {
                symbolsDataGridView.Rows.Add(new string[] { i++.ToString(), symbol.Identifier, symbol.Type });
            }
        }
        private void PopulateLexErrorsTable(List<TokenItem> ls)
        {
            foreach (TokenItem item in ls)
            {
                lexicDataGridView.Rows.Add(new string[] { "*", item.TokenName, item.TokenDesc, item.TokenLine.ToString(), item.TokenCol.ToString() });
            }
            foreach (DataGridViewRow Myrow in lexicDataGridView.Rows)
            {
                if (Myrow.Cells[0].Value != null)
                {
                    if (Myrow.Cells[0].Value.ToString() == "*")//"))//Columns.Contains("SOLD"))//Columns.Contains("SOLD"))
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.Red;

                    }
                }
                
            }
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //revisamos si esta guardado el archivo
            SaveFile();
            if (!_IsAFileOpen)
            {
                MessageBox.Show("Guarda Primero el Archivo!");
                return;
            }
            //Aqui realizamos el analisis lexico si existe un archivo guardado
            MakeLexicalAnalisis();
           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabSintactic_Click(object sender, EventArgs e)
        {

        }

        private void lexicDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void richTextBoxSintatic_TextChanged(object sender, EventArgs e)
        {

        }

        private void numLines_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

/*lexicDataGridView.ColumnCount = 5;
            lexicDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            lexicDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            lexicDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(lexicDataGridView.Font, FontStyle.Bold);

            lexicDataGridView.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            lexicDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            lexicDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            lexicDataGridView.GridColor = Color.Black;
            lexicDataGridView.RowHeadersVisible = false;

            lexicDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            lexicDataGridView.Columns[0].Name = "N°";
            lexicDataGridView.Columns[1].Name = "Token";
            lexicDataGridView.Columns[2].Name = "Description";
            lexicDataGridView.Columns[3].Name = "Line";
            lexicDataGridView.Columns[4].Name = "Column";
            
            lexicDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            lexicDataGridView.MultiSelect = false;
            lexicDataGridView.Dock = DockStyle.Fill;*/
