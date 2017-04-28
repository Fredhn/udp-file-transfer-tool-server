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

        //private void FileTransfer_Server_Load(object sender, EventArgs e)
        //{
        //    IPHostEntry IPHost = Dns.GetHostByName(Dns.GetHostName());
        //    lbl_IP.Text = IPHost.AddressList[0].ToString();
        //    nSockets = new ArrayList();
        //    Thread thdListener = new Thread(new ThreadStart(listenerThread));
        //    thdListener.Start();
        //}

        //public void listenerThread()
        //{

        //    TcpListener tcpListener = new TcpListener(8080);
        //    tcpListener.Start();
        //    while (true)
        //    {
        //        Socket handlerSocket = tcpListener.AcceptSocket();
        //        if (handlerSocket.Connected)
        //        {
        //            Control.CheckForIllegalCrossThreadCalls = false;
        //            listbox_Connections.Items.Add(handlerSocket.RemoteEndPoint.ToString() + " connected.");
        //            lock (this)
        //            {
        //                nSockets.Add(handlerSocket);
        //            }
        //            ThreadStart thdstHandler = new ThreadStart(handlerThread);
        //            Thread thdHandler = new Thread(thdstHandler);
        //            thdHandler.Start();
        //        }
        //    }
        //}
        //public void handlerThread()
        //{
        //    Socket handlerSocket = (Socket)nSockets[nSockets.Count - 1];
        //    NetworkStream networkStream = new NetworkStream(handlerSocket);
        //    int thisRead = 0;
        //    int blockSize = 1024;
        //    Byte[] dataByte = new Byte[blockSize];
        //    try
        //    { 
        //        lock (this)
        //        {
        //            // Only one process can access
        //            // the same file at any given time
        //            Stream fileStream = File.OpenWrite("C:\\Users\\FRED\\Gabi\\Documents\\SubmittedFile.pdf");
        //            while (true)
        //            {
        //                thisRead = networkStream.Read(dataByte, 0, blockSize);
        //                fileStream.Write(dataByte, 0, thisRead);
        //                if (thisRead == 0) break;
        //            }
        //            fileStream.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        //netstream.Close();
        //    }

        //    listbox_Connections.Items.Add("Arquivo salvo.");
        //    handlerSocket = null;
        //}

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
                        //Status = "Connected to a client\n";
                        //Task.Factory.StartNew(() =>
                        //{
                        //    this.BeginInvoke(new Action(() =>
                        //    {
                        //        listbox_Connections.Items.Add(Status);
                        //    }));
                        //});
                        //listbox_Connections.Items.Add(Status);
                        result = MessageBox.Show(message, caption, buttons);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            SaveFileDialog DialogSave = new SaveFileDialog();
                            DialogSave.Filter = "pdf files (*.pdf)|*.pdf|mp3 files (*.mp3)|*.mp3";
                            DialogSave.RestoreDirectory = true;
                            DialogSave.Title = "Onde deseja salvar o arquivo?";
                            DialogSave.InitialDirectory = @"C:/";

                            //if (DialogSave.ShowDialog() == DialogResult.OK)
                            //    SaveFileName = DialogSave.FileName;

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
                                //listbox_Connections.Items.Add("Recebido: " + SaveFileName.ToString());
                            }
                           
                            netstream.Close();
                            client.Close();

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //netstream.Close();
                }
            }
        }
    }
}
