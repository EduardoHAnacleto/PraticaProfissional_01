﻿namespace ProjetoEduardoAnacletoWindowsForm1.Forms_Find
{
    partial class Frm_Find_PhoneClassifications
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_phoneClassification = new System.Windows.Forms.Label();
            this.edt_PhoneClassification = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.DGV_PhoneClassification = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneClassification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.edt_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PhoneClassification)).BeginInit();
            this.SuspendLayout();
            // 
            // edt_id
            // 
            this.edt_id.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.edt_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edt_id_KeyPress);
            // 
            // lbl_phoneClassification
            // 
            this.lbl_phoneClassification.AutoSize = true;
            this.lbl_phoneClassification.Location = new System.Drawing.Point(81, 11);
            this.lbl_phoneClassification.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_phoneClassification.Name = "lbl_phoneClassification";
            this.lbl_phoneClassification.Size = new System.Drawing.Size(126, 16);
            this.lbl_phoneClassification.TabIndex = 18;
            this.lbl_phoneClassification.Text = "Phone classification";
            // 
            // edt_PhoneClassification
            // 
            this.edt_PhoneClassification.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edt_PhoneClassification.Location = new System.Drawing.Point(85, 28);
            this.edt_PhoneClassification.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edt_PhoneClassification.Name = "edt_PhoneClassification";
            this.edt_PhoneClassification.Size = new System.Drawing.Size(265, 22);
            this.edt_PhoneClassification.TabIndex = 17;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(360, 25);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(100, 28);
            this.btn_Search.TabIndex = 19;
            this.btn_Search.Text = "&Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // DGV_PhoneClassification
            // 
            this.DGV_PhoneClassification.AllowUserToAddRows = false;
            this.DGV_PhoneClassification.AllowUserToDeleteRows = false;
            this.DGV_PhoneClassification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_PhoneClassification.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PhoneClassification});
            this.DGV_PhoneClassification.Location = new System.Drawing.Point(12, 81);
            this.DGV_PhoneClassification.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGV_PhoneClassification.MultiSelect = false;
            this.DGV_PhoneClassification.Name = "DGV_PhoneClassification";
            this.DGV_PhoneClassification.ReadOnly = true;
            this.DGV_PhoneClassification.RowHeadersWidth = 51;
            this.DGV_PhoneClassification.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_PhoneClassification.Size = new System.Drawing.Size(772, 313);
            this.DGV_PhoneClassification.TabIndex = 20;
            this.DGV_PhoneClassification.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_PhoneClassification_CellClick);
            this.DGV_PhoneClassification.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_PhoneClassification_CellContentClick);
            this.DGV_PhoneClassification.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_PhoneClassification_CellContentDoubleClick);
            this.DGV_PhoneClassification.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DGV_PhoneClassification_KeyPress);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 65;
            // 
            // PhoneClassification
            // 
            this.PhoneClassification.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PhoneClassification.HeaderText = "Phone Classification";
            this.PhoneClassification.MinimumWidth = 6;
            this.PhoneClassification.Name = "PhoneClassification";
            this.PhoneClassification.ReadOnly = true;
            // 
            // Frm_Find_PhoneClassifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DGV_PhoneClassification);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.lbl_phoneClassification);
            this.Controls.Add(this.edt_PhoneClassification);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Frm_Find_PhoneClassifications";
            this.Text = "Find Phone Classification";
            this.Controls.SetChildIndex(this.lbl_id, 0);
            this.Controls.SetChildIndex(this.btn_exit, 0);
            this.Controls.SetChildIndex(this.btn_New, 0);
            this.Controls.SetChildIndex(this.edt_id, 0);
            this.Controls.SetChildIndex(this.btn_Select, 0);
            this.Controls.SetChildIndex(this.edt_PhoneClassification, 0);
            this.Controls.SetChildIndex(this.lbl_phoneClassification, 0);
            this.Controls.SetChildIndex(this.btn_Search, 0);
            this.Controls.SetChildIndex(this.DGV_PhoneClassification, 0);
            ((System.ComponentModel.ISupportInitialize)(this.edt_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_PhoneClassification)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_phoneClassification;
        private System.Windows.Forms.TextBox edt_PhoneClassification;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.DataGridView DGV_PhoneClassification;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneClassification;
    }
}
