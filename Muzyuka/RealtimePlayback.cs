using System;
using NAudio.Dsp;
using NAudio.Wave;

namespace Muzyuka
{
    public class RealTimePlayback
    {
        public WasapiLoopbackCapture _capture;
        private object _lock;
        public int _fftPos;
        public int _fftLength;
        public Complex[] _fftBuffer;
        public float[] _lastFftBuffer;
        public bool _fftBufferAvailable;
        public int _m;

        public int newFftLength;

        public RealTimePlayback()
        {
            this._lock = new object();

            this._capture = new WasapiLoopbackCapture();
            this._capture.DataAvailable += this.DataAvailable;

            this._fftLength = 64; // must be a multiple of two
            this._m = (int)Math.Log(this._fftLength, 2.0);
            this._fftBuffer = new Complex[this._fftLength];
            this._lastFftBuffer = new float[this._fftLength];
        }

        public WaveFormat Format
        {
            get
            {
                return this._capture.WaveFormat;
            }
        }

        private float[] ConvertByteToFloat(byte[] array, int length)
        {
            int samplesNeeded = length / 4;
            float[] floatArr = new float[samplesNeeded];

            for (int i = 0; i < samplesNeeded; i++)
            {
                floatArr[i] = BitConverter.ToSingle(array, i * 4);
            }

            return floatArr;
        }

        private void DataAvailable(object sender, WaveInEventArgs e)
        {
            // Convert byte[] to float[].
            float[] data = ConvertByteToFloat(e.Buffer, e.BytesRecorded);

            // For all data. Skip right channel on stereo (i += this.Format.Channels).
            for (int i = 0; i < data.Length; i += this.Format.Channels)
            {
                this._fftBuffer[_fftPos].X = (float)(data[i] * FastFourierTransform.HannWindow(_fftPos, _fftLength));
                this._fftBuffer[_fftPos].Y = 0;
                this._fftPos++;

                if (this._fftPos >= this._fftLength)
                {
                    this._fftPos = 0;

                    // Copy to buffer.
                    lock (this._lock)
                    {
                        for (int c = 0; c < this._fftLength; c++)
                        {
                            this._lastFftBuffer[c] = (float)Math.Sqrt(this._fftBuffer[c].X * this._fftBuffer[c].X + this._fftBuffer[c].Y * this._fftBuffer[c].Y);
                        }

                        this._fftBufferAvailable = true;
                    }
                }
            }
        }

        public void Start()
        {
            this._capture.StartRecording();
        }

        public void Stop()
        {
            this._capture.StopRecording();
        }

        public bool GetFFTData(float[] fftDataBuffer)
        {
            lock (this._lock)
            {
                // Use last available buffer.
                if (this._fftBufferAvailable)
                {
                    this._lastFftBuffer.CopyTo(fftDataBuffer, 0);
                    this._fftBufferAvailable = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
