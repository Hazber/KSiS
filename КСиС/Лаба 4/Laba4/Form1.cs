using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4
{
    public partial class Form1 : Form
    {
        PopClass POP3;
        bool flag_q_c=true;
       
        
        public Form1()
        {
            InitializeComponent();
            AutoCompleteStringCollection source = new AutoCompleteStringCollection()
        {
            "USER hazarion@mail.ru",
            "PASS azsxdcqawsed123"
        };
            TBCom.AutoCompleteCustomSource = source;
            TBCom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TBCom.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TBCom.Enabled = false;
            BTNSend.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
            string command = TBCom.Text.Trim();
            string response = POP3.Command_Manager(command);
            if (response != null)
                TBDIalog.Text += response.Trim()+ Environment.NewLine;
            else
                MessageBox.Show("Ошибка");
        }

        public void BTNConnect_Click(object sender, EventArgs e)
        {
            try
            {
                TBDIalog.Clear();
                if (flag_q_c)
                {
                    
                    POP3 = new PopClass(TBServ.Text);
                    if (POP3.Connect(TBDIalog))
                    {
                        TBServ.Enabled = false;
                        BTNConnect.Text = "Отключиться";
                        BTNSend.Enabled = TBCom.Enabled = true;
                        flag_q_c = false;
                    }
                }
                else
                {
                    TBServ.Enabled = true;
                    BTNConnect.Text = "Подключиться";
                    BTNSend.Enabled = TBCom.Enabled = false;
                    POP3.Command_Manager("QUIT");
                    flag_q_c = true;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
