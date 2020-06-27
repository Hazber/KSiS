using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Laba4
{
    class PopClass
    {
        private string host_name;
        private int port = 995;
        public enum ClientState { Connected,Authorized,Activated,Disconnected};
        private ClientState client_state=ClientState.Disconnected;
        private TcpClient tcp_cl;
        private SslStream ssl_stream;

        public PopClass(string pop_server_name)
        {
            host_name = pop_server_name;
        }

        public bool Connect(TextBox txb)
        {
            
            try
            {
                tcp_cl = new TcpClient();
                tcp_cl.Connect(host_name,port);
                ssl_stream = new SslStream(tcp_cl.GetStream());
                ssl_stream.AuthenticateAsClient(host_name);
                string response = GetResponse();
                if ( response!= null && response.IndexOf("+OK")>-1)
                {
                    txb.Text += response.Trim() + Environment.NewLine;
                    client_state = ClientState.Connected;
                    return true;
                }
                return false;
            }
            catch (Exception error)
            {
               
                MessageBox.Show(error.Message);
                return false;
            }
        }

        private bool Disconnect()
        {
            if (client_state != ClientState.Disconnected)
            {
         
                ssl_stream.Close();
                tcp_cl.Close();
                client_state = ClientState.Disconnected;
                return true;
            }
            else
            {
               return false;
            }
        }

        private string GetResponse()
        {
            try
            {
                byte[] buff = new byte[1024];
                String response = "";
                int count = 1;
                while (count!=0)
                {
                    count = ssl_stream.Read(buff, 0, buff.Length);
                    response += Encoding.ASCII.GetString(buff, 0, count);
                    if (response.IndexOf("\r\n") != -1)
                        break;
                }
                return response;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                return null;
            }
        }

        private bool Error(string response)
        {
            if (response.StartsWith("-"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool SendCommand(SslStream ssls, String command)
        {
            try
            {
                command += "\r\n";
                byte[] bufarr = Encoding.ASCII.GetBytes(command);
                ssls.Write(bufarr, 0, bufarr.Length);
                ssls.Flush();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        } 

        private string OneLineResponse(string command)
        {
            if (client_state == ClientState.Activated)
            {
                if (SendCommand(ssl_stream, command))
                    return GetResponse();
                else return null;
            }
            else return null;
        }

        private string MultiLineResponse(string command)
        {
            if (client_state == ClientState.Activated)
            {
                string ret ="";
                string response;
                if (SendCommand(ssl_stream, command))
                {
                    do
                    {
                        response= GetResponse();
                        ret+=response;
                    } while (response != ".\r\n" && response != "" && response.IndexOf("\r\n.\r\n") < 0);
                    return ret;
                }   
                else return null;
            }
            else return null;
        }


        private string USER(string command)
        {
                if (SendCommand(ssl_stream, command))
                {
                    string response=GetResponse();
                    if (!Error(response)) client_state = ClientState.Authorized;
                    return response;
                }
                else return null;
        }

        private string PASS(string command)
        {
                if (SendCommand(ssl_stream, command))
                {
                    string res = GetResponse();
                    if (!Error(res)) client_state = ClientState.Activated;
                        return res;
                }
                else return null;
        }

        public string Command_Manager(string command)
        {
            string response = null;
            string action = command.Substring(0, 4);
            switch (action)
            {
                case "USER":
                    response = USER(command);
                    break;
                case "PASS":
                    response = PASS(command);
                    break;
                case "QUIT":
                    response = OneLineResponse(command);
                    Disconnect();
                    break;
                case "LIST":
                case "RETR":
                    response = MultiLineResponse(command);
                    break;
                case "STAT":
                case "NOOP":
                case "DELE":
                case "RSET":
                    response = OneLineResponse(command);
                    break;
              
                default:
                    response = "Некорректная команда";
                    break;
            }
            return response;
        }
    }
}
