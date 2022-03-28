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
            this.tabSintactic = new System.Windows.Forms.TabPage();
            this.tabSemantic = new System.Windows.Forms.TabPage();
            this.tabICode = new System.Windows.Forms.TabPage();
            this.lexicDataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.tabResults.SuspendLayout();
            this.tabLexic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lexicDataGridView)).BeginInit();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1236, 24);
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
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.archivoToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.newFileToolStripMenuItem.Text = "New File";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.compileToolStripMenuItem.Text = "Compile";
            this.compileToolStripMenuItem.Click += new System.EventHandler(this.compileToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // txtFileContent
            // 
            this.txtFileContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(32)))), ((int)(((byte)(33)))));
            this.txtFileContent.ForeColor = System.Drawing.SystemColors.Info;
            this.txtFileContent.Location = new System.Drawing.Point(48, 85);
            this.txtFileContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFileContent.Name = "txtFileContent";
            this.txtFileContent.Size = new System.Drawing.Size(660, 391);
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
            this.panel2.Location = new System.Drawing.Point(10, 494);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1215, 143);
            this.panel2.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(35)))));
            this.richTextBox1.Location = new System.Drawing.Point(3, 23);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1211, 119);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
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
            this.menuStrip3.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip3.Size = new System.Drawing.Size(1215, 24);
            this.menuStrip3.TabIndex = 0;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // errorsToolStripMenuItem
            // 
            this.errorsToolStripMenuItem.Name = "errorsToolStripMenuItem";
            this.errorsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.errorsToolStripMenuItem.Text = "Errors";
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.resultsToolStripMenuItem.Text = "Results";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "CODE";
            // 
            // FileName
            // 
            this.FileName.AutoSize = true;
            this.FileName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FileName.Location = new System.Drawing.Point(10, 662);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(99, 25);
            this.FileName.TabIndex = 5;
            this.FileName.Text = "FileName:";
            // 
            // txtFileName
            // 
            this.txtFileName.AutoSize = true;
            this.txtFileName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtFileName.Location = new System.Drawing.Point(115, 662);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(0, 25);
            this.txtFileName.TabIndex = 6;
            this.txtFileName.Click += new System.EventHandler(this.txtFileName_Click);
            // 
            // numLines
            // 
            this.numLines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.numLines.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.numLines.Location = new System.Drawing.Point(18, 85);
            this.numLines.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numLines.Name = "numLines";
            this.numLines.Size = new System.Drawing.Size(29, 391);
            this.numLines.TabIndex = 7;
            this.numLines.Text = "";
            this.numLines.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numLines_MouseDown);
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.tabLexic);
            this.tabResults.Controls.Add(this.tabSintactic);
            this.tabResults.Controls.Add(this.tabSemantic);
            this.tabResults.Controls.Add(this.tabICode);
            this.tabResults.Location = new System.Drawing.Point(727, 85);
            this.tabResults.Name = "tabResults";
            this.tabResults.SelectedIndex = 0;
            this.tabResults.Size = new System.Drawing.Size(497, 391);
            this.tabResults.TabIndex = 8;
            // 
            // tabLexic
            // 
            this.tabLexic.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabLexic.Controls.Add(this.lexicDataGridView);
            this.tabLexic.ForeColor = System.Drawing.Color.Black;
            this.tabLexic.Location = new System.Drawing.Point(4, 24);
            this.tabLexic.Name = "tabLexic";
            this.tabLexic.Padding = new System.Windows.Forms.Padding(3);
            this.tabLexic.Size = new System.Drawing.Size(489, 363);
            this.tabLexic.TabIndex = 0;
            this.tabLexic.Text = "Lexic";
            // 
            // tabSintactic
            // 
            this.tabSintactic.BackColor = System.Drawing.Color.DimGray;
            this.tabSintactic.Location = new System.Drawing.Point(4, 24);
            this.tabSintactic.Name = "tabSintactic";
            this.tabSintactic.Padding = new System.Windows.Forms.Padding(3);
            this.tabSintactic.Size = new System.Drawing.Size(489, 363);
            this.tabSintactic.TabIndex = 1;
            this.tabSintactic.Text = "Sintactic";
            // 
            // tabSemantic
            // 
            this.tabSemantic.Location = new System.Drawing.Point(4, 24);
            this.tabSemantic.Name = "tabSemantic";
            this.tabSemantic.Padding = new System.Windows.Forms.Padding(3);
            this.tabSemantic.Size = new System.Drawing.Size(482, 363);
            this.tabSemantic.TabIndex = 2;
            this.tabSemantic.Text = "Semantic";
            this.tabSemantic.UseVisualStyleBackColor = true;
            // 
            // tabICode
            // 
            this.tabICode.Location = new System.Drawing.Point(4, 24);
            this.tabICode.Name = "tabICode";
            this.tabICode.Padding = new System.Windows.Forms.Padding(3);
            this.tabICode.Size = new System.Drawing.Size(489, 363);
            this.tabICode.TabIndex = 3;
            this.tabICode.Text = "Intermediate Code";
            this.tabICode.UseVisualStyleBackColor = true;
            // 
            // lexicDataGridView
            // 
            this.lexicDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lexicDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lexicDataGridView.Location = new System.Drawing.Point(3, 3);
            this.lexicDataGridView.Name = "lexicDataGridView";
            this.lexicDataGridView.RowTemplate.Height = 25;
            this.lexicDataGridView.Size = new System.Drawing.Size(483, 357);
            this.lexicDataGridView.TabIndex = 0;
            // 
            // CompilerLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(1236, 706);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
    }
}