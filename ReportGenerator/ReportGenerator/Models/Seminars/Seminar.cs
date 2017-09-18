using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Seminar : INotifyPropertyChanged
    {
        private int _id;
        private string _SeminarName;
        private int _typeid;
        private int _classificationid;
        private string _venue;
        private string _date;

        public int Id{
            get => _id;
            set
            {
                if(value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }
        public string SeminarName {
            get => _SeminarName;
            set
            {
                if (value != _SeminarName)
                {
                    _SeminarName = value;
                    NotifyPropertyChanged("SeminarName");
                }
            }
        }
        public string Type {
            get => SeminarTypeViewModel.getType(Typeid); }
        public string Classification {
            get => SeminarClassificationViewModel.getClassification(Classificationid);}
        public string Venue {
            get => _venue;
            set
            {
                if (value != _venue)
                {
                    _venue = value;
                    NotifyPropertyChanged("Venue");
                }
            }
        }
        public string Date {
            get => _date;
            set
            {
                if (value != _date)
                {
                    _date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }
        public int Typeid {
            get => _typeid;
            set
            {
                if (value != _typeid)
                {
                    _typeid = value;
                    NotifyPropertyChanged("Typeid");
                }
            }
        }
        public int Classificationid {
            get => _classificationid;
            set
            {
                if (value != _classificationid)
                {
                    _classificationid = value;
                    NotifyPropertyChanged("Classificationid");
                }
            }
        }
        public List<Faculty> Attendance { get => SeminarAttendanceViewModel.getAttendance(Id); }
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
