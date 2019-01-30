//using System;
//using System.Collections.Generic;
//using System.Text;  
//using BL.UOW;
//using BL.Entities;
//using BL.Repositories; 

//namespace BL
//{
//    public class ServiceModule //: NinjectModule
//    { 
//        private string connectionString;
//        public ServiceModule(string connection)
//        {
//            connectionString = connection;
//        }

//        //public ServiceModule()
//        //{

//        //}
//        public override void Load()
//        {
//            //  Bind<IUnitOFWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
//           // Bind<IUnitOFWork>().To<EFUnitOfWork>();
//        }

//        //private string connectionString;
//        //public ServiceModule(string connection)
//        //{
//        //    connectionString = connection;
//        //}

//        //public override void Load()
//        //{
//        //    Bind<IUnitOFWork>().To<EFUnitOfWork>().InRequestScope().WithConstructorArgument(connectionString);
//        //    Bind<IGenericRepository<Student>>().To<EFGenericRepository<Student>>().InRequestScope();
//        //    Bind<IGenericRepository<Lesson>>().To<EFGenericRepository<Lesson>>().InRequestScope();
//        //    Bind<IGenericRepository<Teacher>>().To<EFGenericRepository<Teacher>>().InRequestScope();
//        //    Bind<IGenericRepository<Group>>().To<EFGenericRepository<Group>>().InRequestScope();
//        //    Bind<IGenericRepository<PresetStudent>>().To<EFGenericRepository<PresetStudent>>().InRequestScope();
//        //    Bind<EFContext>().ToSelf().InRequestScope();

//        //}
//    }
//}
