using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ToDo.Services;


namespace ToDo.ViewModel
{
    public class SupplierViewModel : ViewModelBase
    {
        IDataAccessSupplier _ServiceProxy;

        public SupplierViewModel(IDataAccessSupplier prxy)
        {
            _ServiceProxy = prxy;
        }
    }
}
