using DeviantartDownloader.Function;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DeviantartDownloader.Extension {
    public static class StreamExtensions {
        public static async Task CopyToAsync(this Stream source, Stream destination, int bufferSize, IProgress<string> speed=null, IProgress<float> progress = null, CancellationToken cancellationToken = default) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (!source.CanRead)
                throw new ArgumentException("Has to be readable", nameof(source));
            if (destination == null)
                throw new ArgumentNullException(nameof(destination));
            if (!destination.CanWrite)
                throw new ArgumentException("Has to be writable", nameof(destination));
            if (bufferSize < 0)
                throw new ArgumentOutOfRangeException(nameof(bufferSize));

            var buffer = new byte[bufferSize];
            long totalBytesRead = 0;
            int bytesRead;
            speed.Report(GlobalFuction.FormatSpeed(0));
            Stopwatch sw = Stopwatch.StartNew();
            while ((bytesRead = await source.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)) != 0) {
                await destination.WriteAsync(buffer, 0, bytesRead, cancellationToken).ConfigureAwait(false);
                totalBytesRead += bytesRead;
                double speedInBytesPerSecond = totalBytesRead / sw.Elapsed.TotalSeconds;
                progress?.Report(totalBytesRead);
                speed?.Report(GlobalFuction.FormatSpeed(speedInBytesPerSecond));
            }
            sw.Stop();
        }
        
    }
}
