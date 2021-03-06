

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ToDo.Services;

namespace ToDo.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

          

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SupplierViewModel>();
            SimpleIoc.Default.Register<IDataAccessSupplier,DataAccessSupplier>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public SupplierViewModel SupplierVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SupplierViewModel>();
            }
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}