using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class PopulateModels
    {
        private static SqlConnector sql = new SqlConnector("localhost", 3306, "root", "", "cict-hau");
        public static void populate()
        {
            populateSeminars();
            populateAttendance();
            populateTypes();
            populateClassification();
        }
        private static void populateSeminars()
        {
            string query = "select seminarname, seminartype, classificationid, venue, date from seminars";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            SeminarViewModel.seminars = (from DataRow row in dt.Rows
                                         select new Seminar
                                         {
                                             SeminarName = row["seminarname"].ToString(),
                                             Typeid = int.Parse(row["seminartype"].ToString()),
                                             Classificationid = int.Parse(row["classificationid"].ToString()),
                                             Venue = row["venue"].ToString(),
                                             Date = row["Date"].ToString()
                                         }).ToList();
            sql.closeConnection();
        }
        private static void populateAttendance()
        {
            string query = "select * from seminarsattendance";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            SeminarAttendanceViewModel.seminarAttendance = (from DataRow row in dt.Rows
                                         select new SeminarAttendance
                                         {
                                             Id = int.Parse(row["id"].ToString()),
                                             Facultyid = int.Parse(row["facultyId"].ToString()),
                                             Seminarid = int.Parse(row["seminarId"].ToString())
                                         }).ToList();
            sql.closeConnection();
        }
        private static void populateTypes()
        {
            string query = "select * from seminarTypes";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            SeminarTypeViewModel.seminarType = (from DataRow row in dt.Rows
                                                select new SeminarType
                                                {
                                                    Id = int.Parse(row["id"].ToString()),
                                                    Type = row["type"].ToString()
                                                }).ToList();
            sql.closeConnection();
        }
        private static void populateClassification()
        {
            string query = "select * from classifications";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            SeminarClassificationViewModel.seminarClassification = (from DataRow row in dt.Rows
                                                select new SeminarClassification
                                                {
                                                    Id = int.Parse(row["id"].ToString()),
                                                    Classification = row["classification"].ToString()
                                                }).ToList();
            sql.closeConnection();
        }
    }
}
