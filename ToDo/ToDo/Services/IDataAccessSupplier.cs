using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ToDo.Model;

namespace ToDo.Services
{
    public interface IDataAccessSupplier
    {
        ObservableCollection<Suppliier> GetSuppliers();
        void CreateSupplier(Suppliier Sup);
        void DeleteSupplier(Suppliier Sup);
        void UpdateSupplier(Suppliier NewSup, Suppliier OldSup);
    }
}
