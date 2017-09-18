using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Subject : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private int _classID;

        public int Id {
            get => _id;
            set {
                if(value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }
        public string Name {
            get => _name;
            set {
                if(value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        public int ClassID {
            get => _classID;
            set {
                if (value != _classID)
                {
                    _classID = value;
                    NotifyPropertyChanged("ClassID");
                }
            }
            }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
