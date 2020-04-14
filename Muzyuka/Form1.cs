using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Dsp;
using NAudio.Wave.SampleProviders;

namespace Muzyuka
{
    public partial class Form1 : Form
    {
        public WaveOut output = new WaveOut();
        public RealTimePlayback playback;
        public AudioFileReader audioReader;
        public List<short> unanalyzed = new List<short>();

        public Form1()
        {
            InitializeComponent();
            trackBarRefreshRate_Scroll(trackBarRefreshRate, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            if (output != null)
                output.Stop();

            audioReader = new AudioFileReader(openFileDialog.FileName);
            output.Init(audioReader);
            output.Play();

            if (playback != null)
                playback.Stop();

            playback = new RealTimePlayback();
            playback.Start();
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            if (output != null)
            {
                output.Volume = ((TrackBar)sender).Value / 100f;
            }
        }

        private void trackBarRefreshRate_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar) sender;
            timerRender.Interval = trackBar.Maximum - trackBar.Value + 1;
        }

        private void visual_Paint(object sender, PaintEventArgs e)
        {
            PictureBox panel = (PictureBox) sender;
            if (playback == null)
                return;

            float[] fft = new float[playback._fftLength];
            playback.GetFFTData(fft);

            Point[] points = new Point[fft.Length * 2];
            for (int i = 0; i < fft.Length; i++)
            {
                int x = i * panel.Width / 2 / playback._fftLength;
                int y = (int)(fft[i] * panel.Height);
                points[i] = new Point(x, panel.Height /2 - y);
                points[i + fft.Length] = new Point(x + panel.Width / 2, panel.Height / 2 + y);
            }

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.White, 3);

            g.DrawLines(pen, points);
            //g.DrawBeziers(pen, points);
        }

        private void timerRender_Tick(object sender, EventArgs e)
        {
            visual.Invalidate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (playback != null)
                playback.Stop();
            if (output != null)
                output.Stop();
        }
    }
}
