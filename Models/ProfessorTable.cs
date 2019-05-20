using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class ProfessorTable
    {
        public int Id { get; set; }
        public int CathedraId { get; set; }
        public DateTime StartDate { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string WorkPosition { get; set; }
        public string AcademicDegree { get; set; }
        public string Other { get; set; }
    }
}
