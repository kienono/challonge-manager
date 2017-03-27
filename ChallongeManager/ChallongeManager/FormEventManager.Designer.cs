namespace ChallongeManager
{
    partial class FormEventManager
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageEventInfo = new System.Windows.Forms.TabPage();
            this.groupBoxDataImport = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonGetTournamentData = new System.Windows.Forms.Button();
            this.textBoxSingleChallongeTournID = new System.Windows.Forms.TextBox();
            this.tabPageParticipants = new System.Windows.Forms.TabPage();
            this.tabPageEventVenue = new System.Windows.Forms.TabPage();
            this.tabPageWinnersBracket = new System.Windows.Forms.TabPage();
            this.tabPageLoosersBracket = new System.Windows.Forms.TabPage();
            this.tabControlMain.SuspendLayout();
            this.tabPageEventInfo.SuspendLayout();
            this.groupBoxDataImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageEventInfo);
            this.tabControlMain.Controls.Add(this.tabPageParticipants);
            this.tabControlMain.Controls.Add(this.tabPageEventVenue);
            this.tabControlMain.Controls.Add(this.tabPageWinnersBracket);
            this.tabControlMain.Controls.Add(this.tabPageLoosersBracket);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(558, 399);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageEventInfo
            // 
            this.tabPageEventInfo.Controls.Add(this.groupBoxDataImport);
            this.tabPageEventInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageEventInfo.Name = "tabPageEventInfo";
            this.tabPageEventInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEventInfo.Size = new System.Drawing.Size(550, 373);
            this.tabPageEventInfo.TabIndex = 0;
            this.tabPageEventInfo.Text = "Infos générales";
            this.tabPageEventInfo.UseVisualStyleBackColor = true;
            // 
            // groupBoxDataImport
            // 
            this.groupBoxDataImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDataImport.Controls.Add(this.label6);
            this.groupBoxDataImport.Controls.Add(this.buttonGetTournamentData);
            this.groupBoxDataImport.Controls.Add(this.textBoxSingleChallongeTournID);
            this.groupBoxDataImport.Location = new System.Drawing.Point(3, 6);
            this.groupBoxDataImport.Name = "groupBoxDataImport";
            this.groupBoxDataImport.Size = new System.Drawing.Size(539, 47);
            this.groupBoxDataImport.TabIndex = 6;
            this.groupBoxDataImport.TabStop = false;
            this.groupBoxDataImport.Text = "Importation de données";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "URL Challonge: http//challonge.com/";
            // 
            // buttonGetTournamentData
            // 
            this.buttonGetTournamentData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetTournamentData.Location = new System.Drawing.Point(400, 11);
            this.buttonGetTournamentData.Name = "buttonGetTournamentData";
            this.buttonGetTournamentData.Size = new System.Drawing.Size(127, 23);
            this.buttonGetTournamentData.TabIndex = 5;
            this.buttonGetTournamentData.Text = "Récupérer données ...";
            this.buttonGetTournamentData.UseVisualStyleBackColor = true;
            this.buttonGetTournamentData.Click += new System.EventHandler(this.buttonGetTournamentData_Click);
            // 
            // textBoxSingleChallongeTournID
            // 
            this.textBoxSingleChallongeTournID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSingleChallongeTournID.Location = new System.Drawing.Point(193, 12);
            this.textBoxSingleChallongeTournID.Name = "textBoxSingleChallongeTournID";
            this.textBoxSingleChallongeTournID.Size = new System.Drawing.Size(201, 20);
            this.textBoxSingleChallongeTournID.TabIndex = 4;
            this.textBoxSingleChallongeTournID.Text = "waiu16ax";
            // 
            // tabPageParticipants
            // 
            this.tabPageParticipants.Location = new System.Drawing.Point(4, 22);
            this.tabPageParticipants.Name = "tabPageParticipants";
            this.tabPageParticipants.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParticipants.Size = new System.Drawing.Size(550, 373);
            this.tabPageParticipants.TabIndex = 1;
            this.tabPageParticipants.Text = "Participants";
            this.tabPageParticipants.UseVisualStyleBackColor = true;
            // 
            // tabPageEventVenue
            // 
            this.tabPageEventVenue.Location = new System.Drawing.Point(4, 22);
            this.tabPageEventVenue.Name = "tabPageEventVenue";
            this.tabPageEventVenue.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEventVenue.Size = new System.Drawing.Size(550, 373);
            this.tabPageEventVenue.TabIndex = 2;
            this.tabPageEventVenue.Text = "Lieu";
            this.tabPageEventVenue.UseVisualStyleBackColor = true;
            // 
            // tabPageWinnersBracket
            // 
            this.tabPageWinnersBracket.AutoScroll = true;
            this.tabPageWinnersBracket.Location = new System.Drawing.Point(4, 22);
            this.tabPageWinnersBracket.Name = "tabPageWinnersBracket";
            this.tabPageWinnersBracket.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWinnersBracket.Size = new System.Drawing.Size(550, 373);
            this.tabPageWinnersBracket.TabIndex = 3;
            this.tabPageWinnersBracket.Text = "Arbre Winner";
            this.tabPageWinnersBracket.UseVisualStyleBackColor = true;
            // 
            // tabPageLoosersBracket
            // 
            this.tabPageLoosersBracket.AutoScroll = true;
            this.tabPageLoosersBracket.Location = new System.Drawing.Point(4, 22);
            this.tabPageLoosersBracket.Name = "tabPageLoosersBracket";
            this.tabPageLoosersBracket.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLoosersBracket.Size = new System.Drawing.Size(550, 373);
            this.tabPageLoosersBracket.TabIndex = 4;
            this.tabPageLoosersBracket.Text = "ArbreLoosers";
            this.tabPageLoosersBracket.UseVisualStyleBackColor = true;
            // 
            // FormEventManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 399);
            this.Controls.Add(this.tabControlMain);
            this.Name = "FormEventManager";
            this.Text = "Gestion d\'évènement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEventManager_FormClosing);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageEventInfo.ResumeLayout(false);
            this.groupBoxDataImport.ResumeLayout(false);
            this.groupBoxDataImport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageEventInfo;
        private System.Windows.Forms.TabPage tabPageParticipants;
        private System.Windows.Forms.TabPage tabPageEventVenue;
        private System.Windows.Forms.TabPage tabPageWinnersBracket;
        private System.Windows.Forms.TabPage tabPageLoosersBracket;
        private System.Windows.Forms.GroupBox groupBoxDataImport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonGetTournamentData;
        private System.Windows.Forms.TextBox textBoxSingleChallongeTournID;
    }
}