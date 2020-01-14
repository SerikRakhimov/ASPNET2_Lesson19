using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmptyProject.Models;

namespace EmptyProject.Interfaces.Implementations
{
    public class MockStudentsRepository : IStudentRepository
    {
        IList<Student> _students;

        public MockStudentsRepository()
        {
            _students = new List<Student>()
            {
                new Student { Id = 1, Name="Ruslan" },
                new Student { Id = 2, Name="Karina" },
                new Student { Id = 3, Name="Serik" }
            };
        }

        public bool Add(Student student)
        {
            try
            {
                _students.Add(student);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Student student)
        {
            try
            {
                Get(student.Id).Name = student.Name;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var student = Get(id);
                if (student != null)
                    _students.Remove(student);
                else return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Student Get(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }
    }
}
