using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using ToDoList.Services;
using ToDoList.Model;
using System.Windows;
using ToDoList.View;
using System.Linq;

namespace ToDoList.ViewModel
{
    public class SupplierViewModel : ViewModelBase
    {
#region Properties
        IDataAccessSupplier _ServiceProxy;
        private ObservableCollection<Suppliier> _Suppliers;
        private Suppliier _Supplier;
        private Suppliier _SelectedSupplier;
        private string _SupplierName;

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

        public Suppliier Supp
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

        public string SupplierName
        {
            get
            {
                return _SupplierName;
            }

            set
            {
                _SupplierName = value;
                RaisePropertyChanged("SupplierName");
            }
        }
        #endregion

        #region Commands
        public RelayCommand AddSupplierCommand { get; set; }
        public RelayCommand LoadAddSupplierViewCommand { get; set; }
        public RelayCommand CloseAddSupplierViewCommand { get; set; }
        public RelayCommand DeleteSupplierCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public SupplierViewModel(IDataAccessSupplier servPxy)
        {
            _ServiceProxy = servPxy;
            Suppliers = new ObservableCollection<Suppliier>();
            Supp = new Suppliier();
            GetSuppliers();
            AddSupplierCommand = new RelayCommand(AddSupplier);
            LoadAddSupplierViewCommand = new RelayCommand(LoadAddSupplierView);
            CloseAddSupplierViewCommand = new RelayCommand(CloseCurrentView);
            DeleteSupplierCommand = new RelayCommand(DeleteSelectedSupplier);
            SearchCommand = new RelayCommand(SearchSupplier);
        }
        #endregion

#region Methods
        void GetSuppliers()
        {
            Suppliers.Clear();
            foreach (var item in _ServiceProxy.GetSupplierDataAccess())
            {
                Suppliers.Add(item);
            }
        }

        void AddSupplier()
        {
           
            switch (MessageBox.Show("Save " + Supp.Name,"Save Record",MessageBoxButton.YesNo))
            {
                case MessageBoxResult.Yes:
                    Suppliers.Add(Supp);
                    _ServiceProxy.CreateSupplier(Supp);
                    RaisePropertyChanged("Supp");
                    MessageBox.Show(Supp.Name + " has been Saved");
                    break;
                default:
                    break;
            }
            //Supp.Equals(null);
            CloseCurrentView();
        }

        void CloseCurrentView()
        {
            var win = new MainWindow();
            win.Show();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = win;
        }

        void LoadAddSupplierView()
        {
            var win = new AddSupplierView(); 
            win.Show();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = win;


        }

        void DeleteSelectedSupplier()
        {
            _ServiceProxy.DeleteSuppllier(SelectedSupplier);
            Suppliers.Remove(SelectedSupplier);
            
            MessageBox.Show("Deleted");
            GetSuppliers();
            RaisePropertyChanged("SelectedSupplier");
            RaisePropertyChanged("Suppliers");
        }

        void SearchSupplier()
        {
            Suppliers.Clear();
            var Result = from e in _ServiceProxy.GetSupplierDataAccess()
                         where e.Name.StartsWith(SupplierName)
                         select e;
            foreach (var item in Result)
            {
                Suppliers.Add(item);
            }
        }
        #endregion
    }
}
