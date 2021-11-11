namespace GeneratoryPseudolosowe
{
    partial class Menu
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
            this.mName_lbl = new System.Windows.Forms.Label();
            this.menu1_btn = new System.Windows.Forms.Button();
            this.menu2_btn = new System.Windows.Forms.Button();
            this.menu3_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mName_lbl
            // 
            this.mName_lbl.AutoSize = true;
            this.mName_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mName_lbl.Location = new System.Drawing.Point(242, 70);
            this.mName_lbl.Name = "mName_lbl";
            this.mName_lbl.Size = new System.Drawing.Size(345, 46);
            this.mName_lbl.TabIndex = 0;
            this.mName_lbl.Text = "Wybierz generator";
            // 
            // menu1_btn
            // 
            this.menu1_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menu1_btn.Location = new System.Drawing.Point(183, 159);
            this.menu1_btn.Name = "menu1_btn";
            this.menu1_btn.Size = new System.Drawing.Size(472, 95);
            this.menu1_btn.TabIndex = 1;
            this.menu1_btn.Text = "Kongruencje Liniowe";
            this.menu1_btn.UseVisualStyleBackColor = true;
            this.menu1_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // menu2_btn
            // 
            this.menu2_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menu2_btn.Location = new System.Drawing.Point(183, 291);
            this.menu2_btn.Name = "menu2_btn";
            this.menu2_btn.Size = new System.Drawing.Size(472, 95);
            this.menu2_btn.TabIndex = 2;
            this.menu2_btn.Text = "Kongruencje Kwadratowe";
            this.menu2_btn.UseVisualStyleBackColor = true;
            this.menu2_btn.Click += new System.EventHandler(this.menu2_btn_Click);
            // 
            // menu3_btn
            // 
            this.menu3_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menu3_btn.Location = new System.Drawing.Point(183, 431);
            this.menu3_btn.Name = "menu3_btn";
            this.menu3_btn.Size = new System.Drawing.Size(472, 95);
            this.menu3_btn.TabIndex = 3;
            this.menu3_btn.Text = "Metoda von Neumanna";
            this.menu3_btn.UseVisualStyleBackColor = true;
            this.menu3_btn.Click += new System.EventHandler(this.menu3_btn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(183, 573);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(472, 95);
            this.button1.TabIndex = 4;
            this.button1.Text = "Kombinacje liniowe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(183, 714);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(472, 148);
            this.button2.TabIndex = 5;
            this.button2.Text = "Metoda Mitchela-Moora i Marsagali";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 986);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menu3_btn);
            this.Controls.Add(this.menu2_btn);
            this.Controls.Add(this.menu1_btn);
            this.Controls.Add(this.mName_lbl);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mName_lbl;
        private System.Windows.Forms.Button menu1_btn;
        private System.Windows.Forms.Button menu2_btn;
        private System.Windows.Forms.Button menu3_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}