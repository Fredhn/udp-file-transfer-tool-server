namespace FileTransfer_Server
{
    partial class FileTransfer_Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileTransfer_Server));
            this.pnl_Main = new System.Windows.Forms.Panel();
            this.pnl_Main2 = new System.Windows.Forms.Panel();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.lbl_localhostIPTitle = new System.Windows.Forms.Label();
            this.pb_ipConnection = new System.Windows.Forms.PictureBox();
            this.pnl_MainSeparador = new System.Windows.Forms.Panel();
            this.pb_ShutdownButton = new System.Windows.Forms.PictureBox();
            this.listbox_Connections = new System.Windows.Forms.ListBox();
            this.lbl_MainTitle = new System.Windows.Forms.Label();
            this.pnl_Main.SuspendLayout();
            this.pnl_Main2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ipConnection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ShutdownButton)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Main
            // 
            this.pnl_Main.BackColor = System.Drawing.Color.Firebrick;
            this.pnl_Main.Controls.Add(this.pnl_Main2);
            this.pnl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Main.Location = new System.Drawing.Point(0, 0);
            this.pnl_Main.Name = "pnl_Main";
            this.pnl_Main.Size = new System.Drawing.Size(284, 262);
            this.pnl_Main.TabIndex = 0;
            // 
            // pnl_Main2
            // 
            this.pnl_Main2.BackColor = System.Drawing.Color.SeaGreen;
            this.pnl_Main2.Controls.Add(this.lbl_IP);
            this.pnl_Main2.Controls.Add(this.lbl_localhostIPTitle);
            this.pnl_Main2.Controls.Add(this.pb_ipConnection);
            this.pnl_Main2.Controls.Add(this.pnl_MainSeparador);
            this.pnl_Main2.Controls.Add(this.pb_ShutdownButton);
            this.pnl_Main2.Controls.Add(this.listbox_Connections);
            this.pnl_Main2.Controls.Add(this.lbl_MainTitle);
            this.pnl_Main2.Location = new System.Drawing.Point(5, 5);
            this.pnl_Main2.Name = "pnl_Main2";
            this.pnl_Main2.Size = new System.Drawing.Size(274, 252);
            this.pnl_Main2.TabIndex = 0;
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IP.ForeColor = System.Drawing.Color.Transparent;
            this.lbl_IP.Location = new System.Drawing.Point(84, 227);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(0, 18);
            this.lbl_IP.TabIndex = 10;
            // 
            // lbl_localhostIPTitle
            // 
            this.lbl_localhostIPTitle.AutoSize = true;
            this.lbl_localhostIPTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_localhostIPTitle.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_localhostIPTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lbl_localhostIPTitle.Location = new System.Drawing.Point(84, 204);
            this.lbl_localhostIPTitle.Name = "lbl_localhostIPTitle";
            this.lbl_localhostIPTitle.Size = new System.Drawing.Size(107, 20);
            this.lbl_localhostIPTitle.TabIndex = 9;
            this.lbl_localhostIPTitle.Text = "Localhost IP:";
            // 
            // pb_ipConnection
            // 
            this.pb_ipConnection.Image = global::FileTransfer_Server.Properties.Resources.Network_Internet_Connection_icon;
            this.pb_ipConnection.Location = new System.Drawing.Point(26, 201);
            this.pb_ipConnection.Name = "pb_ipConnection";
            this.pb_ipConnection.Size = new System.Drawing.Size(48, 48);
            this.pb_ipConnection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_ipConnection.TabIndex = 8;
            this.pb_ipConnection.TabStop = false;
            // 
            // pnl_MainSeparador
            // 
            this.pnl_MainSeparador.BackColor = System.Drawing.Color.Firebrick;
            this.pnl_MainSeparador.Location = new System.Drawing.Point(-4, 196);
            this.pnl_MainSeparador.Name = "pnl_MainSeparador";
            this.pnl_MainSeparador.Size = new System.Drawing.Size(280, 5);
            this.pnl_MainSeparador.TabIndex = 7;
            // 
            // pb_ShutdownButton
            // 
            this.pb_ShutdownButton.Image = global::FileTransfer_Server.Properties.Resources.power_2_icon__1_;
            this.pb_ShutdownButton.Location = new System.Drawing.Point(247, 3);
            this.pb_ShutdownButton.Name = "pb_ShutdownButton";
            this.pb_ShutdownButton.Size = new System.Drawing.Size(24, 24);
            this.pb_ShutdownButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_ShutdownButton.TabIndex = 4;
            this.pb_ShutdownButton.TabStop = false;
            this.pb_ShutdownButton.Click += new System.EventHandler(this.pb_ShutdownButton_Click);
            // 
            // listbox_Connections
            // 
            this.listbox_Connections.FormattingEnabled = true;
            this.listbox_Connections.Location = new System.Drawing.Point(43, 49);
            this.listbox_Connections.Name = "listbox_Connections";
            this.listbox_Connections.Size = new System.Drawing.Size(188, 134);
            this.listbox_Connections.TabIndex = 2;
            // 
            // lbl_MainTitle
            // 
            this.lbl_MainTitle.AutoSize = true;
            this.lbl_MainTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MainTitle.Font = new System.Drawing.Font("Bookman Old Style", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MainTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lbl_MainTitle.Location = new System.Drawing.Point(43, 14);
            this.lbl_MainTitle.Name = "lbl_MainTitle";
            this.lbl_MainTitle.Size = new System.Drawing.Size(188, 25);
            this.lbl_MainTitle.TabIndex = 1;
            this.lbl_MainTitle.Text = "File Transfer Tool";
            // 
            // FileTransfer_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pnl_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileTransfer_Server";
            this.Text = "File Transfer Tool - Server";
            this.Load += new System.EventHandler(this.FileTransfer_Server_Load);
            this.pnl_Main.ResumeLayout(false);
            this.pnl_Main2.ResumeLayout(false);
            this.pnl_Main2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ipConnection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ShutdownButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Main;
        private System.Windows.Forms.Panel pnl_Main2;
        private System.Windows.Forms.ListBox listbox_Connections;
        private System.Windows.Forms.Label lbl_MainTitle;
        private System.Windows.Forms.PictureBox pb_ShutdownButton;
        private System.Windows.Forms.PictureBox pb_ipConnection;
        private System.Windows.Forms.Panel pnl_MainSeparador;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.Label lbl_localhostIPTitle;
    }
}

