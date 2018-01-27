namespace ChallongeManager.Forms
{
    partial class FormSettings
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageChallonge = new System.Windows.Forms.TabPage();
            this.textBoxGameList = new System.Windows.Forms.TextBox();
            this.textBoxForfeitTag = new System.Windows.Forms.TextBox();
            this.textBoxTournamentSearchTag = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAPIKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAPIKey = new System.Windows.Forms.Label();
            this.textBoxIDChallonge = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSeasonGame = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageChallonge.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageChallonge);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(393, 351);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageChallonge
            // 
            this.tabPageChallonge.Controls.Add(this.textBoxGameList);
            this.tabPageChallonge.Controls.Add(this.textBoxSeasonGame);
            this.tabPageChallonge.Controls.Add(this.textBoxForfeitTag);
            this.tabPageChallonge.Controls.Add(this.label5);
            this.tabPageChallonge.Controls.Add(this.textBoxTournamentSearchTag);
            this.tabPageChallonge.Controls.Add(this.label4);
            this.tabPageChallonge.Controls.Add(this.textBoxAPIKey);
            this.tabPageChallonge.Controls.Add(this.label3);
            this.tabPageChallonge.Controls.Add(this.label2);
            this.tabPageChallonge.Controls.Add(this.labelAPIKey);
            this.tabPageChallonge.Controls.Add(this.textBoxIDChallonge);
            this.tabPageChallonge.Controls.Add(this.label1);
            this.tabPageChallonge.Location = new System.Drawing.Point(4, 22);
            this.tabPageChallonge.Name = "tabPageChallonge";
            this.tabPageChallonge.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChallonge.Size = new System.Drawing.Size(385, 325);
            this.tabPageChallonge.TabIndex = 0;
            this.tabPageChallonge.Text = "Challonge";
            this.tabPageChallonge.UseVisualStyleBackColor = true;
            // 
            // textBoxGameList
            // 
            this.textBoxGameList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGameList.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ChallongeManager.Properties.Settings.Default, "Challonge_GameList", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxGameList.Location = new System.Drawing.Point(7, 166);
            this.textBoxGameList.Multiline = true;
            this.textBoxGameList.Name = "textBoxGameList";
            this.textBoxGameList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxGameList.Size = new System.Drawing.Size(369, 150);
            this.textBoxGameList.TabIndex = 2;
            this.textBoxGameList.Text = global::ChallongeManager.Properties.Settings.Default.Challonge_GameList;
            // 
            // textBoxForfeitTag
            // 
            this.textBoxForfeitTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxForfeitTag.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ChallongeManager.Properties.Settings.Default, "ForfeitTag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxForfeitTag.Location = new System.Drawing.Point(86, 92);
            this.textBoxForfeitTag.Name = "textBoxForfeitTag";
            this.textBoxForfeitTag.Size = new System.Drawing.Size(290, 20);
            this.textBoxForfeitTag.TabIndex = 1;
            this.textBoxForfeitTag.Text = global::ChallongeManager.Properties.Settings.Default.ForfeitTag;
            // 
            // textBoxTournamentSearchTag
            // 
            this.textBoxTournamentSearchTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTournamentSearchTag.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ChallongeManager.Properties.Settings.Default, "Challonge_SearchTag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxTournamentSearchTag.Location = new System.Drawing.Point(86, 65);
            this.textBoxTournamentSearchTag.Name = "textBoxTournamentSearchTag";
            this.textBoxTournamentSearchTag.Size = new System.Drawing.Size(290, 20);
            this.textBoxTournamentSearchTag.TabIndex = 1;
            this.textBoxTournamentSearchTag.Text = global::ChallongeManager.Properties.Settings.Default.Challonge_SearchTag;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tag forfait:";
            // 
            // textBoxAPIKey
            // 
            this.textBoxAPIKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAPIKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ChallongeManager.Properties.Settings.Default, "Challonge_APIkey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxAPIKey.Location = new System.Drawing.Point(86, 38);
            this.textBoxAPIKey.Name = "textBoxAPIKey";
            this.textBoxAPIKey.Size = new System.Drawing.Size(290, 20);
            this.textBoxAPIKey.TabIndex = 1;
            this.textBoxAPIKey.Text = global::ChallongeManager.Properties.Settings.Default.Challonge_APIkey;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tag tournoi:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Liste des jeux (1 jeu par ligne, alternatives de nom séparées par \'/\'):";
            // 
            // labelAPIKey
            // 
            this.labelAPIKey.AutoSize = true;
            this.labelAPIKey.Location = new System.Drawing.Point(8, 41);
            this.labelAPIKey.Name = "labelAPIKey";
            this.labelAPIKey.Size = new System.Drawing.Size(45, 13);
            this.labelAPIKey.TabIndex = 0;
            this.labelAPIKey.Text = "Clé API:";
            // 
            // textBoxIDChallonge
            // 
            this.textBoxIDChallonge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIDChallonge.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ChallongeManager.Properties.Settings.Default, "Challonge_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxIDChallonge.Location = new System.Drawing.Point(86, 11);
            this.textBoxIDChallonge.Name = "textBoxIDChallonge";
            this.textBoxIDChallonge.Size = new System.Drawing.Size(290, 20);
            this.textBoxIDChallonge.TabIndex = 1;
            this.textBoxIDChallonge.Text = global::ChallongeManager.Properties.Settings.Default.Challonge_ID;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Challonge:";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(185, 358);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(99, 29);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "&Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(290, 358);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(99, 29);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "&Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Season game:";
            // 
            // textBoxSeasonGame
            // 
            this.textBoxSeasonGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSeasonGame.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ChallongeManager.Properties.Settings.Default, "SeasonGame", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxSeasonGame.Location = new System.Drawing.Point(86, 118);
            this.textBoxSeasonGame.Name = "textBoxSeasonGame";
            this.textBoxSeasonGame.Size = new System.Drawing.Size(290, 20);
            this.textBoxSeasonGame.TabIndex = 1;
            this.textBoxSeasonGame.Text = global::ChallongeManager.Properties.Settings.Default.SeasonGame;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 392);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paramètres";
            this.tabControl1.ResumeLayout(false);
            this.tabPageChallonge.ResumeLayout(false);
            this.tabPageChallonge.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageChallonge;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxAPIKey;
        private System.Windows.Forms.Label labelAPIKey;
        private System.Windows.Forms.TextBox textBoxIDChallonge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxGameList;
        private System.Windows.Forms.TextBox textBoxTournamentSearchTag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxForfeitTag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSeasonGame;
        private System.Windows.Forms.Label label5;
    }
}