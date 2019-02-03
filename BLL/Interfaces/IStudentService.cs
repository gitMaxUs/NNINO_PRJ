using BLL.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetItems();

        void CreateItem(StudentDTO ItemDTO);

        void EditItem(StudentDTO ItemDTO);

        StudentDTO GetItem(int? id);

        void DeleteItem(int? id);
    }
}
