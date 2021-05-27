using System;
using System.Windows.Forms;
using NAudio.Wave;
using System.Diagnostics;
using NAudio.Utils;

namespace WhatDidISay
{
    internal partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        WaveIn _wavein;
        private CircularBuffer _circularBuffer;
        private byte[] _dataBuffer;
        internal Options Options { get; set; }

        private void OnStartBuffering_Click(object sender, EventArgs e)
        {
            _wavein?.Dispose();

            CreateWaveProvider();
            _wavein.DataAvailable += VuMeter;
            _wavein.DataAvailable += OnReceiveAudio;
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            ntfyIcon.BalloonTipText = string.Format(Resource.BufferingMinutesOfAudio, txtBufferSize);
            ntfyIcon.Visible = true;
        }

        void OnReceiveAudio(object sender, WaveInEventArgs e)
        {
            _circularBuffer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtBufferSize.Text = Options.BufferTimeInMinutes.ToString();
            cmbRecordingDevices.Items.Clear();
            cmbRecordingDevices.Enabled = false;
            btnStartBuffering.Enabled = false;

            for (int device = 0; device < WaveIn.DeviceCount; device++)
            {
                var capabilities = WaveIn.GetCapabilities(device);
                cmbRecordingDevices.Items.Add(capabilities.ProductName);
            }

            if (WaveIn.DeviceCount > 1)
            {
                cmbRecordingDevices.SelectedIndex = 0;
                cmbRecordingDevices.Enabled = true;
                btnStartBuffering.Enabled = true;
            }
        }


        private void OnComboDevices_Select(object sender, EventArgs e)
        {
            CreateWaveProvider();
            _wavein.DataAvailable += VuMeter;
        }

        private void CreateWaveProvider()
        {
            var bufferTimeInSeconds = int.Parse(txtBufferSize.Text)*60;
            var bufferSizeInBytes = Options.SampleRate*(Options.BitsPerSample/8)*Options.Channels*bufferTimeInSeconds;
            _circularBuffer = new CircularBuffer(bufferSizeInBytes);
            _dataBuffer = new byte[bufferSizeInBytes];

            _wavein = new WaveIn
            {
                WaveFormat = new WaveFormat(Options.SampleRate, Options.BitsPerSample, Options.Channels),
                BufferMilliseconds = 500,
                NumberOfBuffers = 3,
                DeviceNumber = cmbRecordingDevices.SelectedIndex,
            };
            _wavein.StartRecording();
        }

        private void VuMeter(object sender, WaveInEventArgs e)
        {            
            short maxvu = 0;
            for (int i = 0; i < e.BytesRecorded; i+=4)
            {
                var vu = (short)(e.Buffer[i + 1] *256 + e.Buffer[i]);
                if (vu > maxvu) maxvu = vu;
            }

            var vuValue = 96 + (int)Math.Max(20.0f * Math.Log10(maxvu / 32768.0f), -96.0f);
            vumeter.Value = vuValue+1;
            vumeter.Value = vuValue; 
        }

        private void OnNotifyIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ntfyIcon.Visible = false;
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                return;
            }

            ntfyIcon.Visible = false;
            var currentBufferSize = _circularBuffer.Count;
            _circularBuffer.Read(_dataBuffer, 0, currentBufferSize);
            var answer = saveRecording.ShowDialog(this);
            if (answer != DialogResult.Cancel)
            {
                using (var wfw = new WaveFileWriter(saveRecording.FileName, _wavein.WaveFormat))
                {
                    wfw.Write(_dataBuffer, 0, currentBufferSize);
                }
            }
            else
            {
                // TODO: Write back the data for later use
                // But note: there's additional data that may have been arrived in the meanwhile
                // _circularBuffer.Write(_dataBuffer, 0, currentBufferSize);
            }
            ntfyIcon.Visible = true;
        }
    }
}