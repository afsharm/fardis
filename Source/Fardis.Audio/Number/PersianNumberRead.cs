using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NAudio.Wave;

namespace Fardis.Audio.Number
{
    public class PersianNumberRead
    {
        public static Stream ReadPersianNumber(int number, string tempDirectory)
        {
            if (number > 99 || number < 1)
                return
                    Assembly.GetExecutingAssembly().GetManifestResourceStream(
                        "Fardis.Audio.Wave.Invalid.wav");

            var reminder = number % 10;

            if (number <= 20 || reminder == 0)
                return PrepareSingle(number, tempDirectory);

            int quotient = number / 10;
            var firstPart = quotient * 10;

            var fileName = Concatenate(new[]
                {                    
                    Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    string.Format("Fardis.Audio.Wave.{0}.wav", firstPart)),
                    Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    "Fardis.Audio.Wave.And.wav"),
                    Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    string.Format("Fardis.Audio.Wave.{0}.wav", reminder)),
                }, tempDirectory);

            var memStream = new MemoryStream();
            using (var fileStream = File.OpenRead(fileName))
            {
                memStream.SetLength(fileStream.Length);
                fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);
            }

            return memStream;
        }

        private static Stream PrepareSingle(int number, string tempDirectory)
        {
            return
                Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    string.Format("Fardis.Audio.Wave.{0}.wav", number));
        }

        private static string Concatenate(IEnumerable<Stream> sourceFiles, string tempDirectory)
        {
            var buffer = new byte[1024];
            WaveFileWriter waveFileWriter = null;
            var filename = Path.Combine(tempDirectory, string.Format("{0}.wav", Guid.NewGuid()));

            try
            {
                foreach (var sourceFile in sourceFiles)
                {
                    using (var reader = new WaveFileReader(sourceFile))
                    {
                        if (waveFileWriter == null)
                        {
                            // first time in create new Writer
                            waveFileWriter = new WaveFileWriter(filename, reader.WaveFormat);
                        }
                        else
                        {
                            if (!reader.WaveFormat.Equals(waveFileWriter.WaveFormat))
                            {
                                throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
                            }
                        }

                        int read;
                        while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            waveFileWriter.Write(buffer, 0, read);
                        }
                    }
                }
            }
            finally
            {
                if (waveFileWriter != null)
                {
                    waveFileWriter.Dispose();
                }
            }

            return filename;
        }
    }
}
