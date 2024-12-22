namespace AcordLauncher
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.prograssbar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.loadingtxt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.üstpanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(91, 52);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(157, 153);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // prograssbar
            // 
            this.prograssbar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.prograssbar.Location = new System.Drawing.Point(-2, 440);
            this.prograssbar.Name = "prograssbar";
            this.prograssbar.Size = new System.Drawing.Size(360, 49);
            this.prograssbar.TabIndex = 1;
            this.prograssbar.Text = "guna2ProgressBar1";
            this.prograssbar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // loadingtxt
            // 
            this.loadingtxt.BackColor = System.Drawing.Color.Transparent;
            this.loadingtxt.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingtxt.ForeColor = System.Drawing.Color.White;
            this.loadingtxt.Location = new System.Drawing.Point(3, 404);
            this.loadingtxt.Name = "loadingtxt";
            this.loadingtxt.Size = new System.Drawing.Size(89, 30);
            this.loadingtxt.TabIndex = 2;
            this.loadingtxt.Text = "Yükleniyor";
            // 
            // üstpanel
            // 
            this.üstpanel.Location = new System.Drawing.Point(-2, 1);
            this.üstpanel.Name = "üstpanel";
            this.üstpanel.Size = new System.Drawing.Size(360, 34);
            this.üstpanel.TabIndex = 3;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.DragStartTransparencyValue = 1D;
            this.guna2DragControl1.TargetControl = this.üstpanel;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(356, 488);
            this.Controls.Add(this.üstpanel);
            this.Controls.Add(this.loadingtxt);
            this.Controls.Add(this.prograssbar);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ProgressBar prograssbar;
        private Guna.UI2.WinForms.Guna2HtmlLabel loadingtxt;
        private Guna.UI2.WinForms.Guna2Panel üstpanel;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}