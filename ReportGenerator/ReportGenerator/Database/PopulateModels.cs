using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class PopulateModels
    {
        private static Connector sql = new Connector();
        public static void populate()
        {
            populateSeminars();
            populateAttendance();
            populateClassification();
            populateFaculty();
            populateFacultyLoads();
            populateRoles();
            populateSubjects();
            populateTypes();
        }
        private static void populateSeminars()
        {
            string query = "select id, seminarname, seminartype, classificationid, venue, date from seminars";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            SeminarVM.Seminars = new BindingList<Seminar>((from DataRow row in dt.Rows
                                                                  select new Seminar
                                                                  {
                                                                      id = int.Parse(row["id"].ToString()),
                                                                      seminarName = row["seminarname"].ToString(),
                                                                      typeid = int.Parse(row["seminartype"].ToString()),
                                                                      classId = int.Parse(row["classificationid"].ToString()),
                                                                      venue = row["venue"].ToString(),
                                                                      date = row["Date"].ToString()
                                                                  }).ToList());
            sql.closeConnection();
        }
        private static void populateAttendance()
        {
            string query = "select * from seminarsattendance";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            AttendanceVM.Attendances = new BindingList<Attendance>((from DataRow row in dt.Rows
                                                                    select new Attendance
                                                                    {
                                                                        id = int.Parse(row["id"].ToString()),
                                                                        facultyid = int.Parse(row["facultyId"].ToString()),
                                                                        seminarid = int.Parse(row["seminarId"].ToString())
                                                                    }).ToList());
            sql.closeConnection();
        }
        private static void populateTypes()
        {
            string query = "select * from seminarTypes";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            TypeVM.Types = new BindingList<Type>((from DataRow row in dt.Rows
                                                  select new Type
                                                  {
                                                      id = int.Parse(row["id"].ToString()),
                                                      type = row["type"].ToString()
                                                  }).ToList());
            sql.closeConnection();
        }
        private static void populateClassification()
        {
            string query = "select * from classifications";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            ClassificationVM.Classifications = new BindingList<Classification>((from DataRow row in dt.Rows
                                                                                select new Classification
                                                                                {
                                                                                    id = int.Parse(row["id"].ToString()),
                                                                                    classification = row["classification"].ToString()
                                                                                }).ToList());
            sql.closeConnection();
        }
        private static void populateFaculty()
        {
            string query = "select * from faculty";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            FacultyVM.faculty = new BindingList<Faculty>((from DataRow row in dt.Rows
                                                                 select new Faculty
                                                                 {
                                                                     id = int.Parse(row["id"].ToString()),
                                                                     name = row["name"].ToString(),
                                                                     undergrad = row["undergrad"].ToString(),
                                                                     undergradYear = int.Parse(row["undergradYear"].ToString()),
                                                                     postgrad = row["postgrad"].ToString(),
                                                                     postgradYear = int.Parse(row["postgradYear"].ToString()),
                                                                     postgradExpectedYear = row["expectedDate"].ToString(),
                                                                     roleID = int.Parse(row["roleId"].ToString())
                                                                 }).ToList());
            sql.closeConnection();
        }
        private static void populateRoles()
        {
            string query = "select * from roles";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            RoleVM.Roles = new BindingList<Role>((from DataRow row in dt.Rows
                                                  select new Role
                                                  {
                                                      id = int.Parse(row["id"].ToString()),
                                                      roleName = row["rolename"].ToString()
                                                  }).ToList());
            sql.closeConnection();
        }
        private static void populateSubjects()
        {
            string query = "select * from subjects";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            SubjectVM.Subjects = new BindingList<Subject>((from DataRow row in dt.Rows
                                                           select new Subject
                                                           {
                                                               id = int.Parse(row["id"].ToString()),
                                                               name = row["name"].ToString(),
                                                               classID = int.Parse(row["classificationid"].ToString())
                                                           }).ToList());
            sql.closeConnection();
        }
        private static void populateFacultyLoads()
        {
            string query = "select * from facultyloads";
            sql.openConnection();
            DataTable dt = sql.getData(query);
            LoadsVM.Loads = new BindingList<FacultyLoads>((from DataRow row in dt.Rows
                                                           select new FacultyLoads
                                                           {
                                                               id = int.Parse(row["id"].ToString()),
                                                               facultyID = int.Parse(row["facultyid"].ToString()),
                                                               subjectID = int.Parse(row["subjectid"].ToString())
                                                           }).ToList());
            sql.closeConnection();
        }
    }
}
