using DeviantartDownloader.Command;
using DeviantartDownloader.Models;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DeviantartDownloader.ViewModels {
    public class MoreSelectViewModel : DialogViewModel {
        private IDialogCoordinator _dialogCoordinator;
        public string BeforeYear { 
            get;set; 
        } = "2005";
        public string BeforeMonth {
            get; set;
        } = "1";
        public string BeforeDay {
            get; set;
        } = "1";
        public string AfterYear {
            get; set;
        }
        public string AfterMonth {
            get; set;
        }
        public string AfterDay {
            get; set;
        }
        public string AuthorName {
            get; set;
        } = "";
        public string Title {
            get; set;
        } = "";
        private List<Deviant> _deviants;
        public RelayCommand SelectCommand {
            get; set;
        }
        public MoreSelectViewModel(IDialogCoordinator dialogCoordinator,List<Deviant> deviants) {
            _deviants = deviants;
            _dialogCoordinator = dialogCoordinator;
            var LatestDate = DateTime.Now;
            AfterYear=LatestDate.Year.ToString();
            AfterMonth=LatestDate.Month.ToString();
            AfterDay=LatestDate.Day.ToString();
            SelectCommand= new RelayCommand(async o => {
                await Select();
            }, o => true);
        }
        private async Task Select() {
            try {
                var beforeDate = new DateTime(int.Parse(BeforeYear), int.Parse(BeforeMonth), int.Parse(BeforeDay), 0, 0, 0);
                var afterDate = new DateTime(int.Parse(AfterYear), int.Parse(AfterMonth), int.Parse(AfterDay), 23, 59, 59);
                var list = _deviants
                            .Where(d => d.Author.Username.ToLower().Contains(AuthorName.ToLower()))
                            .Where(d => d.Title.ToLower().Contains(Title.ToLower()))
                            .Where(d => d.PublishDate >= beforeDate && d.PublishDate <= afterDate)
                            .ToList();
                foreach(var deviant in list) {
                    deviant.IsSelected = true;
                }
                Dialog.Close();
            }
            catch {
                await _dialogCoordinator.ShowMessageAsync(this, "ERROR", "Something went wrong!", MessageDialogStyle.Affirmative);
            }
        }
    }
}
