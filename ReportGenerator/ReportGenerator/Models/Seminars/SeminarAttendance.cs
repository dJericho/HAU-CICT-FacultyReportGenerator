﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SeminarAttendance : INotifyPropertyChanged
    {
        private int _id;
        private int _facultyid;
        private int _seminarid;

        public int Id {
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
        public int Seminarid {
            get => _seminarid;
            set
            {
                if (value != _seminarid)
                {
                    _seminarid = value;
                    NotifyPropertyChanged("Seminarid");
                }
            }
        }
        public Seminar Seminar { get => SeminarViewModel.getSeminar(Seminarid); }
        public Faculty Faculty { get => FacultyViewModel.getFaculty(Facultyid); }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
