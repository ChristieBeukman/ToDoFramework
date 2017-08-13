using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ToDo.Model;

namespace ToDo.Services
{
    public interface IDataAccesCategory
    {
        ObservableCollection<CategoryItem> GetCategories();
        void CreateCategories(CategoryItem Cat);
        void DeleteCategories(CategoryItem cat);
        void UpdateCategories(CategoryItem NewCat, CategoryItem OldCat);
    }
}
