using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using University.Models;

namespace FillingDataUniversityDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            CathedraTable(ref i);
            FacultyTable();
            ProfessorTable(i);
                                       
            MessageBox.Show("Выполнено");            
        }

        private void CathedraTable(ref int i)
        {
            using (UniversityContext context = new UniversityContext())
            {
                CathedraTable cathedra = new CathedraTable();
                StreamReader sr = new StreamReader(@"Cathedras.txt", Encoding.GetEncoding(1251));
                Random random = new Random();
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    cathedra.CathedraName = s.Split('#')[0];
                    cathedra.FacultyId = Convert.ToInt32(s.Split('#').Last());
                    cathedra.FoundationYear = random.Next(1950, 2019);
                    context.Cathedras.Add(cathedra);
                    context.SaveChanges();
                    i++;
                }
                sr.Close();
            }
        }

        private void ProfessorTable(int i)
        {
            Random random = new Random();
            ProfessorTable professor = new ProfessorTable();
            using (UniversityContext context = new UniversityContext())
            {
                for (int j = 0; j < 100; j++)
                {
                    DateTime date1 = new DateTime(1950, 1, 1);
                    date1 = date1.AddYears(random.Next(0, 69));
                    date1 = date1.AddMonths(random.Next(0, 12));
                    date1 = date1.AddDays(random.Next(0, 30));
                    var prepod = Prepod();
                    professor.CathedraId = random.Next(1, i);
                    professor.Name = prepod.fname;
                    professor.Surname = prepod.lname;
                    professor.Patronymic = prepod.patronymic;
                    professor.WorkPosition = WorkPosition();
                    professor.AcademicDegree = AcademicDegree();
                    professor.Other = null;
                    professor.StartDate = date1;
                    context.Professors.Add(professor);
                    context.SaveChanges();
                }
            }
        }

        private void FacultyTable()
        {
            FacultyTable faculty = new FacultyTable();
            string road = @"Faculties.txt";
            using (UniversityContext context = new UniversityContext())
            {
                StreamReader sr = new StreamReader(road, Encoding.GetEncoding(1251));
                while (!sr.EndOfStream)
                {
                    faculty.FacultyName = sr.ReadLine();
                    context.Faculties.Add(faculty);
                    context.SaveChanges();
                }
                sr.Close();
            }
        }

        private string AcademicDegree()
        {
            Random random = new Random();
            int i = random.Next(1, 6);
            string s = null;
            switch (i)
            {
                case 1:
                    s= "Доцент";
                    break;
                case 2:
                    s = "Профессор";
                    break;
                case 3:
                    s = "Доктор наук";
                    break;
            }
            return s;
        }

        private string WorkPosition()
        {
            Random random = new Random();
            int i = random.Next(1, 12);
            string s = null;
            switch (i)
            {
                case 1:
                    s = "Старший научный сотрудник";
                    break;
                case 2:
                    s = "Старший преподаватель";
                    break;
                case 3:
                    s = "Профессор";
                    break;
                case 4:
                    s = "Преподаватель";
                    break;
                case 5:
                    s = "Научный сотрудник";
                    break;
                case 6:
                    s = "Младший научный сотрудник";
                    break;
                case 7:
                    s = "Доцент";
                    break;
                case 8:
                    s = "Докторант";
                    break;
                case 9:
                    s = "Главный научный сотрудник";
                    break;
                case 10:
                    s = "Ведущий научный сотрудник";
                    break;
                case 11:
                    s = "Ассистент";
                    break;
                case 12:
                    s = "Аспирант";
                    break;
            }
            return s;
        }

        private JsonModel Prepod()
        {
            string url = "https://randus.org/api.php";
            var webClient = new WebClient();
            // Выполняем запрос по адресу и получаем ответ в виде строки
            var response = Encoding.UTF8.GetString(webClient.DownloadData(url));
            return JsonConvert.DeserializeObject<JsonModel>(response);
        }
    }
}
