namespace Laba4
{
    partial class Form1
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
            this.TBCom = new System.Windows.Forms.TextBox();
            this.BTNSend = new System.Windows.Forms.Button();
            this.TBServ = new System.Windows.Forms.TextBox();
            this.BTNConnect = new System.Windows.Forms.Button();
            this.TBDIalog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TBCom
            // 
            this.TBCom.Location = new System.Drawing.Point(12, 298);
            this.TBCom.Name = "TBCom";
            this.TBCom.Size = new System.Drawing.Size(383, 20);
            this.TBCom.TabIndex = 1;
            this.TBCom.Text = "Введите команду";
            // 
            // BTNSend
            // 
            this.BTNSend.Location = new System.Drawing.Point(422, 295);
            this.BTNSend.Name = "BTNSend";
            this.BTNSend.Size = new System.Drawing.Size(122, 53);
            this.BTNSend.TabIndex = 2;
            this.BTNSend.Text = "Отправить";
            this.BTNSend.UseVisualStyleBackColor = true;
            this.BTNSend.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TBServ
            // 
            this.TBServ.Location = new System.Drawing.Point(12, 384);
            this.TBServ.Name = "TBServ";
            this.TBServ.Size = new System.Drawing.Size(383, 20);
            this.TBServ.TabIndex = 3;
            this.TBServ.Text = "Введите имя pop-сервера";
            // 
            // BTNConnect
            // 
            this.BTNConnect.Location = new System.Drawing.Point(422, 373);
            this.BTNConnect.Name = "BTNConnect";
            this.BTNConnect.Size = new System.Drawing.Size(122, 40);
            this.BTNConnect.TabIndex = 4;
            this.BTNConnect.Text = "Подключиться";
            this.BTNConnect.UseVisualStyleBackColor = true;
            this.BTNConnect.Click += new System.EventHandler(this.BTNConnect_Click);
            // 
            // TBDIalog
            // 
            this.TBDIalog.Location = new System.Drawing.Point(12, 36);
            this.TBDIalog.Multiline = true;
            this.TBDIalog.Name = "TBDIalog";
            this.TBDIalog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBDIalog.Size = new System.Drawing.Size(532, 231);
            this.TBDIalog.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 436);
            this.Controls.Add(this.TBDIalog);
            this.Controls.Add(this.BTNConnect);
            this.Controls.Add(this.TBServ);
            this.Controls.Add(this.BTNSend);
            this.Controls.Add(this.TBCom);
            this.Name = "Form1";
            this.Text = "POPClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TBCom;
        private System.Windows.Forms.Button BTNSend;
        private System.Windows.Forms.TextBox TBServ;
        private System.Windows.Forms.Button BTNConnect;
        private System.Windows.Forms.TextBox TBDIalog;
    }
}

