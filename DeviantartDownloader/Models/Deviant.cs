using DeviantartDownloader.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeviantartDownloader.Models {
    public class Deviant: ObservableObject {
        public string Id { get; set; }
        public Author? Author {  get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public MediaContent? Content { get; set; }
        public ICollection<MediaContent>? Video { get; set; }
        public DeviantType Type { get; set; }
        public bool Downloadable { get; set; }
        public DateTime PublishDate { get; set; }
        public bool ContentLocked { get; set; }
        public string FileSize { get; set; }
        public string HaveOriginalFile {
            get {
                return Downloadable ? "Yes" : "No";
            } 
        }
        private float _percent=0;
        public float Percent {
            get {
                return _percent;
            }
            set {
                _percent = value;
                OnPropertyChanged(nameof(Percent));
                OnPropertyChanged(nameof(DisplayPercent));
            }
        }
        public DownloadStatus _status= DownloadStatus.Waiting;
        public DownloadStatus Status {
            get {
                return _status;
            }
            set {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private string _downloadSpeed="";
        public string DownloadSpeed {
            get {
                return _downloadSpeed;
            }
            set {
                _downloadSpeed = value;
                OnPropertyChanged(nameof(DownloadSpeed));
            }
        }
        public string DisplayPercent {
            get {
                return $"{_percent:0.##}%";
            }
        }
        private bool _isSeleted = false;
        public bool IsSelected {
            get {
                return _isSeleted;
            }
            set {
                _isSeleted = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }
}
