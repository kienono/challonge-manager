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
            this.buttonExtractToCSV = new System.Windows.Forms.Button();
            this.listViewPoints = new System.Windows.Forms.ListView();
            this.checkedListBoxTournois = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialogCSV = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.groupBoxDataRetrieval.SuspendLayout();
            this.groupBoxResults.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 12);
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
            this.groupBoxDataRetrieval.Location = new System.Drawing.Point(12, 27);
            this.groupBoxDataRetrieval.Name = "groupBoxDataRetrieval";
            this.groupBoxDataRetrieval.Size = new System.Drawing.Size(711, 95);
            this.groupBoxDataRetrieval.TabIndex = 1;
            this.groupBoxDataRetrieval.TabStop = false;
            this.groupBoxDataRetrieval.Text = "Récupération de données sur Challonge.com";
            // 
            // progressBarDataRequest
            // 
            this.progressBarDataRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDataRequest.Location = new System.Drawing.Point(11, 66);
            this.progressBarDataRequest.Name = "progressBarDataRequest";
            this.progressBarDataRequest.Size = new System.Drawing.Size(686, 20);
            this.progressBarDataRequest.TabIndex = 3;
            // 
            // buttonDataRequest
            // 
            this.buttonDataRequest.Location = new System.Drawing.Point(377, 36);
            this.buttonDataRequest.Name = "buttonDataRequest";
            this.buttonDataRequest.Size = new System.Drawing.Size(97, 22);
            this.buttonDataRequest.TabIndex = 2;
            this.buttonDataRequest.Text = "Go!";
            this.buttonDataRequest.UseVisualStyleBackColor = true;
            this.buttonDataRequest.Click += new System.EventHandler(this.buttonDataRequest_Click);
            // 
            // dateTimePickerRequestPeriodEnd
            // 
            this.dateTimePickerRequestPeriodEnd.Location = new System.Drawing.Point(238, 39);
            this.dateTimePickerRequestPeriodEnd.Name = "dateTimePickerRequestPeriodEnd";
            this.dateTimePickerRequestPeriodEnd.Size = new System.Drawing.Size(133, 19);
            this.dateTimePickerRequestPeriodEnd.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fin:";
            // 
            // dateTimePickerRequestPeriodStart
            // 
            this.dateTimePickerRequestPeriodStart.Location = new System.Drawing.Point(65, 39);
            this.dateTimePickerRequestPeriodStart.Name = "dateTimePickerRequestPeriodStart";
            this.dateTimePickerRequestPeriodStart.Size = new System.Drawing.Size(133, 19);
            this.dateTimePickerRequestPeriodStart.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
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
            this.groupBoxResults.Location = new System.Drawing.Point(12, 133);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(711, 474);
            this.groupBoxResults.TabIndex = 2;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Résultats";
            // 
            // buttonUpdateTable
            // 
            this.buttonUpdateTable.Location = new System.Drawing.Point(114, 160);
            this.buttonUpdateTable.Name = "buttonUpdateTable";
            this.buttonUpdateTable.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateTable.TabIndex = 6;
            this.buttonUpdateTable.Text = "Rafraichir";
            this.buttonUpdateTable.UseVisualStyleBackColor = true;
            this.buttonUpdateTable.Click += new System.EventHandler(this.buttonUpdateTable_Click);
            // 
            // textBoxTournamentDetails
            // 
            this.textBoxTournamentDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTournamentDetails.Location = new System.Drawing.Point(337, 38);
            this.textBoxTournamentDetails.Multiline = true;
            this.textBoxTournamentDetails.Name = "textBoxTournamentDetails";
            this.textBoxTournamentDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTournamentDetails.Size = new System.Drawing.Size(360, 116);
            this.textBoxTournamentDetails.TabIndex = 5;
            this.textBoxTournamentDetails.WordWrap = false;
            // 
            // buttonExtractToCSV
            // 
            this.buttonExtractToCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExtractToCSV.Location = new System.Drawing.Point(12, 441);
            this.buttonExtractToCSV.Name = "buttonExtractToCSV";
            this.buttonExtractToCSV.Size = new System.Drawing.Size(132, 23);
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
            this.listViewPoints.Location = new System.Drawing.Point(11, 193);
            this.listViewPoints.Name = "listViewPoints";
            this.listViewPoints.Size = new System.Drawing.Size(686, 238);
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
            this.checkedListBoxTournois.Location = new System.Drawing.Point(11, 38);
            this.checkedListBoxTournois.Name = "checkedListBoxTournois";
            this.checkedListBoxTournois.Size = new System.Drawing.Size(320, 116);
            this.checkedListBoxTournois.TabIndex = 2;
            this.checkedListBoxTournois.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxTournois_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tableau de points:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 12);
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
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(733, 26);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(58, 22);
            this.fichierToolStripMenuItem.Text = "&Fichier";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.quitterToolStripMenuItem.Text = "&Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parametresToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(64, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // parametresToolStripMenuItem
            // 
            this.parametresToolStripMenuItem.Name = "parametresToolStripMenuItem";
            this.parametresToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.parametresToolStripMenuItem.Text = "&Paramètres";
            this.parametresToolStripMenuItem.Click += new System.EventHandler(this.parametresToolStripMenuItem_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCopy.Location = new System.Drawing.Point(150, 441);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(181, 23);
            this.buttonCopy.TabIndex = 4;
            this.buttonCopy.Text = "Copier dans le presse papier";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 619);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.groupBoxDataRetrieval);
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
    }
}

