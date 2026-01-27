using DeviantartDownloader.Command;
using DeviantartDownloader.Models;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DeviantartDownloader.ViewModels {
    public class SettingViewModel : DialogViewModel {
        private IDialogCoordinator _dialogCoordinator;

        private string _headerString;
        public string HeaderString {
            get {
                return _headerString;
            }
            set {
                _headerString = value;
            }
        }

        public string _queueLimit;
        public string QueueLimit {
            get {
                return _queueLimit;
            }
            set {
                _queueLimit = value;
            }
        }

        private string _folderSearchWaitTime;
        public string FolderSearchWaitTime {
            get {
                return _folderSearchWaitTime;
            }
            set {
                _folderSearchWaitTime = value;
            }
        }

        private string _deviantSearchWaitTime;
        public string DeviantSearchWaitTime {
            get {
                return _deviantSearchWaitTime;
            }
            set {
                _deviantSearchWaitTime = value;
            }
        }

        private string _deviantDownloadWaitTime;
        public string DeviantDownloadWaitTime {
            get {
                return _deviantDownloadWaitTime;
            }
            set {
                _deviantDownloadWaitTime = value;
            }
        }

        private bool _downloadDescription;
        public bool DownloadDescription {
            get {
                return _downloadDescription;
            }
            set {
                _downloadDescription = value;
                if(!value)
                    _descriptionOnly = false;
                OnPropertyChanged(nameof(DownloadDescription));
                OnPropertyChanged(nameof(DescriptionOnly));
            }
        }

        private bool _descriptionOnly;
        public bool DescriptionOnly {
            get {
                return _descriptionOnly;
            }
            set {
                _descriptionOnly = value;
            }
        }
      
        public RelayCommand SaveCommand {
            get; set;
        }
        public RelayCommand UserKeyInfoCommand {
            get; set;
        }
        public RelayCommand DescriptionInfoCommand {
            get; set;
        }
        public SettingViewModel(AppSetting appSetting, IDialogCoordinator dialogCoordinator) {
            _dialogCoordinator= dialogCoordinator;
            _headerString = appSetting.HeaderString;
            _queueLimit = appSetting.QueueLimit.ToString();
            _deviantSearchWaitTime = appSetting.UserKeySearchDeviantWaitTime.ToString();
            _deviantDownloadWaitTime = appSetting.UserKeyDownloadDeviantWaitTime.ToString();
            _folderSearchWaitTime=appSetting.UserKeySearchFolderWaitTime.ToString();
            _downloadDescription=appSetting.DownloadArtDescription;
            _descriptionOnly = appSetting.DownloadArtDescriptionOnly;
            SaveCommand = new RelayCommand(async o => {
                var Result = await _dialogCoordinator.ShowMessageAsync(this, "ALERT", "Are you sure you want to save?", MessageDialogStyle.AffirmativeAndNegative);
                if(Result == MessageDialogResult.Affirmative) {
                    Success = true;
                    Dialog.Close();
                }
            }, o => QueueLimit != "" && _deviantSearchWaitTime != "" && _deviantDownloadWaitTime != "" && _folderSearchWaitTime != "");
            UserKeyInfoCommand = new RelayCommand(async o => {
                var Result = await _dialogCoordinator.ShowMessageAsync(this, "INFORMATION", "Setting wait time for each request when using user key.\n*Note: search request will be send multiple time based on gallery size");
            }, o => true);
            DescriptionInfoCommand = new RelayCommand(async o => {
                var Result = await _dialogCoordinator.ShowMessageAsync(this, "INFORMATION", "Saving image description as a HTML file.");
            }, o => true);
        }
    }
}
