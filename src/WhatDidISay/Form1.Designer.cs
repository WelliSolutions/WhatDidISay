namespace WhatDidISay
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
            this.lblBufferSize = new System.Windows.Forms.Label();
            this.txtBufferSize = new System.Windows.Forms.TextBox();
            this.lblBufferSizeUnit = new System.Windows.Forms.Label();
            this.btnStartBuffering = new System.Windows.Forms.Button();
            this.vumeter = new System.Windows.Forms.ProgressBar();
            this.cmbRecordingDevices = new System.Windows.Forms.ComboBox();
            this.lblDevice = new System.Windows.Forms.Label();
            this.ntfyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.saveRecording = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBufferSize
            // 
            resources.ApplyResources(this.lblBufferSize, "lblBufferSize");
            this.lblBufferSize.Name = "lblBufferSize";
            // 
            // txtBufferSize
            // 
            resources.ApplyResources(this.txtBufferSize, "txtBufferSize");
            this.txtBufferSize.Name = "txtBufferSize";
            // 
            // lblBufferSizeUnit
            // 
            resources.ApplyResources(this.lblBufferSizeUnit, "lblBufferSizeUnit");
            this.lblBufferSizeUnit.Name = "lblBufferSizeUnit";
            // 
            // btnStartBuffering
            // 
            resources.ApplyResources(this.btnStartBuffering, "btnStartBuffering");
            this.btnStartBuffering.Name = "btnStartBuffering";
            this.btnStartBuffering.UseVisualStyleBackColor = true;
            this.btnStartBuffering.Click += new System.EventHandler(this.OnStartBuffering_Click);
            // 
            // vumeter
            // 
            resources.ApplyResources(this.vumeter, "vumeter");
            this.vumeter.Maximum = 97;
            this.vumeter.Name = "vumeter";
            // 
            // cmbRecordingDevices
            // 
            this.cmbRecordingDevices.FormattingEnabled = true;
            resources.ApplyResources(this.cmbRecordingDevices, "cmbRecordingDevices");
            this.cmbRecordingDevices.Name = "cmbRecordingDevices";
            this.cmbRecordingDevices.SelectedIndexChanged += new System.EventHandler(this.OnComboDevices_Select);
            // 
            // lblDevice
            // 
            resources.ApplyResources(this.lblDevice, "lblDevice");
            this.lblDevice.Name = "lblDevice";
            // 
            // ntfyIcon
            // 
            resources.ApplyResources(this.ntfyIcon, "ntfyIcon");
            this.ntfyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnNotifyIcon_Click);
            // 
            // saveRecording
            // 
            this.saveRecording.DefaultExt = "wav";
            this.saveRecording.FileName = "Voice Recording";
            resources.ApplyResources(this.saveRecording, "saveRecording");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnStartBuffering;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.cmbRecordingDevices);
            this.Controls.Add(this.vumeter);
            this.Controls.Add(this.btnStartBuffering);
            this.Controls.Add(this.lblBufferSizeUnit);
            this.Controls.Add(this.txtBufferSize);
            this.Controls.Add(this.lblBufferSize);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBufferSize;
        private System.Windows.Forms.TextBox txtBufferSize;
        private System.Windows.Forms.Label lblBufferSizeUnit;
        private System.Windows.Forms.Button btnStartBuffering;
        private System.Windows.Forms.ProgressBar vumeter;
        private System.Windows.Forms.ComboBox cmbRecordingDevices;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.NotifyIcon ntfyIcon;
        private System.Windows.Forms.SaveFileDialog saveRecording;
        private System.Windows.Forms.Label label1;
    }
}

