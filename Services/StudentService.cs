using D10.Data.Entites;
using D10.Data;

namespace D10.Services
{
    public class StudentService : IStudentService
    {
        private readonly MyDbContext _context;

        public StudentService(MyDbContext context)
        {
            _context = context;
        }

        public IList<Student>? GetAll()
        {
            return _context.Students != null ? _context.Students.ToList(): new List<Student>();
        }

        public Student? GetOne(int id)
        {
            if(_context.Students == null) return null;

            return _context.Students.SingleOrDefault(x => x.StudentId == id);
        }

        public Student? Add(Student entity)
        {
            if(_context.Students == null) return null;

            _context.Students.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public Student? Edit(int id, Student entity)
        {
            if(_context.Students == null) return null;

            _context.Students.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Remove(int id, Student entity)
        {
            if(_context.Students == null) throw new IndexOutOfRangeException();

            _context.Students.Remove(entity);
            _context.SaveChanges();
        }
    }
}