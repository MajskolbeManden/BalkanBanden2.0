using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding_test.Model
{
    public class Data
    {
        public static ObservableCollection<Object> ProductList = new ObservableCollection<Object>
        {
            new Object { Name = "lol"},
            new Object { Name = "numse"},
            new Object { Name = "fisk"},
            new Object { Name = "loleren"},
            new Object { Name = "fuck xamarin"}
        };
    }
}
