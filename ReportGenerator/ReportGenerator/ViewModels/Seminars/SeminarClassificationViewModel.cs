﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SeminarClassificationViewModel
    {
        public static BindingList<SeminarClassification> seminarClassification { get; set; }

        public static string getClassification(int id)
        {
            try
            {
                return seminarClassification.FirstOrDefault(x => {
                    return x.Id == id;
                }).Classification;
            }
            catch(Exception)
            {
                Console.WriteLine("Error in SeminarClassificationViewModel!");
                PopulateModels.populate();
                return getClassification(id);
            }
        }
    }
}
