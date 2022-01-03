using System;
using System.IO;

namespace DarkOFDM
{
    public static class Wav
    {
        public static void WriteWavHeader(Stream writeStream)
        {
            byte[] wavHeader = new byte[44];
            //RIFF
            writeStream.WriteByte((byte)'R');
            writeStream.WriteByte((byte)'I');
            writeStream.WriteByte((byte)'F');
            writeStream.WriteByte((byte)'F');
            //LENGTH
            writeStream.WriteByte(0);
            writeStream.WriteByte(0);
            writeStream.WriteByte(0);
            writeStream.WriteByte(0);
            //WAVE
            writeStream.WriteByte((byte)'W');
            writeStream.WriteByte((byte)'A');
            writeStream.WriteByte((byte)'V');
            writeStream.WriteByte((byte)'E');
            //FMT
            writeStream.WriteByte((byte)'f');
            writeStream.WriteByte((byte)'m');
            writeStream.WriteByte((byte)'t');
            writeStream.WriteByte((byte)' ');
            //FMT LENGTH
            writeStream.WriteByte(16);
            writeStream.WriteByte(0);
            writeStream.WriteByte(0);
            writeStream.WriteByte(0);
            //TYPE
            writeStream.WriteByte(1);
            writeStream.WriteByte(0);
            //CHANNELS
            writeStream.WriteByte(1);
            writeStream.WriteByte(0);
            //SAMPLE RATE
            uint sampleRate = 48000;
            writeStream.Write(BitConverter.GetBytes(sampleRate), 0, 4);
            //Sample Rate * BytesPerSample * Channels.
            uint bytesPerSampleRate = sampleRate * 2 * 1;
            writeStream.Write(BitConverter.GetBytes(bytesPerSampleRate), 0, 4);
            //Bytes per sample*channels
            writeStream.WriteByte(2);
            writeStream.WriteByte(0);
            //Bits per sample
            writeStream.WriteByte(16);
            writeStream.WriteByte(0);
            //data
            writeStream.WriteByte((byte)'d');
            writeStream.WriteByte((byte)'a');
            writeStream.WriteByte((byte)'t');
            writeStream.WriteByte((byte)'a');
            writeStream.WriteByte(0);
            writeStream.WriteByte(0);
            writeStream.WriteByte(0);
            writeStream.WriteByte(0);
            writeStream.Flush();
        }

        public static void WriteWavLength()
        {
            Stream fs = File.Open("out.wav", FileMode.Open);
            fs.Seek(4, SeekOrigin.Begin);
            int fileLength = (int)fs.Length;
            fs.Write(BitConverter.GetBytes(fileLength - 8), 0, 4);
            fs.Seek(40, SeekOrigin.Begin);
            fs.Write(BitConverter.GetBytes(fileLength - 44), 0, 4);
            fs.Close();
        }
    }
}