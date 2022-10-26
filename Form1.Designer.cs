namespace MandelbrotTry
{
    partial class MandelbrotSet
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MandelbrotPanel = new System.Windows.Forms.Panel();
            this.JuliaSetPanel = new System.Windows.Forms.Panel();
            this.MouseLabelX = new System.Windows.Forms.Label();
            this.MouseLabelY = new System.Windows.Forms.Label();
            this.MandelbrotBtn = new System.Windows.Forms.Button();
            this.JuliaSetBtn = new System.Windows.Forms.Button();
            this.JuliaLbl = new System.Windows.Forms.Label();
            this.JuliaLbl2 = new System.Windows.Forms.Label();
            this.CreditsLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MandelbrotPanel
            // 
            this.MandelbrotPanel.Location = new System.Drawing.Point(12, 12);
            this.MandelbrotPanel.Name = "MandelbrotPanel";
            this.MandelbrotPanel.Size = new System.Drawing.Size(500, 500);
            this.MandelbrotPanel.TabIndex = 0;
            this.MandelbrotPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MandelbrotPanelPaint);
            this.MandelbrotPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MandelbrotPanel_MouseDown);
            // 
            // JuliaSetPanel
            // 
            this.JuliaSetPanel.Location = new System.Drawing.Point(672, 12);
            this.JuliaSetPanel.Name = "JuliaSetPanel";
            this.JuliaSetPanel.Size = new System.Drawing.Size(500, 500);
            this.JuliaSetPanel.TabIndex = 1;
            this.JuliaSetPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.JuliaSetPanel_Paint);
            // 
            // MouseLabelX
            // 
            this.MouseLabelX.AutoSize = true;
            this.MouseLabelX.Location = new System.Drawing.Point(672, 525);
            this.MouseLabelX.Name = "MouseLabelX";
            this.MouseLabelX.Size = new System.Drawing.Size(102, 15);
            this.MouseLabelX.TabIndex = 2;
            this.MouseLabelX.Text = "Mouse X Position:";
            // 
            // MouseLabelY
            // 
            this.MouseLabelY.AutoSize = true;
            this.MouseLabelY.Location = new System.Drawing.Point(828, 525);
            this.MouseLabelY.Name = "MouseLabelY";
            this.MouseLabelY.Size = new System.Drawing.Size(102, 15);
            this.MouseLabelY.TabIndex = 3;
            this.MouseLabelY.Text = "Mouse Y Position:";
            // 
            // MandelbrotBtn
            // 
            this.MandelbrotBtn.Location = new System.Drawing.Point(538, 145);
            this.MandelbrotBtn.Name = "MandelbrotBtn";
            this.MandelbrotBtn.Size = new System.Drawing.Size(102, 47);
            this.MandelbrotBtn.TabIndex = 5;
            this.MandelbrotBtn.Text = "Generate Mandelbrot Set";
            this.MandelbrotBtn.UseVisualStyleBackColor = true;
            this.MandelbrotBtn.Click += new System.EventHandler(this.MandelbrotBtn_Click);
            // 
            // JuliaSetBtn
            // 
            this.JuliaSetBtn.Location = new System.Drawing.Point(550, 263);
            this.JuliaSetBtn.Name = "JuliaSetBtn";
            this.JuliaSetBtn.Size = new System.Drawing.Size(81, 43);
            this.JuliaSetBtn.TabIndex = 6;
            this.JuliaSetBtn.Text = "Generate Julia Set";
            this.JuliaSetBtn.UseVisualStyleBackColor = true;
            this.JuliaSetBtn.Click += new System.EventHandler(this.JuliaSetBtn_Click);
            // 
            // JuliaLbl
            // 
            this.JuliaLbl.Location = new System.Drawing.Point(538, 195);
            this.JuliaLbl.Name = "JuliaLbl";
            this.JuliaLbl.Size = new System.Drawing.Size(113, 65);
            this.JuliaLbl.TabIndex = 7;
            // 
            // JuliaLbl2
            // 
            this.JuliaLbl2.Location = new System.Drawing.Point(538, 309);
            this.JuliaLbl2.Name = "JuliaLbl2";
            this.JuliaLbl2.Size = new System.Drawing.Size(113, 65);
            this.JuliaLbl2.TabIndex = 8;
            // 
            // CreditsLbl
            // 
            this.CreditsLbl.AutoSize = true;
            this.CreditsLbl.Location = new System.Drawing.Point(12, 537);
            this.CreditsLbl.Name = "CreditsLbl";
            this.CreditsLbl.Size = new System.Drawing.Size(136, 15);
            this.CreditsLbl.TabIndex = 9;
            this.CreditsLbl.Text = "Made by Gabriel Iobagiu";
            // 
            // MandelbrotSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.CreditsLbl);
            this.Controls.Add(this.JuliaLbl2);
            this.Controls.Add(this.JuliaLbl);
            this.Controls.Add(this.JuliaSetBtn);
            this.Controls.Add(this.MandelbrotBtn);
            this.Controls.Add(this.MouseLabelY);
            this.Controls.Add(this.MouseLabelX);
            this.Controls.Add(this.JuliaSetPanel);
            this.Controls.Add(this.MandelbrotPanel);
            this.Name = "MandelbrotSet";
            this.Text = "Mandelbrot Set";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel MandelbrotPanel;
        private Panel JuliaSetPanel;
        private Label MouseLabelX;
        private Label MouseLabelY;
        private Button MandelbrotBtn;
        private Button JuliaSetBtn;
        private Label JuliaLbl;
        private Label JuliaLbl2;
        private Label CreditsLbl;
    }
}