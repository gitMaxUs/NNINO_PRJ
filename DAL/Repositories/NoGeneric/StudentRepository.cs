//using DAL.Entities; 
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;

//namespace DAL.Repositories
//{
//    public class StudentRepository : IGenericRepository<Student>
//    {
//        private EFContext db;
//        public StudentRepository(EFContext context)
//        {
//            db = context;
//        }


//        public IEnumerable<Student> GetAll()
//        {
//            return db.Students;
//        }

//        public Student Get(int id)
//        {
//            return db.Students.Find(id);
//        }

//        public void Create(Student book)
//        {
//            db.Students.Add(book);
//        }

//        public void Update(Student book)
//        {
//            db.Entry(book).State = EntityState.Modified;
//        }

//        public IEnumerable<Student> Find(Func<Student, Boolean> predicate)
//        {
//            return db.Students.Where(predicate).ToList();
//        }

//        public void Delete(int? id)
//        {
//            Student book = db.Students.Find(id);
//            if (book != null)
//                db.Students.Remove(book);
//        }

       
//    }
//}

