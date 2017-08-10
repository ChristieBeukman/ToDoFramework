using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ToDo.Services;
using ToDo.Model;


namespace ToDo.ViewModel
{
    public class SupplierViewModel : ViewModelBase
    {
        /// <summary>
        /// Private Public Properties
        /// </summary>
        IDataAccessSupplier _ServiceProxy;
        private ObservableCollection<Suppliier> _Suppliers;
        private Suppliier _Supplier;
        private Suppliier _SelectedSupplier;

        /// <summary>
        /// Public Properties
        /// </summary>
        public ObservableCollection<Suppliier> Suppliers
        {
            get
            {
                return _Suppliers;
            }

            set
            {
                _Suppliers = value;
                RaisePropertyChanged("Suppliers");
            }
        }

        public Suppliier Supplier
        {
            get
            {
                return _Supplier;
            }

            set
            {
                _Supplier = value;
                RaisePropertyChanged("Supplier");
            }
        }

        public Suppliier SelectedSupplier
        {
            get
            {
                return _SelectedSupplier;
            }

            set
            {
                _SelectedSupplier = value;
                RaisePropertyChanged("SelectedSupplier");
            }
        }

        /// <summary>
        /// COnstructor Initialises all objects
        /// </summary>
        /// <param name="prxy"></param>
        public SupplierViewModel(IDataAccessSupplier prxy)
        {
            _ServiceProxy = prxy;
            Suppliers = new ObservableCollection<Suppliier>();
            Supplier = new Suppliier();
            SelectedSupplier = new Suppliier();
            GetSupplier();
        }

        void GetSupplier()
        {
            Suppliers.Clear();
            foreach (var item in _ServiceProxy.GetSuppliers())
            {
                Suppliers.Add(item);
            }
        }

    }
}
