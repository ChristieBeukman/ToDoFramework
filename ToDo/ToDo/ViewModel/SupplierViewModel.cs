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
using System.Windows;
using ToDo.View;

namespace ToDo.ViewModel
{
    public class SupplierViewModel : ViewModelBase
    {
#region Properties

#region Private
        /// <summary>
        /// Private Public Properties
        /// </summary>
        IDataAccessSupplier _ServiceProxy;
        private ObservableCollection<Suppliier> _Suppliers;
        private Suppliier _Supplier;
        private Suppliier _SelectedSupplier;
        private Suppliier _Sup;


        #endregion Private

 #region Public
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

        public Suppliier Sup
        {
            get
            {
                return _Sup;
            }

            set
            {
                _Sup = value;
                RaisePropertyChanged("Sup");
            }
        }


        #endregion Public

#region Commands

        public RelayCommand AddSupplierCommand { get; set; }
        public RelayCommand OpenAddSupplierView { get; set; }
        public RelayCommand DeleteSupplierCommand { get; set; }
        #endregion
        #endregion Properties

        #region Constructor
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
            Sup = new Suppliier();
            AddSupplierCommand = new RelayCommand(AddSupplier);
            OpenAddSupplierView = new RelayCommand(OpenAddSupplierWindow);
            DeleteSupplierCommand = new RelayCommand(DeleteSupplier);
        }

        #endregion Constructor

#region Methods
        /// <summary>
        /// Fill the Combobox with the database data
        /// </summary>
        void GetSupplier()
        {
            Suppliers.Clear();
            foreach (var item in _ServiceProxy.GetSuppliers())
            {
                Suppliers.Add(item);
            }
        }

        /// <summary>
        /// Add new record to the database
        /// </summary>
        void AddSupplier()
        {
            Suppliers.Add(Sup);
            _ServiceProxy.CreateSupplier(Sup);
            RaisePropertyChanged("Sup");
            MessageBox.Show(Sup + " has been succesfully added");
        }

        /// <summary>
        /// Opens the Add Supplier Window
        /// </summary>
        void OpenAddSupplierWindow()
        {
            var win = new AddSupplierWindowView();
            win.ShowDialog();
        }

        void DeleteSupplier()
        {
            var Result = MessageBox.Show("Delete " + SelectedSupplier.Name, "DELETE", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (Result)
            {
                case MessageBoxResult.Yes:
                    _ServiceProxy.DeleteSupplier(SelectedSupplier);
                    Suppliers.Remove(SelectedSupplier);
                    MessageBox.Show("Deleted","",MessageBoxButton.OK,MessageBoxImage.Information);
                    GetSupplier();
                    RaisePropertyChanged("SelectedSupplier");
                    RaisePropertyChanged("Suppliers");
                    break;
                case MessageBoxResult.No:

                    break;
                default:
                    break;
            }
           
        }
#endregion Constructor

    }
}
