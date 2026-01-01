using DeviantartDownloader.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartDownloader.DTOs
{
    public record DeviantAPIContent
    {
        public string deviationid { get; set; }
        public AuthorAPIContent author { get; set; }
        public string? url { get; set; }
        public string? title { get; set; }
        public MediaAPIContent? content { get; set; }
        public ICollection<MediaAPIContent>? videos { get; set; }
        public string? excerpt { get; set; }
        public bool? is_downloadable { get; set; }
    }
}
