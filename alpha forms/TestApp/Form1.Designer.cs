namespace TestApp
{
	partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.picBoxClose = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.textBox1.Location = new System.Drawing.Point(481, 272);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(181, 30);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Username";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.LightCyan;
            this.button1.Location = new System.Drawing.Point(481, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "LOGIN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // picBoxClose
            // 
            this.picBoxClose.BackColor = System.Drawing.Color.Transparent;
            this.picBoxClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxClose.BackgroundImage")));
            this.picBoxClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("picBoxClose.Image")));
            this.picBoxClose.Location = new System.Drawing.Point(708, 12);
            this.picBoxClose.Name = "picBoxClose";
            this.picBoxClose.Size = new System.Drawing.Size(138, 115);
            this.picBoxClose.TabIndex = 0;
            this.picBoxClose.TabStop = false;
            this.picBoxClose.Click += new System.EventHandler(this.picBoxClose_Click);
            this.picBoxClose.MouseEnter += new System.EventHandler(this.picBoxClose_MouseEnter);
            this.picBoxClose.MouseLeave += new System.EventHandler(this.picBoxClose_MouseLeave);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.textBox3.Location = new System.Drawing.Point(481, 328);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(181, 30);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "Password";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BlendedBackground = ((System.Drawing.Bitmap)(resources.GetObject("$this.BlendedBackground")));
            this.ClientSize = new System.Drawing.Size(1136, 806);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.picBoxClose);
            this.DrawControlBackgrounds = true;
            this.EnhancedRendering = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "Form1";
            this.SizeMode = AlphaForms.AlphaForm.SizeModes.Clip;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picBoxClose;
        private System.Windows.Forms.TextBox textBox3;
    }
}

