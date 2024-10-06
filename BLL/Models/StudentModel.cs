using BLL.DAL;

namespace BLL.Models
{
    public class StudentModel
    {
        public Student Record { get; set; }
        
        public String Name => Record.Name;

        public String Surname => Record.Surname;

        public DateTime? BirthDate => Record.BirthDate;

        public decimal? Gpa => Record.Gpa;
    }
}
