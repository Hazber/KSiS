using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace Laba2
{
    public partial class WhoIs : Form
    {
        static TcpClient tcpWhois;
        static NetworkStream nsWhois;
        static BufferedStream bfWhois;
        static StreamWriter strmSend;
        static StreamReader strmRecive;
        enum TParamType { TDomain, TIp, TWhois };
        static string[] servers_domain = new string[7];

        static TParamType definitionType(string domain)
        {
            if (domain[domain.Length - 1] >= '0' && domain[domain.Length - 1] <= '9')
                return TParamType.TIp; 
            else
                return TParamType.TDomain; 
        }
        public WhoIs()
        {
            InitializeComponent();
            Progress.Minimum = 0;
            Progress.Maximum = 100;
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
        }


    private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1.PerformClick();
        }
        static string GetResult(string servername, string domain)
        {
            string response, result = null;
            try
            {
                tcpWhois = new TcpClient(servername, 43);
                nsWhois = tcpWhois.GetStream();
                bfWhois = new BufferedStream(nsWhois);
                strmSend = new StreamWriter(bfWhois);
                strmSend.WriteLine(domain);
                strmSend.Flush();
                strmRecive = new StreamReader(bfWhois);
                while ((response = strmRecive.ReadLine()) != null)
                {
                    result += response + "\r\n";
                }
                   
            }
            catch
            {
               // MessageBox.Show("WHOis Server Error");
            }
            finally
            {
                tcpWhois.Close();
            }
            return result;
        }

        static string ServerNameinResult(string result)
        {
            if (result != null)
            {
                int ind = result.IndexOf("whois.");
                if (ind != -1)
                {
                    result = result.Remove(0, ind);
                    result = result.Substring(0, result.IndexOf("\r\n"));
                    return result;
                }
                else
                    return null; 
            }
            else
                return null; 
        }

            static void GetServerNames_Domain(string domain, int count)
        {
            string result, TLD, fldomain;
            if (count > 0)
            {
                TLD = domain.Substring(domain.IndexOf('.'), domain.Length - domain.IndexOf('.'));
                fldomain = TLD.Substring(TLD.LastIndexOf('.') + 1, TLD.Length - TLD.LastIndexOf('.') - 1);
            }
            else
            {
                TLD = domain;
                fldomain = domain;
            }
            result = GetResult("whois.iana.org", fldomain);
            servers_domain[0] = ServerNameinResult(result);
            servers_domain[1] = "whois" + TLD;
            servers_domain[2] = "whois.nic" + TLD;
            servers_domain[3] = "whois.nic." + fldomain;
            servers_domain[4] = "whois." + fldomain;
            servers_domain[5] = "whois.cctld." + fldomain;
            servers_domain[6] = fldomain + ".whois-servers.net";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string result = null;
            Information.Clear();
            if (namedomain.Text == "")
            {
                namedomain.Text = "Input something please";
            }
            string domain = namedomain.Text;
            if (definitionType(domain)== TParamType.TDomain)
            {
                int number = 0, index = 0;
                while ((index = domain.IndexOf(".", index) + 1) != 0) number++;
                GetServerNames_Domain(domain, number);
                switch (number)
                {
                    case 0:
                    case 1:
                        result = GetResult(servers_domain[0], domain);
                        string new_result = ServerNameinResult(result);
                        if (new_result != null && new_result.IndexOf(' ') == -1) 
                            result = GetResult(new_result, domain); 
                        break;
                    default:
                        for (int i = 1; i < 7; i++)
                        {
                            result = GetResult(servers_domain[i], domain);
                            if (result != null)
                            {
                                new_result = ServerNameinResult(result);
                                if (new_result != null) 
                                    result = GetResult(new_result, domain); 
                                break;
                            }
                        }
                        break;
                }
            }
            else if (definitionType(domain) == TParamType.TIp)
            {
                result = GetResult("whois.iana.org", domain);
                result = GetResult(ServerNameinResult(result), domain);
            }
            if (result == null)
                 MessageBox.Show("IP or domain doesn't exist"); 
            else
                  Information.Text=result;
        }
    }
}
