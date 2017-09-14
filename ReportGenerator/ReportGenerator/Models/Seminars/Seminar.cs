using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Seminar
    {
        private int _id;
        private string _SeminarName;
        private int _typeid;
        private string _type;
        private int _classificationid;
        private List<Faculty> _attendance;
        private string _classificiation;
        private string _venue;
        private string _date;

        public int Id{
            get => _id;
            set => _id = value; }
        public string SeminarName {
            get => _SeminarName;
            set => _SeminarName = value; }
        public string Type {
            get => SeminarTypeViewModel.getType(Typeid);
            set => _type = value; }
        public string Classification {
            get => SeminarClassificationViewModel.getClassification(Classificationid);
            set => _classificiation = value; }
        public string Venue {
            get => _venue;
            set => _venue = value; }
        public string Date {
            get => _date;
            set => _date = value; }
        public int Typeid {
            get => _typeid;
            set => _typeid = value; }
        public int Classificationid {
            get => _classificationid;
            set => _classificationid = value; }
        public List<Faculty> Attendance { get => SeminarAttendanceViewModel.getAttendance(Id); set => _attendance = value; }

        public string[] getData()
        {
            string[] x =
            {
                SeminarName, Typeid+"", Classificationid+"", Venue, Date
            };
            return x;
        }
    }
}
