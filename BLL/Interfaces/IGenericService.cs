using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IGenericService<T>
    {
        IEnumerable<T> GetItems();

        void CreateItem(T ItemDTO);

        void EditItem(T ItemDTO);

        T GetItem(int? id);

        void DeleteItem(int? id);
    }
}
