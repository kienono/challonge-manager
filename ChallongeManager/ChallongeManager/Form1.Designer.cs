namespace ChallongeManager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxDataRetrieval = new System.Windows.Forms.GroupBox();
            this.progressBarDataRequest = new System.Windows.Forms.ProgressBar();
            this.buttonDataRequest = new System.Windows.Forms.Button();
            this.dateTimePickerRequestPeriodEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerRequestPeriodStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorkerChallongeRequest = new System.ComponentModel.BackgroundWorker();
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.buttonUpdateTable = new System.Windows.Forms.Button();
            this.textBoxTournamentDetails = new System.Windows.Forms.TextBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonExtractToCSV = new System.Windows.Forms.Button();
            this.listViewPoints = new System.Windows.Forms.ListView();
            this.checkedListBoxTournois = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialogCSV = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultTableGenerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageRankingManager = new System.Windows.Forms.TabPage();
            this.groupBoxDataRetrieval.SuspendLayout();
            this.groupBoxResults.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageRankingManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Période de récupération";
            // 
            // groupBoxDataRetrieval
            // 
            this.groupBoxDataRetrieval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDataRetrieval.Controls.Add(this.progressBarDataRequest);
            this.groupBoxDataRetrieval.Controls.Add(this.buttonDataRequest);
            this.groupBoxDataRetrieval.Controls.Add(this.dateTimePickerRequestPeriodEnd);
            this.groupBoxDataRetrieval.Controls.Add(this.label3);
            this.groupBoxDataRetrieval.Controls.Add(this.dateTimePickerRequestPeriodStart);
            this.groupBoxDataRetrieval.Controls.Add(this.label2);
            this.groupBoxDataRetrieval.Controls.Add(this.label1);
            this.groupBoxDataRetrieval.Location = new System.Drawing.Point(0, 3);
            this.groupBoxDataRetrieval.Name = "groupBoxDataRetrieval";
            this.groupBoxDataRetrieval.Size = new System.Drawing.Size(736, 103);
            this.groupBoxDataRetrieval.TabIndex = 1;
            this.groupBoxDataRetrieval.TabStop = false;
            this.groupBoxDataRetrieval.Text = "Récupération de données sur Challonge.com";
            // 
            // progressBarDataRequest
            // 
            this.progressBarDataRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDataRequest.Location = new System.Drawing.Point(11, 72);
            this.progressBarDataRequest.Name = "progressBarDataRequest";
            this.progressBarDataRequest.Size = new System.Drawing.Size(711, 22);
            this.progressBarDataRequest.TabIndex = 3;
            // 
            // buttonDataRequest
            // 
            this.buttonDataRequest.Location = new System.Drawing.Point(377, 39);
            this.buttonDataRequest.Name = "buttonDataRequest";
            this.buttonDataRequest.Size = new System.Drawing.Size(97, 24);
            this.buttonDataRequest.TabIndex = 2;
            this.buttonDataRequest.Text = "Go!";
            this.buttonDataRequest.UseVisualStyleBackColor = true;
            this.buttonDataRequest.Click += new System.EventHandler(this.buttonDataRequest_Click);
            // 
            // dateTimePickerRequestPeriodEnd
            // 
            this.dateTimePickerRequestPeriodEnd.Location = new System.Drawing.Point(238, 42);
            this.dateTimePickerRequestPeriodEnd.Name = "dateTimePickerRequestPeriodEnd";
            this.dateTimePickerRequestPeriodEnd.Size = new System.Drawing.Size(133, 20);
            this.dateTimePickerRequestPeriodEnd.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fin:";
            // 
            // dateTimePickerRequestPeriodStart
            // 
            this.dateTimePickerRequestPeriodStart.Location = new System.Drawing.Point(65, 42);
            this.dateTimePickerRequestPeriodStart.Name = "dateTimePickerRequestPeriodStart";
            this.dateTimePickerRequestPeriodStart.Size = new System.Drawing.Size(133, 20);
            this.dateTimePickerRequestPeriodStart.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Début:";
            // 
            // backgroundWorkerChallongeRequest
            // 
            this.backgroundWorkerChallongeRequest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerChallongeRequest_DoWork);
            this.backgroundWorkerChallongeRequest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerChallongeRequest_RunWorkerCompleted);
            // 
            // groupBoxResults
            // 
            this.groupBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResults.Controls.Add(this.buttonUpdateTable);
            this.groupBoxResults.Controls.Add(this.textBoxTournamentDetails);
            this.groupBoxResults.Controls.Add(this.buttonCopy);
            this.groupBoxResults.Controls.Add(this.buttonExtractToCSV);
            this.groupBoxResults.Controls.Add(this.listViewPoints);
            this.groupBoxResults.Controls.Add(this.checkedListBoxTournois);
            this.groupBoxResults.Controls.Add(this.label5);
            this.groupBoxResults.Controls.Add(this.label4);
            this.groupBoxResults.Location = new System.Drawing.Point(0, 112);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(748, 408);
            this.groupBoxResults.TabIndex = 2;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Résultats";
            // 
            // buttonUpdateTable
            // 
            this.buttonUpdateTable.Location = new System.Drawing.Point(114, 173);
            this.buttonUpdateTable.Name = "buttonUpdateTable";
            this.buttonUpdateTable.Size = new System.Drawing.Size(75, 25);
            this.buttonUpdateTable.TabIndex = 6;
            this.buttonUpdateTable.Text = "Rafraichir";
            this.buttonUpdateTable.UseVisualStyleBackColor = true;
            this.buttonUpdateTable.Click += new System.EventHandler(this.buttonUpdateTable_Click);
            // 
            // textBoxTournamentDetails
            // 
            this.textBoxTournamentDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTournamentDetails.Location = new System.Drawing.Point(374, 41);
            this.textBoxTournamentDetails.Multiline = true;
            this.textBoxTournamentDetails.Name = "textBoxTournamentDetails";
            this.textBoxTournamentDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTournamentDetails.Size = new System.Drawing.Size(360, 125);
            this.textBoxTournamentDetails.TabIndex = 5;
            this.textBoxTournamentDetails.WordWrap = false;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCopy.Location = new System.Drawing.Point(150, 372);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(181, 25);
            this.buttonCopy.TabIndex = 4;
            this.buttonCopy.Text = "Copier dans le presse papier";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonExtractToCSV
            // 
            this.buttonExtractToCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExtractToCSV.Location = new System.Drawing.Point(12, 372);
            this.buttonExtractToCSV.Name = "buttonExtractToCSV";
            this.buttonExtractToCSV.Size = new System.Drawing.Size(132, 25);
            this.buttonExtractToCSV.TabIndex = 4;
            this.buttonExtractToCSV.Text = "Exporter vers CSV";
            this.buttonExtractToCSV.UseVisualStyleBackColor = true;
            this.buttonExtractToCSV.Click += new System.EventHandler(this.buttonExtractToCSV_Click);
            // 
            // listViewPoints
            // 
            this.listViewPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPoints.GridLines = true;
            this.listViewPoints.Location = new System.Drawing.Point(11, 209);
            this.listViewPoints.Name = "listViewPoints";
            this.listViewPoints.Size = new System.Drawing.Size(723, 152);
            this.listViewPoints.TabIndex = 3;
            this.listViewPoints.UseCompatibleStateImageBehavior = false;
            this.listViewPoints.View = System.Windows.Forms.View.Details;
            this.listViewPoints.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewPoints_ColumnClick);
            // 
            // checkedListBoxTournois
            // 
            this.checkedListBoxTournois.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxTournois.FormattingEnabled = true;
            this.checkedListBoxTournois.Location = new System.Drawing.Point(11, 41);
            this.checkedListBoxTournois.Name = "checkedListBoxTournois";
            this.checkedListBoxTournois.Size = new System.Drawing.Size(357, 124);
            this.checkedListBoxTournois.TabIndex = 2;
            this.checkedListBoxTournois.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxTournois_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tableau de points:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Liste des tournois:";
            // 
            // saveFileDialogCSV
            // 
            this.saveFileDialogCSV.Filter = "Fichier CSV|*.csv";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.affichageToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "&Fichier";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(108, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.quitterToolStripMenuItem.Text = "&Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventManagerToolStripMenuItem,
            this.resultTableGenerationToolStripMenuItem});
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            this.affichageToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.affichageToolStripMenuItem.Text = "&Affichage";
            // 
            // eventManagerToolStripMenuItem
            // 
            this.eventManagerToolStripMenuItem.Name = "eventManagerToolStripMenuItem";
            this.eventManagerToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.eventManagerToolStripMenuItem.Text = "Gestion d\'&évènement";
            this.eventManagerToolStripMenuItem.Visible = false;
            this.eventManagerToolStripMenuItem.Click += new System.EventHandler(this.eventManagerToolStripMenuItem_Click);
            // 
            // resultTableGenerationToolStripMenuItem
            // 
            this.resultTableGenerationToolStripMenuItem.Name = "resultTableGenerationToolStripMenuItem";
            this.resultTableGenerationToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.resultTableGenerationToolStripMenuItem.Text = "&Générer un tableau de résultats HTML";
            this.resultTableGenerationToolStripMenuItem.Click += new System.EventHandler(this.resultTableGenerationToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parametresToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // parametresToolStripMenuItem
            // 
            this.parametresToolStripMenuItem.Name = "parametresToolStripMenuItem";
            this.parametresToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.parametresToolStripMenuItem.Text = "&Paramètres";
            this.parametresToolStripMenuItem.Click += new System.EventHandler(this.parametresToolStripMenuItem_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageRankingManager);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 24);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(752, 542);
            this.tabControlMain.TabIndex = 4;
            // 
            // tabPageRankingManager
            // 
            this.tabPageRankingManager.Controls.Add(this.groupBoxDataRetrieval);
            this.tabPageRankingManager.Controls.Add(this.groupBoxResults);
            this.tabPageRankingManager.Location = new System.Drawing.Point(4, 22);
            this.tabPageRankingManager.Name = "tabPageRankingManager";
            this.tabPageRankingManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRankingManager.Size = new System.Drawing.Size(744, 516);
            this.tabPageRankingManager.TabIndex = 0;
            this.tabPageRankingManager.Text = "Gestion Score et Ranking";
            this.tabPageRankingManager.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 566);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Challonge Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxDataRetrieval.ResumeLayout(false);
            this.groupBoxDataRetrieval.PerformLayout();
            this.groupBoxResults.ResumeLayout(false);
            this.groupBoxResults.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageRankingManager.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxDataRetrieval;
        private System.Windows.Forms.ProgressBar progressBarDataRequest;
        private System.Windows.Forms.Button buttonDataRequest;
        private System.Windows.Forms.DateTimePicker dateTimePickerRequestPeriodEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerRequestPeriodStart;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerChallongeRequest;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkedListBoxTournois;
        private System.Windows.Forms.ListView listViewPoints;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonExtractToCSV;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCSV;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametresToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxTournamentDetails;
        private System.Windows.Forms.Button buttonUpdateTable;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageRankingManager;
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem resultTableGenerationToolStripMenuItem;
    }
}

