namespace Laba2
{
    partial class WhoIs
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Information = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.namedomain = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Information
            // 
            this.Information.CausesValidation = false;
            this.Information.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Information.Location = new System.Drawing.Point(293, 12);
            this.Information.Multiline = true;
            this.Information.Name = "Information";
            this.Information.ReadOnly = true;
            this.Information.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Information.Size = new System.Drawing.Size(271, 236);
            this.Information.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter your request (domain name or IP)";
            // 
            // namedomain
            // 
            this.namedomain.Location = new System.Drawing.Point(46, 76);
            this.namedomain.Name = "namedomain";
            this.namedomain.Size = new System.Drawing.Size(209, 20);
            this.namedomain.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(69, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 53);
            this.button1.TabIndex = 3;
            this.button1.Text = "Search!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Progress
            // 
            this.Progress.Location = new System.Drawing.Point(46, 213);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(209, 23);
            this.Progress.TabIndex = 4;
            // 
            // WhoIs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 260);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.namedomain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Information);
            this.MaximumSize = new System.Drawing.Size(592, 299);
            this.MinimumSize = new System.Drawing.Size(592, 299);
            this.Name = "WhoIs";
            this.Text = "WhoIs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Information;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namedomain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar Progress;
    }
}

