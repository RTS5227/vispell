namespace VietnameseSpellChecker
{
    partial class FormMain
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.browserResult = new System.Windows.Forms.WebBrowser();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.radSingle = new System.Windows.Forms.RadioButton();
            this.radDouble = new System.Windows.Forms.RadioButton();
            this.radTriple = new System.Windows.Forms.RadioButton();
            this.btnReloadApp = new System.Windows.Forms.Button();
            this.browserSource = new System.Windows.Forms.WebBrowser();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(4, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.browserSource);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.browserResult);
            this.splitContainer.Size = new System.Drawing.Size(789, 402);
            this.splitContainer.SplitterDistance = 322;
            this.splitContainer.TabIndex = 2;
            // 
            // browserResult
            // 
            this.browserResult.AllowWebBrowserDrop = false;
            this.browserResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserResult.Location = new System.Drawing.Point(0, 0);
            this.browserResult.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserResult.Name = "browserResult";
            this.browserResult.Size = new System.Drawing.Size(463, 402);
            this.browserResult.TabIndex = 1;
            this.browserResult.Url = new System.Uri("", System.UriKind.Relative);
            this.browserResult.WebBrowserShortcutsEnabled = false;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Location = new System.Drawing.Point(718, 519);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "Bắt đầu";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Đưa text gốc vào ô bên này";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Text sau khi check ở ô bên này";
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole.Location = new System.Drawing.Point(4, 432);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(789, 81);
            this.txtConsole.TabIndex = 6;
            // 
            // radSingle
            // 
            this.radSingle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radSingle.AutoSize = true;
            this.radSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radSingle.Location = new System.Drawing.Point(456, 522);
            this.radSingle.Name = "radSingle";
            this.radSingle.Size = new System.Drawing.Size(79, 17);
            this.radSingle.TabIndex = 7;
            this.radSingle.Text = "SingleWord";
            this.radSingle.UseVisualStyleBackColor = true;
            // 
            // radDouble
            // 
            this.radDouble.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radDouble.AutoSize = true;
            this.radDouble.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radDouble.Location = new System.Drawing.Point(546, 521);
            this.radDouble.Name = "radDouble";
            this.radDouble.Size = new System.Drawing.Size(84, 17);
            this.radDouble.TabIndex = 8;
            this.radDouble.Text = "DoubleWord";
            this.radDouble.UseVisualStyleBackColor = true;
            // 
            // radTriple
            // 
            this.radTriple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radTriple.AutoSize = true;
            this.radTriple.Checked = true;
            this.radTriple.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radTriple.Location = new System.Drawing.Point(636, 522);
            this.radTriple.Name = "radTriple";
            this.radTriple.Size = new System.Drawing.Size(76, 17);
            this.radTriple.TabIndex = 9;
            this.radTriple.TabStop = true;
            this.radTriple.Text = "TripleWord";
            this.radTriple.UseVisualStyleBackColor = true;
            // 
            // btnReloadApp
            // 
            this.btnReloadApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadApp.Location = new System.Drawing.Point(162, 519);
            this.btnReloadApp.Name = "btnReloadApp";
            this.btnReloadApp.Size = new System.Drawing.Size(98, 23);
            this.btnReloadApp.TabIndex = 10;
            this.btnReloadApp.Text = "Nạp lại cấu hình";
            this.btnReloadApp.UseVisualStyleBackColor = true;
            this.btnReloadApp.Click += new System.EventHandler(this.btnReloadApp_Click);
            // 
            // browserSource
            // 
            this.browserSource.AllowWebBrowserDrop = false;
            this.browserSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserSource.IsWebBrowserContextMenuEnabled = false;
            this.browserSource.Location = new System.Drawing.Point(0, 0);
            this.browserSource.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserSource.Name = "browserSource";
            this.browserSource.ScrollBarsEnabled = false;
            this.browserSource.Size = new System.Drawing.Size(322, 402);
            this.browserSource.TabIndex = 0;
            this.browserSource.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // FormMain
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 545);
            this.Controls.Add(this.btnReloadApp);
            this.Controls.Add(this.radTriple);
            this.Controls.Add(this.radDouble);
            this.Controls.Add(this.radSingle);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.splitContainer);
            this.Name = "FormMain";
            this.Text = "GURUCORE Smart Vietnamese Spell Checker - made for pandaxinh@";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.RadioButton radSingle;
        private System.Windows.Forms.RadioButton radDouble;
        private System.Windows.Forms.RadioButton radTriple;
        private System.Windows.Forms.WebBrowser browserResult;
        private System.Windows.Forms.Button btnReloadApp;
        private System.Windows.Forms.WebBrowser browserSource;
    }
}

