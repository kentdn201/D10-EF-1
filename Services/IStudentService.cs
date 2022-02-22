using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D10.Data.Entites;

namespace D10.Services
{
    public interface IStudentService
    {
        public IList<Student> GetAll();

        public Student? GetOne(int id);

        public Student? Add(Student entity);

        public Student? Edit(int id, Student entity);

        public void Remove(int id, Student entity);
    }
}