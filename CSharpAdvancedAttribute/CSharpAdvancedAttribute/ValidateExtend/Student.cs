using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedAttribute.ValidateExtend
{
   public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(5,10)]
        public string StudentName { get; set; }
        [Required]
        [Long(11)]
        public long PoneNumber { get; set; }
    }
}
