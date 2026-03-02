using DeviantartDownloader.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviantartDownloader.Models {
    public class SelectionMode {
        public string DisplayName { get; set; }
        public DeviantType? DeviantType { get; set; }
        public DownloadStatus? Status { get; set; }
        public SelectionMode(string displayName,DeviantType? type=null) {
            DisplayName=displayName;
            DeviantType=type;
        }
        public SelectionMode(string displayName, DownloadStatus? status = null) {
            DisplayName = displayName;
            Status = Status;
        }
    }
}
