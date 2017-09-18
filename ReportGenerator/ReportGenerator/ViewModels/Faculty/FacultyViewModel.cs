﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class FacultyViewModel
    {
        public static BindingList<Faculty> Faculty { get; set; }

        public static Faculty getFaculty(int id)
        {
            return Faculty.FirstOrDefault(e => e.Id == id);
        }
    }
}
