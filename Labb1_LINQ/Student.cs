using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }        
        public int CourseID { get; set; }
        public int ClassID { get; set; }
        


        
    }
}
