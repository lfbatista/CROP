namespace WindowsFormsApplication3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btOpenPorta1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btOpenPorta1
            // 
            this.btOpenPorta1.Location = new System.Drawing.Point(140, 61);
            this.btOpenPorta1.Name = "btOpenPorta1";
            this.btOpenPorta1.Size = new System.Drawing.Size(94, 23);
            this.btOpenPorta1.TabIndex = 0;
            this.btOpenPorta1.Text = "OPEN Porta";
            this.btOpenPorta1.UseVisualStyleBackColor = true;
            this.btOpenPorta1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 146);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(461, 110);
            this.textBox1.TabIndex = 3;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "9600",
            "38400",
            "115200"});
            this.comboBox2.Location = new System.Drawing.Point(13, 106);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Porta 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Baud Rate:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(462, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Sair";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(140, 104);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "CLOSE Porta";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(489, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "String para a Base de Dados:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(492, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(461, 20);
            this.textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(585, 131);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(122, 20);
            this.textBox3.TabIndex = 11;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(585, 157);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(122, 20);
            this.textBox4.TabIndex = 12;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(585, 183);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(122, 20);
            this.textBox5.TabIndex = 13;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(585, 207);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(122, 20);
            this.textBox6.TabIndex = 14;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(831, 131);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(122, 20);
            this.textBox7.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(558, 296);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 19;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(831, 157);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(122, 20);
            this.textBox8.TabIndex = 22;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(831, 183);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(122, 20);
            this.textBox9.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Porta COM:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(492, 107);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Elementos a carregar na BD:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(493, 133);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(40, 17);
            this.checkBox1.TabIndex = 28;
            this.checkBox1.Text = "ID:";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(493, 159);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(41, 17);
            this.checkBox2.TabIndex = 29;
            this.checkBox2.Text = "Nº:";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(492, 185);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(86, 17);
            this.checkBox3.TabIndex = 30;
            this.checkBox3.Text = "Temperatura";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(492, 211);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(52, 17);
            this.checkBox4.TabIndex = 31;
            this.checkBox4.Text = "Hora:";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(740, 133);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(52, 17);
            this.checkBox5.TabIndex = 32;
            this.checkBox5.Text = "Data:";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(740, 159);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(88, 17);
            this.checkBox6.TabIndex = 33;
            this.checkBox6.Text = "Nível Bateria";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(740, 185);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(77, 17);
            this.checkBox7.TabIndex = 34;
            this.checkBox7.Text = "Humidade:";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(489, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 35;
            this.label4.Text = "Waspmote";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(489, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 24);
            this.label5.TabIndex = 36;
            this.label5.Text = "Arduino";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(380, 104);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 23);
            this.button4.TabIndex = 43;
            this.button4.Text = "CLOSE Porta";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Baud Rate:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(249, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Porta 2:";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "9600",
            "38400",
            "115200"});
            this.comboBox3.Location = new System.Drawing.Point(252, 106);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 40;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(492, 335);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox10.Size = new System.Drawing.Size(461, 62);
            this.textBox10.TabIndex = 39;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(252, 63);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 21);
            this.comboBox4.TabIndex = 38;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(380, 61);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 23);
            this.button5.TabIndex = 37;
            this.button5.Text = "OPEN Porta";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(584, 75);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(255, 21);
            this.comboBox5.TabIndex = 44;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(493, 79);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(79, 17);
            this.checkBox8.TabIndex = 45;
            this.checkBox8.Text = "Comentário";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(494, 286);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(79, 17);
            this.checkBox9.TabIndex = 47;
            this.checkBox9.Text = "Comentário";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(585, 282);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(253, 21);
            this.comboBox6.TabIndex = 46;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 270);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "Porta COM:";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(13, 286);
            this.textBox11.Multiline = true;
            this.textBox11.Name = "textBox11";
            this.textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox11.Size = new System.Drawing.Size(461, 111);
            this.textBox11.TabIndex = 49;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Checked = true;
            this.checkBox10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox10.Location = new System.Drawing.Point(493, 311);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(77, 17);
            this.checkBox10.TabIndex = 52;
            this.checkBox10.Text = "Humidade:";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(585, 309);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(122, 20);
            this.textBox12.TabIndex = 51;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 410);
            this.Controls.Add(this.checkBox10);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.checkBox9);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.checkBox8);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btOpenPorta1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Serial READ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOpenPorta1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.TextBox textBox12;
    }
}

