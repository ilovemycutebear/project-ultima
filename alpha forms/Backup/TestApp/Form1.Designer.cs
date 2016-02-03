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
			this.picBoxClose = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// picBoxClose
			// 
			this.picBoxClose.BackColor = System.Drawing.Color.Transparent;
			this.picBoxClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxClose.BackgroundImage")));
			this.picBoxClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.picBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("picBoxClose.Image")));
			this.picBoxClose.Location = new System.Drawing.Point(601, 8);
			this.picBoxClose.Name = "picBoxClose";
			this.picBoxClose.Size = new System.Drawing.Size(32, 32);
			this.picBoxClose.TabIndex = 0;
			this.picBoxClose.TabStop = false;
			this.picBoxClose.Click += new System.EventHandler(this.picBoxClose_Click);
			this.picBoxClose.MouseEnter += new System.EventHandler(this.picBoxClose_MouseEnter);
			this.picBoxClose.MouseLeave += new System.EventHandler(this.picBoxClose_MouseLeave);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(6, 19);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(170, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "Text Box";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Transparent;
			this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button1.Location = new System.Drawing.Point(6, 45);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(170, 36);
			this.button1.TabIndex = 2;
			this.button1.Text = "Button";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
			this.groupBox1.Location = new System.Drawing.Point(53, 53);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(194, 95);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Group Box";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Fuchsia;
			this.BlendedBackground = ((System.Drawing.Bitmap)(resources.GetObject("$this.BlendedBackground")));
			this.ClientSize = new System.Drawing.Size(640, 480);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.picBoxClose);
			this.DrawControlBackgrounds = true;
			this.EnhancedRendering = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.Name = "Form1";
			this.SizeMode = AlphaForms.AlphaForm.SizeModes.Clip;
			this.Text = "Form1";
			this.TransparencyKey = System.Drawing.Color.Fuchsia;
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox picBoxClose;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}

