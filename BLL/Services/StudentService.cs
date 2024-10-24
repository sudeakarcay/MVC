using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IStudentService
    {
        public Service Create(Student student);
        public Service Update(Student student);
        public Service Delete(int id);
        public IQueryable<StudentModel> Query();
    }

    public class StudentService : Service, IStudentService
    {
        public StudentService(Db db) : base(db)
        {
        }

        public Service Create(Student student)
        {
            if (_db.Students.Any(c => c.Name == student.Name))
                return Error("Student with the same name exists!");
            _db.Students.Add(student);
            _db.SaveChanges();
            return Success();
        }

        public Service Delete(int id)
        {
            var student = _db.Students.SingleOrDefault(c => c.Id == id);
            if (student is not null)
                return Error("Student cannot be deleted!");
            _db.Students.Remove(student);
            _db.SaveChanges();
            return Success();
        }

        public IQueryable<StudentModel> Query()
        {
            return _db.Students.OrderBy(c => c.Name).Select(c => new StudentModel() { Record = c });
        }

        public Service Update(Student student)
        {
            if (_db.Students.Any(c => c.Id != student.Id && c.Name == student.Name))
                return Error("Student with the same name exists!");
            _db.Students.Update(student);
            _db.SaveChanges();
            return Success();
        }
    }
}