using DAL.UOW;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;
        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOFWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
