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
        public long RestaurantId { get; set; }
        public List<Food> MenuValues;

        public Menu(long restId, List<Food> menu)
        {
            RestaurantId = restId;
            MenuValues = menu;
        }
    }

    //сериализую меню разных ресторанов. каждый раз создается новый список. где хранятся, как достать необходимое меню по айди ресторана
}
