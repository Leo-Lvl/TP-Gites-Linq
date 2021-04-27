namespace tpGites
{
    partial class FGites
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
            if (disposing && (components != null)) {
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
            this.lbl_requetes = new System.Windows.Forms.Label();
            this.cb_requetes = new System.Windows.Forms.ComboBox();
            this.btn_lancerRequetes = new System.Windows.Forms.Button();
            this.rtb_resultat = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lbl_requetes
            // 
            this.lbl_requetes.AutoSize = true;
            this.lbl_requetes.Location = new System.Drawing.Point(12, 9);
            this.lbl_requetes.Name = "lbl_requetes";
            this.lbl_requetes.Size = new System.Drawing.Size(53, 13);
            this.lbl_requetes.TabIndex = 0;
            this.lbl_requetes.Text = "Requêtes";
            // 
            // cb_requetes
            // 
            this.cb_requetes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_requetes.FormattingEnabled = true;
            this.cb_requetes.Location = new System.Drawing.Point(12, 25);
            this.cb_requetes.Name = "cb_requetes";
            this.cb_requetes.Size = new System.Drawing.Size(404, 21);
            this.cb_requetes.TabIndex = 1;
            this.cb_requetes.SelectedIndexChanged += new System.EventHandler(this.cb_requetes_SelectedIndexChanged);
            // 
            // btn_lancerRequetes
            // 
            this.btn_lancerRequetes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_lancerRequetes.Location = new System.Drawing.Point(422, 24);
            this.btn_lancerRequetes.Name = "btn_lancerRequetes";
            this.btn_lancerRequetes.Size = new System.Drawing.Size(75, 23);
            this.btn_lancerRequetes.TabIndex = 2;
            this.btn_lancerRequetes.Text = "OK";
            this.btn_lancerRequetes.UseVisualStyleBackColor = true;
            this.btn_lancerRequetes.Click += new System.EventHandler(this.btn_lancerRequetes_Click);
            // 
            // rtb_resultat
            // 
            this.rtb_resultat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_resultat.BackColor = System.Drawing.Color.Gray;
            this.rtb_resultat.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_resultat.ForeColor = System.Drawing.Color.White;
            this.rtb_resultat.Location = new System.Drawing.Point(12, 52);
            this.rtb_resultat.Name = "rtb_resultat";
            this.rtb_resultat.ReadOnly = true;
            this.rtb_resultat.ShortcutsEnabled = false;
            this.rtb_resultat.Size = new System.Drawing.Size(485, 202);
            this.rtb_resultat.TabIndex = 3;
            this.rtb_resultat.Text = "";
            this.rtb_resultat.WordWrap = false;
            // 
            // FGites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 269);
            this.Controls.Add(this.rtb_resultat);
            this.Controls.Add(this.btn_lancerRequetes);
            this.Controls.Add(this.cb_requetes);
            this.Controls.Add(this.lbl_requetes);
            this.Name = "FGites";
            this.Text = "Requêtes Linq";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_requetes;
        private System.Windows.Forms.ComboBox cb_requetes;
        private System.Windows.Forms.Button btn_lancerRequetes;
        private System.Windows.Forms.RichTextBox rtb_resultat;
    }
}

