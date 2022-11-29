using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
    public class Menu
    {
        public List<Food> MenuValues;

        public Menu(List<Food> menu)
        {
            MenuValues = menu;
        }
    }
}
