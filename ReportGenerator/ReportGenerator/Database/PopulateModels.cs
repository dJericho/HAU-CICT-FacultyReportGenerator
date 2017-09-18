using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            populateFaculty();
            populateRoles();
            populateSubjects();
            populateFacultyLoads();
        }
        private static void populateSeminars()
        {
            string query = "select id, seminarname, seminartype, classificationid, venue, date from seminars";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            SeminarViewModel.seminars = new BindingList<Seminar>((from DataRow row in dt.Rows
                                                                          select new Seminar
                                                                          {
                                                                              Id = int.Parse(row["id"].ToString()),
                                                                              SeminarName = row["seminarname"].ToString(),
                                                                              Typeid = int.Parse(row["seminartype"].ToString()),
                                                                              Classificationid = int.Parse(row["classificationid"].ToString()),
                                                                              Venue = row["venue"].ToString(),
                                                                              Date = row["Date"].ToString()
                                                                          }).ToList());
            sql.closeConnection();
        }
        private static void populateAttendance()
        {
            string query = "select * from seminarsattendance";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            SeminarAttendanceViewModel.seminarAttendance = new BindingList<SeminarAttendance>((from DataRow row in dt.Rows
                                         select new SeminarAttendance
                                         {
                                             Id = int.Parse(row["id"].ToString()),
                                             Facultyid = int.Parse(row["facultyId"].ToString()),
                                             Seminarid = int.Parse(row["seminarId"].ToString())
                                         }).ToList());
            sql.closeConnection();
        }
        private static void populateTypes()
        {
            string query = "select * from seminarTypes";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            SeminarTypeViewModel.seminarType = new BindingList<SeminarType>((from DataRow row in dt.Rows
                                                select new SeminarType
                                                {
                                                    Id = int.Parse(row["id"].ToString()),
                                                    Type = row["type"].ToString()
                                                }).ToList());
            sql.closeConnection();
        }
        private static void populateClassification()
        {
            string query = "select * from classifications";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            SeminarClassificationViewModel.seminarClassification = new BindingList<SeminarClassification>((from DataRow row in dt.Rows
                                                select new SeminarClassification
                                                {
                                                    Id = int.Parse(row["id"].ToString()),
                                                    Classification = row["classification"].ToString()
                                                }).ToList());
            sql.closeConnection();
        }
        private static void populateFaculty()
        {
            string query = "select * from faculty";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            FacultyViewModel.Faculty = new BindingList<Faculty>((from DataRow row in dt.Rows
                                        select new Faculty
                                        {
                                            Id = int.Parse(row["id"].ToString()),
                                            Name = row["name"].ToString(),
                                            Undergrad = row["undergrad"].ToString(),
                                            Postgrad = row["postgrad"].ToString(),
                                            RoleId = int.Parse(row["roleid"].ToString())
                                        }).ToList());
            sql.closeConnection();
        }
        private static void populateRoles()
        {
            string query = "select * from roles";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            RoleViewModel.roles = new BindingList<Role>((from DataRow row in dt.Rows
                                        select new Role
                                        {   
                                            Id = int.Parse(row["id"].ToString()),
                                            RoleName = row["rolename"].ToString()
                                        }).ToList());
            sql.closeConnection();
        }
        private static void populateSubjects()
        {
            string query = "select * from subjects";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            SubjectViewModel.subjects = new BindingList<Subject>((from DataRow row in dt.Rows
                                   select new Subject
                                   {
                                       Id = int.Parse(row["id"].ToString()),
                                       Name = row["name"].ToString(),
                                       ClassID = int.Parse(row["classificationid"].ToString())
                                   }).ToList());
            sql.closeConnection();
        }
        private static void populateFacultyLoads()
        {
            string query = "select * from facultyloads";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            FacultyLoadsViewModel.facultyloads = new BindingList<FacultyLoads>((from DataRow row in dt.Rows
                                         select new FacultyLoads
                                         {
                                             Id = int.Parse(row["id"].ToString()),
                                             Facultyid = int.Parse(row["facultyid"].ToString()),
                                             Subjectid = int.Parse(row["subjectid"].ToString())
                                         }).ToList());
            sql.closeConnection();
        }
    }
}
