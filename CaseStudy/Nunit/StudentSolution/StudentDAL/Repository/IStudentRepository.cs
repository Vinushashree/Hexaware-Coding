using StudentDAL.Domain;
using System.Collections.Generic;

namespace StudentDAL.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetByRollNo(int rollNo);
        Student GetByName(string name);
        void Add(Student student);
        void Update(Student student);
        void Delete(int rollNo);
    }
}

