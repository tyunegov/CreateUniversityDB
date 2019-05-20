using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class CathedraTable
    {
        public  int Id { get; set; }
        public string CathedraName { get; set; }
        public int FoundationYear { get; set; }
        public int FacultyId { get; set; }
    }
}
