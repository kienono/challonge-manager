namespace ChallongeManager
{
    partial class FormResultTableGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerEvent = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.tabControlResults = new System.Windows.Forms.TabControl();
            this.tabPageHTML = new System.Windows.Forms.TabPage();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.tabPagePreview = new System.Windows.Forms.TabPage();
            this.webBrowserPreview = new System.Windows.Forms.WebBrowser();
            this.backgroundWorkerChallongeRequest = new System.ComponentModel.BackgroundWorker();
            this.progressBarRequest = new System.Windows.Forms.ProgressBar();
            this.tabControlResults.SuspendLayout();
            this.tabPageHTML.SuspendLayout();
            this.tabPagePreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date de l\'événement:";
            // 
            // dateTimePickerEvent
            // 
            this.dateTimePickerEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerEvent.Location = new System.Drawing.Point(127, 7);
            this.dateTimePickerEvent.Name = "dateTimePickerEvent";
            this.dateTimePickerEvent.Size = new System.Drawing.Size(279, 20);
            this.dateTimePickerEvent.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tag (optionel):";
            // 
            // textBoxTag
            // 
            this.textBoxTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTag.Location = new System.Drawing.Point(94, 33);
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.Size = new System.Drawing.Size(312, 20);
            this.textBoxTag.TabIndex = 2;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.Location = new System.Drawing.Point(16, 59);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(390, 29);
            this.buttonGenerate.TabIndex = 3;
            this.buttonGenerate.Text = "Générer";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // tabControlResults
            // 
            this.tabControlResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlResults.Controls.Add(this.tabPageHTML);
            this.tabControlResults.Controls.Add(this.tabPagePreview);
            this.tabControlResults.Location = new System.Drawing.Point(16, 119);
            this.tabControlResults.Name = "tabControlResults";
            this.tabControlResults.SelectedIndex = 0;
            this.tabControlResults.Size = new System.Drawing.Size(392, 250);
            this.tabControlResults.TabIndex = 4;
            // 
            // tabPageHTML
            // 
            this.tabPageHTML.Controls.Add(this.textBoxCode);
            this.tabPageHTML.Location = new System.Drawing.Point(4, 22);
            this.tabPageHTML.Name = "tabPageHTML";
            this.tabPageHTML.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHTML.Size = new System.Drawing.Size(384, 224);
            this.tabPageHTML.TabIndex = 0;
            this.tabPageHTML.Text = "Code HTML";
            this.tabPageHTML.UseVisualStyleBackColor = true;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCode.Location = new System.Drawing.Point(3, 3);
            this.textBoxCode.Multiline = true;
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCode.Size = new System.Drawing.Size(378, 218);
            this.textBoxCode.TabIndex = 0;
            // 
            // tabPagePreview
            // 
            this.tabPagePreview.Controls.Add(this.webBrowserPreview);
            this.tabPagePreview.Location = new System.Drawing.Point(4, 22);
            this.tabPagePreview.Name = "tabPagePreview";
            this.tabPagePreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreview.Size = new System.Drawing.Size(395, 278);
            this.tabPagePreview.TabIndex = 1;
            this.tabPagePreview.Text = "Preview";
            this.tabPagePreview.UseVisualStyleBackColor = true;
            // 
            // webBrowserPreview
            // 
            this.webBrowserPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserPreview.Location = new System.Drawing.Point(3, 3);
            this.webBrowserPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPreview.Name = "webBrowserPreview";
            this.webBrowserPreview.Size = new System.Drawing.Size(389, 272);
            this.webBrowserPreview.TabIndex = 0;
            // 
            // backgroundWorkerChallongeRequest
            // 
            this.backgroundWorkerChallongeRequest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerChallongeRequest_DoWork);
            this.backgroundWorkerChallongeRequest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerChallongeRequest_RunWorkerCompleted);
            // 
            // progressBarRequest
            // 
            this.progressBarRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarRequest.Location = new System.Drawing.Point(16, 90);
            this.progressBarRequest.Name = "progressBarRequest";
            this.progressBarRequest.Size = new System.Drawing.Size(390, 23);
            this.progressBarRequest.TabIndex = 5;
            // 
            // FormResultTableGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 381);
            this.Controls.Add(this.progressBarRequest);
            this.Controls.Add(this.tabControlResults);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.textBoxTag);
            this.Controls.Add(this.dateTimePickerEvent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormResultTableGenerator";
            this.Text = "Génération de tableau de résultats";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormResultTableGenerator_FormClosing);
            this.tabControlResults.ResumeLayout(false);
            this.tabPageHTML.ResumeLayout(false);
            this.tabPageHTML.PerformLayout();
            this.tabPagePreview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEvent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTag;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.TabControl tabControlResults;
        private System.Windows.Forms.TabPage tabPageHTML;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.TabPage tabPagePreview;
        private System.Windows.Forms.WebBrowser webBrowserPreview;
        private System.ComponentModel.BackgroundWorker backgroundWorkerChallongeRequest;
        private System.Windows.Forms.ProgressBar progressBarRequest;
    }
}