namespace MD5
{
    partial class Form1
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
            encrypt = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            decrypt = new Button();
            SuspendLayout();
            // 
            // encrypt
            // 
            encrypt.Font = new Font("Segoe UI", 20F);
            encrypt.Location = new Point(12, 78);
            encrypt.Name = "encrypt";
            encrypt.Size = new Size(202, 53);
            encrypt.TabIndex = 0;
            encrypt.Text = "Зашифровать";
            encrypt.UseVisualStyleBackColor = true;
            encrypt.Click += encrypt_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 24F);
            textBox1.Location = new Point(1807, 636);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 50);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 24F);
            textBox2.Location = new Point(12, 12);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(294, 50);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 24F);
            textBox3.Location = new Point(12, 153);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(294, 50);
            textBox3.TabIndex = 4;
            // 
            // decrypt
            // 
            decrypt.Font = new Font("Segoe UI", 20F);
            decrypt.Location = new Point(12, 219);
            decrypt.Name = "decrypt";
            decrypt.Size = new Size(202, 53);
            decrypt.TabIndex = 3;
            decrypt.Text = "Зашифровать";
            decrypt.UseVisualStyleBackColor = true;
            decrypt.Click += decrypt_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(319, 284);
            Controls.Add(textBox3);
            Controls.Add(decrypt);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(encrypt);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button encrypt;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button decrypt;
    }
}
