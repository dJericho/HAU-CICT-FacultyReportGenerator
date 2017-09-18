using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Faculty : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _undergrad;
        private string _postgrad;
        private int _roleId;

        public int Id {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }
        public string Name {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        public string Undergrad {
            get => _undergrad;
            set
            {
                if (value != _undergrad)
                {
                    _undergrad = value;
                    NotifyPropertyChanged("Undergrad");
                }
            }
        }
        public string Postgrad {
            get => _postgrad;
            set
            {
                if (value != _postgrad)
                {
                    _postgrad = value;
                    NotifyPropertyChanged("Postgrad");
                }
            }
        }
        public int RoleId {
            get => _roleId;
            set
            {
                if (value != _roleId)
                {
                    _roleId = value;
                    NotifyPropertyChanged("RoleId");
                }
            }
        }
        public String Role { get => RoleViewModel.getRole(RoleId);}

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
