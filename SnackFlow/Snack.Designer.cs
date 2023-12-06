namespace SnackFlow
{
    partial class frm_Snack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Snack));
            this.btn_Convert = new System.Windows.Forms.Button();
            this.txt_PathDestino = new System.Windows.Forms.TextBox();
            this.txt_PathRuta = new System.Windows.Forms.TextBox();
            this.btn_PathDestino = new System.Windows.Forms.Button();
            this.btn_PathRuta = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.imageFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Convert
            // 
            this.btn_Convert.BackColor = System.Drawing.Color.Crimson;
            this.btn_Convert.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12.5F, System.Drawing.FontStyle.Bold);
            this.btn_Convert.ForeColor = System.Drawing.Color.White;
            this.btn_Convert.Location = new System.Drawing.Point(236, 623);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Size = new System.Drawing.Size(149, 44);
            this.btn_Convert.TabIndex = 300;
            this.btn_Convert.Text = "CONVERTIR";
            this.btn_Convert.UseVisualStyleBackColor = false;
            this.btn_Convert.Click += new System.EventHandler(this.btn_Convertir_Click);
            // 
            // txt_PathDestino
            // 
            this.txt_PathDestino.BackColor = System.Drawing.SystemColors.Window;
            this.txt_PathDestino.Location = new System.Drawing.Point(34, 381);
            this.txt_PathDestino.Name = "txt_PathDestino";
            this.txt_PathDestino.ReadOnly = true;
            this.txt_PathDestino.Size = new System.Drawing.Size(294, 20);
            this.txt_PathDestino.TabIndex = 1118;
            // 
            // txt_PathRuta
            // 
            this.txt_PathRuta.BackColor = System.Drawing.SystemColors.Window;
            this.txt_PathRuta.Location = new System.Drawing.Point(34, 307);
            this.txt_PathRuta.Name = "txt_PathRuta";
            this.txt_PathRuta.ReadOnly = true;
            this.txt_PathRuta.Size = new System.Drawing.Size(294, 20);
            this.txt_PathRuta.TabIndex = 1117;
            // 
            // btn_PathDestino
            // 
            this.btn_PathDestino.BackColor = System.Drawing.Color.White;
            this.btn_PathDestino.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PathDestino.Location = new System.Drawing.Point(334, 378);
            this.btn_PathDestino.Name = "btn_PathDestino";
            this.btn_PathDestino.Size = new System.Drawing.Size(38, 25);
            this.btn_PathDestino.TabIndex = 200;
            this.btn_PathDestino.Text = ". . .";
            this.btn_PathDestino.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_PathDestino.UseVisualStyleBackColor = false;
            this.btn_PathDestino.Click += new System.EventHandler(this.btn_PathDestino_Click);
            // 
            // btn_PathRuta
            // 
            this.btn_PathRuta.BackColor = System.Drawing.Color.White;
            this.btn_PathRuta.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PathRuta.Location = new System.Drawing.Point(334, 305);
            this.btn_PathRuta.Name = "btn_PathRuta";
            this.btn_PathRuta.Size = new System.Drawing.Size(38, 25);
            this.btn_PathRuta.TabIndex = 100;
            this.btn_PathRuta.Text = ". . .";
            this.btn_PathRuta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_PathRuta.UseVisualStyleBackColor = false;
            this.btn_PathRuta.Click += new System.EventHandler(this.btn_PathRuta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSalmon;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 18);
            this.label2.TabIndex = 1113;
            this.label2.Text = "SELECCIONA LA CARPETA DONDE QUIERES QUE SE GUARDE TU ASCII ART";
            // 
            // imageFlowLayout
            // 
            this.imageFlowLayout.BackColor = System.Drawing.SystemColors.Window;
            this.imageFlowLayout.Location = new System.Drawing.Point(34, 477);
            this.imageFlowLayout.Name = "imageFlowLayout";
            this.imageFlowLayout.Size = new System.Drawing.Size(575, 125);
            this.imageFlowLayout.TabIndex = 1121;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(52, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(546, 250);
            this.pictureBox1.TabIndex = 1122;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Turquoise;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(35, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 18);
            this.label1.TabIndex = 1112;
            this.label1.Text = "SELECCIONA LA CARPETA QUE CONTIENE TUS IMÁGENES";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Pink;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(35, 455);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 19);
            this.label6.TabIndex = 1123;
            this.label6.Text = "SELECCIONE UNA O MÁS IMÁGENES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(553, 13);
            this.label3.TabIndex = 1124;
            this.label3.Text = "=================================================================================" +
    "==========";
            // 
            // frm_Snack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(644, 741);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.imageFlowLayout);
            this.Controls.Add(this.btn_Convert);
            this.Controls.Add(this.txt_PathDestino);
            this.Controls.Add(this.txt_PathRuta);
            this.Controls.Add(this.btn_PathDestino);
            this.Controls.Add(this.btn_PathRuta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_Snack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snack Flow";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Convert;
        private System.Windows.Forms.TextBox txt_PathDestino;
        private System.Windows.Forms.TextBox txt_PathRuta;
        private System.Windows.Forms.Button btn_PathDestino;
        private System.Windows.Forms.Button btn_PathRuta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel imageFlowLayout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
    }
}

