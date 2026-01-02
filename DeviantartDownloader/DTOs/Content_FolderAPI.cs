using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartDownloader.DTOs
{
    public record Content_FolderAPI
    {
        public string folderid { get; set; }
        public string name { get; set; }
        public int size { get; set; }
    }
}
