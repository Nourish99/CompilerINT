namespace CompilerINT
{
    partial class CompilerLayout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFileContent = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.errorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.Label();
            this.numLines = new System.Windows.Forms.RichTextBox();
            this.tabResults = new System.Windows.Forms.TabControl();
            this.tabLexic = new System.Windows.Forms.TabPage();
            this.lexicDataGridView = new System.Windows.Forms.DataGridView();
            this.tabSintactic = new System.Windows.Forms.TabPage();
            this.richTextBoxSintatic = new System.Windows.Forms.RichTextBox();
            this.tabSemantic = new System.Windows.Forms.TabPage();
            this.tabICode = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.symbolsDataGridView = new System.Windows.Forms.DataGridView();
            this.richTextBoxSemanthic = new System.Windows.Forms.RichTextBox();
            this.intCode = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.tabResults.SuspendLayout();
            this.tabLexic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lexicDataGridView)).BeginInit();
            this.tabSintactic.SuspendLayout();
            this.tabSemantic.SuspendLayout();
            this.tabICode.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.symbolsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.editToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.compileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1413, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.newFileToolStripMenuItem});
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.archivoToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.newFileToolStripMenuItem.Text = "New File";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.compileToolStripMenuItem.Text = "Compile";
            this.compileToolStripMenuItem.Click += new System.EventHandler(this.compileToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // txtFileContent
            // 
            this.txtFileContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(32)))), ((int)(((byte)(33)))));
            this.txtFileContent.ForeColor = System.Drawing.SystemColors.Info;
            this.txtFileContent.Location = new System.Drawing.Point(56, 113);
            this.txtFileContent.Name = "txtFileContent";
            this.txtFileContent.Size = new System.Drawing.Size(753, 520);
            this.txtFileContent.TabIndex = 1;
            this.txtFileContent.Text = "";
            this.txtFileContent.SelectionChanged += new System.EventHandler(this.txtFileContent_SelectionChanged);
            this.txtFileContent.VScroll += new System.EventHandler(this.txtFileContent_VScroll);
            this.txtFileContent.FontChanged += new System.EventHandler(this.txtFileContent_FontChanged);
            this.txtFileContent.TextChanged += new System.EventHandler(this.txtFileContent_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(75)))), ((int)(((byte)(84)))));
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.menuStrip3);
            this.panel2.Location = new System.Drawing.Point(11, 659);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1389, 191);
            this.panel2.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(35)))));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.richTextBox1.Location = new System.Drawing.Point(3, 31);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1383, 157);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "zxz<xxzx";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // menuStrip3
            // 
            this.menuStrip3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorsToolStripMenuItem,
            this.resultsToolStripMenuItem});
            this.menuStrip3.Location = new System.Drawing.Point(0, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip3.Size = new System.Drawing.Size(1389, 30);
            this.menuStrip3.TabIndex = 0;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // errorsToolStripMenuItem
            // 
            this.errorsToolStripMenuItem.Name = "errorsToolStripMenuItem";
            this.errorsToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.errorsToolStripMenuItem.Text = "Errors";
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.resultsToolStripMenuItem.Text = "Results";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(11, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "CODE";
            // 
            // FileName
            // 
            this.FileName.AutoSize = true;
            this.FileName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FileName.Location = new System.Drawing.Point(11, 883);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(122, 32);
            this.FileName.TabIndex = 5;
            this.FileName.Text = "FileName:";
            // 
            // txtFileName
            // 
            this.txtFileName.AutoSize = true;
            this.txtFileName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtFileName.Location = new System.Drawing.Point(131, 883);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(0, 32);
            this.txtFileName.TabIndex = 6;
            this.txtFileName.Click += new System.EventHandler(this.txtFileName_Click);
            // 
            // numLines
            // 
            this.numLines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.numLines.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.numLines.Location = new System.Drawing.Point(21, 113);
            this.numLines.Name = "numLines";
            this.numLines.Size = new System.Drawing.Size(41, 520);
            this.numLines.TabIndex = 7;
            this.numLines.Text = "";
            this.numLines.TextChanged += new System.EventHandler(this.numLines_TextChanged);
            this.numLines.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numLines_MouseDown);
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.tabLexic);
            this.tabResults.Controls.Add(this.tabSintactic);
            this.tabResults.Controls.Add(this.tabSemantic);
            this.tabResults.Controls.Add(this.tabICode);
            this.tabResults.Controls.Add(this.tabPage1);
            this.tabResults.Location = new System.Drawing.Point(832, 113);
            this.tabResults.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabResults.Name = "tabResults";
            this.tabResults.SelectedIndex = 0;
            this.tabResults.Size = new System.Drawing.Size(568, 521);
            this.tabResults.TabIndex = 8;
            // 
            // tabLexic
            // 
            this.tabLexic.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabLexic.Controls.Add(this.lexicDataGridView);
            this.tabLexic.ForeColor = System.Drawing.Color.Black;
            this.tabLexic.Location = new System.Drawing.Point(4, 29);
            this.tabLexic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabLexic.Name = "tabLexic";
            this.tabLexic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabLexic.Size = new System.Drawing.Size(560, 488);
            this.tabLexic.TabIndex = 0;
            this.tabLexic.Text = "Lexic";
            // 
            // lexicDataGridView
            // 
            this.lexicDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lexicDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lexicDataGridView.Location = new System.Drawing.Point(3, 4);
            this.lexicDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lexicDataGridView.Name = "lexicDataGridView";
            this.lexicDataGridView.RowHeadersWidth = 51;
            this.lexicDataGridView.RowTemplate.Height = 25;
            this.lexicDataGridView.Size = new System.Drawing.Size(554, 480);
            this.lexicDataGridView.TabIndex = 0;
            this.lexicDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lexicDataGridView_CellContentClick);
            // 
            // tabSintactic
            // 
            this.tabSintactic.BackColor = System.Drawing.Color.DimGray;
            this.tabSintactic.Controls.Add(this.richTextBoxSintatic);
            this.tabSintactic.Location = new System.Drawing.Point(4, 29);
            this.tabSintactic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabSintactic.Name = "tabSintactic";
            this.tabSintactic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabSintactic.Size = new System.Drawing.Size(560, 488);
            this.tabSintactic.TabIndex = 1;
            this.tabSintactic.Text = "Sintactic";
            this.tabSintactic.Click += new System.EventHandler(this.tabSintactic_Click);
            // 
            // richTextBoxSintatic
            // 
            this.richTextBoxSintatic.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxSintatic.Name = "richTextBoxSintatic";
            this.richTextBoxSintatic.Size = new System.Drawing.Size(560, 488);
            this.richTextBoxSintatic.TabIndex = 0;
            this.richTextBoxSintatic.Text = "";
            this.richTextBoxSintatic.TextChanged += new System.EventHandler(this.richTextBoxSintatic_TextChanged);
            // 
            // tabSemantic
            // 
            this.tabSemantic.Controls.Add(this.richTextBoxSemanthic);
            this.tabSemantic.Location = new System.Drawing.Point(4, 29);
            this.tabSemantic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabSemantic.Name = "tabSemantic";
            this.tabSemantic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabSemantic.Size = new System.Drawing.Size(560, 488);
            this.tabSemantic.TabIndex = 2;
            this.tabSemantic.Text = "Semantic";
            this.tabSemantic.UseVisualStyleBackColor = true;
            // 
            // tabICode
            // 
            this.tabICode.Controls.Add(this.intCode);
            this.tabICode.Location = new System.Drawing.Point(4, 29);
            this.tabICode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabICode.Name = "tabICode";
            this.tabICode.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabICode.Size = new System.Drawing.Size(560, 488);
            this.tabICode.TabIndex = 3;
            this.tabICode.Text = "Intermediate Code";
            this.tabICode.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.symbolsDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(560, 488);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Symbol Table";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // symbolsDataGridView
            // 
            this.symbolsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.symbolsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.symbolsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.symbolsDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.symbolsDataGridView.Name = "symbolsDataGridView";
            this.symbolsDataGridView.RowHeadersWidth = 51;
            this.symbolsDataGridView.RowTemplate.Height = 25;
            this.symbolsDataGridView.Size = new System.Drawing.Size(560, 488);
            this.symbolsDataGridView.TabIndex = 1;
            // 
            // richTextBoxSemanthic
            // 
            this.richTextBoxSemanthic.Location = new System.Drawing.Point(-1, 1);
            this.richTextBoxSemanthic.Name = "richTextBoxSemanthic";
            this.richTextBoxSemanthic.Size = new System.Drawing.Size(560, 484);
            this.richTextBoxSemanthic.TabIndex = 1;
            this.richTextBoxSemanthic.Text = "";
            // 
            // intCode
            // 
            this.intCode.Location = new System.Drawing.Point(0, 1);
            this.intCode.Name = "intCode";
            this.intCode.Size = new System.Drawing.Size(560, 484);
            this.intCode.TabIndex = 2;
            this.intCode.Tag = "intCode";
            this.intCode.Text = "";
            // 
            // CompilerLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(1413, 941);
            this.Controls.Add(this.tabResults);
            this.Controls.Add(this.numLines);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtFileContent);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(223)))));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CompilerLayout";
            this.Text = "CompilerLayout";
            this.Load += new System.EventHandler(this.CompilerLayout_Load);
            this.Resize += new System.EventHandler(this.CompilerLayout_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.tabResults.ResumeLayout(false);
            this.tabLexic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lexicDataGridView)).EndInit();
            this.tabSintactic.ResumeLayout(false);
            this.tabSemantic.ResumeLayout(false);
            this.tabICode.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.symbolsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.RichTextBox txtFileContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem errorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FileName;
        private System.Windows.Forms.Label txtFileName;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.RichTextBox numLines;
        private System.Windows.Forms.TabControl tabResults;
        private System.Windows.Forms.TabPage tabLexic;
        private System.Windows.Forms.DataGridView lexicDataGridView;
        private System.Windows.Forms.TabPage tabSintactic;
        private System.Windows.Forms.TabPage tabSemantic;
        private System.Windows.Forms.TabPage tabICode;
        private System.Windows.Forms.RichTextBox richTextBoxSintatic;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView symbolsDataGridView;
        private System.Windows.Forms.RichTextBox richTextBoxSemanthic;
        private System.Windows.Forms.RichTextBox intCode;
    }
}