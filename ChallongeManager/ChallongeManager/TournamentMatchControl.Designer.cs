namespace ChallongeManager
{
    partial class TournamentMatchControl
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelMatchNumber = new System.Windows.Forms.Label();
            this.textBoxOpponent1 = new System.Windows.Forms.TextBox();
            this.textBoxOpponent2 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelMatchNumber
            // 
            this.labelMatchNumber.Location = new System.Drawing.Point(0, 0);
            this.labelMatchNumber.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelMatchNumber.Name = "labelMatchNumber";
            this.labelMatchNumber.Size = new System.Drawing.Size(28, 38);
            this.labelMatchNumber.TabIndex = 0;
            this.labelMatchNumber.Text = "000";
            this.labelMatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxOpponent1
            // 
            this.textBoxOpponent1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOpponent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOpponent1.Location = new System.Drawing.Point(30, 1);
            this.textBoxOpponent1.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxOpponent1.Name = "textBoxOpponent1";
            this.textBoxOpponent1.Size = new System.Drawing.Size(65, 18);
            this.textBoxOpponent1.TabIndex = 1;
            this.textBoxOpponent1.Text = "test";
            // 
            // textBoxOpponent2
            // 
            this.textBoxOpponent2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOpponent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOpponent2.Location = new System.Drawing.Point(30, 19);
            this.textBoxOpponent2.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxOpponent2.Name = "textBoxOpponent2";
            this.textBoxOpponent2.Size = new System.Drawing.Size(65, 18);
            this.textBoxOpponent2.TabIndex = 1;
            // 
            // TournamentMatchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textBoxOpponent2);
            this.Controls.Add(this.textBoxOpponent1);
            this.Controls.Add(this.labelMatchNumber);
            this.MaximumSize = new System.Drawing.Size(250, 40);
            this.MinimumSize = new System.Drawing.Size(100, 40);
            this.Name = "TournamentMatchControl";
            this.Size = new System.Drawing.Size(98, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMatchNumber;
        private System.Windows.Forms.TextBox textBoxOpponent1;
        private System.Windows.Forms.TextBox textBoxOpponent2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
