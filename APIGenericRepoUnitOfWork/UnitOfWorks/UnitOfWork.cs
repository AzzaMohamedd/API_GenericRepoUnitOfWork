using APIGenericRepoUnitOfWork.Models;
using APIGenericRepoUnitOfWork.Repositories;

namespace APIGenericRepoUnitOfWork.UnitOfWorks
{
    public class UnitOfWork
    {
        ITIContext db;
        private GenericRepository<Student> studentGenRepo;
        private GenericRepository<Department> deptGenRepo;
        private StudentRepository studentRepository;

        public GenericRepository<Student> StudentGenRepo
        {
            get
            {
                if(studentGenRepo == null)
                {
                    studentGenRepo = new GenericRepository<Student>(db);
                }
                return studentGenRepo;
            }
        }
        public GenericRepository<Department> DeptGenRepo
        {
            get
            {
                if(deptGenRepo == null)
                {
                    deptGenRepo = new GenericRepository<Department>(db);
                }
                return deptGenRepo;
            }
        }
        public StudentRepository StudentRepository
        {
            get
            {
                if(studentRepository == null)
                {
                    studentRepository = new StudentRepository(db);
                }
                return studentRepository;
            }
        }
        public UnitOfWork(ITIContext db)
        {
            this.db = db;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
