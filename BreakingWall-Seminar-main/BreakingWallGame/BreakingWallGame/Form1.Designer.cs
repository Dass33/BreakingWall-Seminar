namespace BreakingWallGame
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbplatno = new System.Windows.Forms.PictureBox();
            this.tmrRedraw = new System.Windows.Forms.Timer(this.components);
            this.lbGameOver = new System.Windows.Forms.Label();
            this.btStartOver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbplatno)).BeginInit();
            this.SuspendLayout();
            // 
            // pbplatno
            // 
            this.pbplatno.Location = new System.Drawing.Point(12, 12);
            this.pbplatno.Name = "pbplatno";
            this.pbplatno.Size = new System.Drawing.Size(931, 628);
            this.pbplatno.TabIndex = 0;
            this.pbplatno.TabStop = false;
            // 
            // tmrRedraw
            // 
            this.tmrRedraw.Interval = 10;
            this.tmrRedraw.Tick += new System.EventHandler(this.tmrRedraw_Tick);
            // 
            // lbGameOver
            // 
            this.lbGameOver.AutoSize = true;
            this.lbGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbGameOver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbGameOver.Location = new System.Drawing.Point(436, 204);
            this.lbGameOver.Name = "lbGameOver";
            this.lbGameOver.Size = new System.Drawing.Size(281, 55);
            this.lbGameOver.TabIndex = 2;
            this.lbGameOver.Text = "Game Over";
            this.lbGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbGameOver.Visible = false;
            // 
            // btStartOver
            // 
            this.btStartOver.AccessibleDescription = "";
            this.btStartOver.Location = new System.Drawing.Point(393, 178);
            this.btStartOver.Name = "btStartOver";
            this.btStartOver.Size = new System.Drawing.Size(75, 23);
            this.btStartOver.TabIndex = 3;
            this.btStartOver.Text = "button1";
            this.btStartOver.UseVisualStyleBackColor = true;
            this.btStartOver.Visible = false;
            this.btStartOver.Click += new System.EventHandler(this.btStartOver_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 686);
            this.Controls.Add(this.btStartOver);
            this.Controls.Add(this.lbGameOver);
            this.Controls.Add(this.pbplatno);
            this.Name = "Form1";
            this.Text = "Breaking Wall";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbplatno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbplatno;
        private System.Windows.Forms.Timer tmrRedraw;
        private System.Windows.Forms.Label lbGameOver;
        private System.Windows.Forms.Button btStartOver;
    }
}

