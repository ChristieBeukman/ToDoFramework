using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using ToDoList.Services;
using ToDoList.Model;
using System.Windows;

namespace ToDoList.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        //IDataAccessSupplier _ServiceProxy;
        //private ObservableCollection<Suppliier> _Suppliers;
        //private Suppliier _Supplier;
        //private Suppliier _SelectedSupplier;
        //public RelayCommand AddSupplierCommand { get; set; }

        ///// <summary>
        ///// Initializes a new instance of the MainViewModel class.
        ///// </summary>
        //public MainViewModel(IDataAccessSupplier servPxy)
        //{
        //    _ServiceProxy = servPxy;
        //    Suppliers = new ObservableCollection<Suppliier>();
        //    Supp = new Suppliier();
        //    GetSuppliers();
        //    AddSupplierCommand = new RelayCommand(AddSupplier);
          
        //}

        //public ObservableCollection<Suppliier> Suppliers
        //{
        //    get
        //    {
        //        return _Suppliers;
        //    }

        //    set
        //    {
        //        _Suppliers = value;
        //        RaisePropertyChanged("Suppliers");
        //    }
        //}

        //public Suppliier Supp
        //{
        //    get
        //    {
        //        return _Supplier;
        //    }

        //    set
        //    {
        //        _Supplier = value;
        //        RaisePropertyChanged("Supplier");
        //    }
        //}

        //public Suppliier SelectedSupplier
        //{
        //    get
        //    {
        //        return _SelectedSupplier;
        //    }

        //    set
        //    {
        //        _SelectedSupplier = value;
        //        RaisePropertyChanged("SelectedSupplier");
        //    }
        //}

        //void GetSuppliers()
        //{
        //    Suppliers.Clear();
        //    foreach (var item in _ServiceProxy.GetSupplierDataAccess())
        //    {
        //        Suppliers.Add(item);
        //    }
        //}

        //void AddSupplier()
        //{
        //    Suppliers.Add(Supp);
        //    _ServiceProxy.CreateSupplier(Supp);
        //    RaisePropertyChanged("Supp");
        //    MessageBox.Show(Supp.Name + " has been Saved");
        //}
    }
}