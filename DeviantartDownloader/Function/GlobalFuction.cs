using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartDownloader.Function {
    static class GlobalFuction {
        public static string FormatBytes(int bytes) {
            if(bytes == 0)
                return "";

            string[] suffixes = { "Bytes", "KB", "MB", "GB"};
            int counter = 0;
            decimal number = (decimal)bytes;
            while(Math.Round(number / 1024) >= 1) {
                number = number / 1024;
                counter++;
            }

            return $"{number:n2} {suffixes[counter]}";
        }
        public static string FormatSpeed(double bytesPerSecond) {
            const double KB = 1024;
            const double MB = KB * 1024;
            const double GB = MB * 1024;

            if(bytesPerSecond >= GB)
                return $"{bytesPerSecond / GB:F2} GB/s";

            if(bytesPerSecond >= MB)
                return $"{bytesPerSecond / MB:F2} MB/s";

            if(bytesPerSecond >= KB)
                return $"{bytesPerSecond / KB:F2} KB/s";

            return $"{bytesPerSecond:F0} B/s";
        }
    }
}
