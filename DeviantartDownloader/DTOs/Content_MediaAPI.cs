using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartDownloader.DTOs
{
    public record Content_MediaAPI
    {
        public string? src { get; set; }
        public int? filesize { get; set; }
        public string? quality { get; set; }
    }
}
