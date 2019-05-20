namespace FillingDataUniversityDB
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using University.Models;

    public class UniversityContext : DbContext
    {

        public UniversityContext()
            : base("name=UniversityDB")
        {
        }

        

        public DbSet<CathedraTable> Cathedras{get; set;}
        public DbSet<FacultyTable> Faculties { get; set; }
        public DbSet<ProfessorTable> Professors { get; set; }
    }
}