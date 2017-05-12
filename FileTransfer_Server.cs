using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer_Server
{
    public partial class FileTransfer_Server : Form
    {
        private ArrayList nSockets;

        public string SaveFileName = string.Empty;
        private const int BufferSize = 1024;
        public string Status = string.Empty;
        public Thread T = null;
        private object sync_temp = new object();

        public FileTransfer_Server()
        {
            InitializeComponent();
        }

        private void pb_ShutdownButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FileTransfer_Server_Load(object sender, EventArgs e)
        {
            IPHostEntry IPHost = Dns.GetHostByName(Dns.GetHostName());
            lbl_IP.Text = IPHost.AddressList[0].ToString();
            nSockets = new ArrayList();

            ThreadStart Ts = new ThreadStart(StartReceiving);
            T = new Thread(Ts);
            T.Start();
        }

        public void StartReceiving()
        {
            ReceiveTCP(8080);
        }


        public void ReceiveTCP(int portN)
        {
            TcpListener Listener = null;
            try
            {
                Listener = new TcpListener(IPAddress.Any, portN);
                Listener.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            byte[] RecData = new byte[BufferSize];
            int RecBytes;

            for (;;)
            {
                TcpClient client = null;
                NetworkStream netstream = null;
                Status = string.Empty;
                try
                {
                    string message = "Aceitar arquivo recebido? ";
                    string caption = "Conexão solicitada";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    if (Listener.Pending())
                    {
                        client = Listener.AcceptTcpClient();
                        netstream = client.GetStream();
                        result = MessageBox.Show(message, caption, buttons);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            SaveFileDialog DialogSave = new SaveFileDialog();
                            DialogSave.Filter = "pdf files (*.pdf)|*.pdf|mp3 files (*.mp3)|*.mp3";
                            DialogSave.RestoreDirectory = true;
                            DialogSave.Title = "Onde deseja salvar o arquivo?";
                            DialogSave.InitialDirectory = @"C:/";

                            Action ac = () => { lock (sync_temp) { DialogSave.ShowDialog(); } };
                            Invoke(ac);

                            lock (sync_temp)
                            {
                                SaveFileName = DialogSave.FileName;
                            }

                            if (SaveFileName != string.Empty)
                            {
                                int totalrecbytes = 0;
                                FileStream Fs = new FileStream(SaveFileName, FileMode.OpenOrCreate, FileAccess.Write);
                                while ((RecBytes = netstream.Read(RecData, 0, RecData.Length)) > 0)
                                {
                                    Fs.Write(RecData, 0, RecBytes);
                                    totalrecbytes += RecBytes;
                                }
                                Fs.Close();
                            }
                           
                            netstream.Close();
                            client.Close();

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
