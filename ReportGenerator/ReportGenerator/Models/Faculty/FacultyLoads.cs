using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class FacultyLoads : INotifyPropertyChanged
    {
        private int _id;
        private int _facultyid;
        private int _subjectid;

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
        public int Facultyid {
            get => _facultyid;
            set
            {
                if (value != _facultyid)
                {
                    _facultyid = value;
                    NotifyPropertyChanged("Facultyid");
                }
            }
        }
        public int Subjectid {
            get => _subjectid;
            set
            {
                if (value != _subjectid)
                {
                    _subjectid = value;
                    NotifyPropertyChanged("SubjectID");
                }
            }
        }
        public Faculty faculty { get => FacultyViewModel.getFaculty(Facultyid); }
        public Subject subject { get => SubjectViewModel.getSubject(Subjectid); }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
