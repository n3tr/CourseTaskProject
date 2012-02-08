using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Windows.Documents;
using CourseTaskProject;

namespace CourseTaskProject.Data
{


    class CourseData
    {
        
        private static CTData _db = new CTData(App.ConnectionString);

        public static CTData db
        {
            get { return _db; }
        }
    }

    
}
