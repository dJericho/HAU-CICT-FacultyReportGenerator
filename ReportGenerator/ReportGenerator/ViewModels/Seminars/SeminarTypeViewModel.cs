using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class SeminarTypeViewModel
    {
        public static BindingList<SeminarType> seminarType { get; set; }

        public static string getType(int id)
        {
            try
            {
                return seminarType.FirstOrDefault(x => {
                    return x.Id == id;
                    }).Type;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error in SEMINARTYPEVIEWMODEL!");
                PopulateModels.populate();
                return getType(id);
            }
        }
    }
}
