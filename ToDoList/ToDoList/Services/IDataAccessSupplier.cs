using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ToDoList.Model;


namespace ToDoList.Services
{
     public interface IDataAccessSupplier
    {
        ObservableCollection<Suppliier> GetSupplierDataAccess();
        void CreateSupplier(Suppliier Sup);
        void DeleteSuppllier(Suppliier Sup);
    }
}
