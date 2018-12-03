using System.ComponentModel;
using System.Windows.Forms;

namespace SharpProxy
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExternalPort = new System.Windows.Forms.TextBox();
            this.txtInternalPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbIPAddress = new System.Windows.Forms.ComboBox();
            this.chkRewriteHostHeaders = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxMenuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(11, 154);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(125, 154);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "S&top";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "External Port";
            // 
            // txtExternalPort
            // 
            this.txtExternalPort.Location = new System.Drawing.Point(11, 65);
            this.txtExternalPort.MaxLength = 7;
            this.txtExternalPort.Name = "txtExternalPort";
            this.txtExternalPort.Size = new System.Drawing.Size(189, 20);
            this.txtExternalPort.TabIndex = 3;
            this.txtExternalPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorts_KeyPress);
            // 
            // txtInternalPort
            // 
            this.txtInternalPort.Location = new System.Drawing.Point(11, 104);
            this.txtInternalPort.MaxLength = 7;
            this.txtInternalPort.Name = "txtInternalPort";
            this.txtInternalPort.Size = new System.Drawing.Size(189, 20);
            this.txtInternalPort.TabIndex = 5;
            this.txtInternalPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorts_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Internal Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Your IP Address";
            // 
            // cmbIPAddress
            // 
            this.cmbIPAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIPAddress.FormattingEnabled = true;
            this.cmbIPAddress.Location = new System.Drawing.Point(11, 25);
            this.cmbIPAddress.Name = "cmbIPAddress";
            this.cmbIPAddress.Size = new System.Drawing.Size(189, 21);
            this.cmbIPAddress.TabIndex = 8;
            // 
            // chkRewriteHostHeaders
            // 
            this.chkRewriteHostHeaders.AutoSize = true;
            this.chkRewriteHostHeaders.Checked = true;
            this.chkRewriteHostHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRewriteHostHeaders.Location = new System.Drawing.Point(13, 131);
            this.chkRewriteHostHeaders.Name = "chkRewriteHostHeaders";
            this.chkRewriteHostHeaders.Size = new System.Drawing.Size(188, 17);
            this.chkRewriteHostHeaders.TabIndex = 9;
            this.chkRewriteHostHeaders.Text = "&Rewrite host headers (IIS Express)";
            this.chkRewriteHostHeaders.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Sharp";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuRestore,
            this.ctxMenuClose});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(114, 48);
            // 
            // ctxMenuRestore
            // 
            this.ctxMenuRestore.Name = "ctxMenuRestore";
            this.ctxMenuRestore.Size = new System.Drawing.Size(113, 22);
            this.ctxMenuRestore.Text = "Restore";
            // 
            // ctxMenuClose
            // 
            this.ctxMenuClose.Name = "ctxMenuClose";
            this.ctxMenuClose.Size = new System.Drawing.Size(113, 22);
            this.ctxMenuClose.Text = "Close";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 185);
            this.Controls.Add(this.chkRewriteHostHeaders);
            this.Controls.Add(this.cmbIPAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInternalPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtExternalPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SharpProxy";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Label label1;
        private TextBox txtExternalPort;
        private TextBox txtInternalPort;
        private Label label2;
        private Label label3;
        private ComboBox cmbIPAddress;
        private CheckBox chkRewriteHostHeaders;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip ctxMenu;
        private ToolStripMenuItem ctxMenuRestore;
        private ToolStripMenuItem ctxMenuClose;
    }
}

