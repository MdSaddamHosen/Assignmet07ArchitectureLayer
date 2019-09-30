using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopWithOperation.ItemsRepository;

namespace CoffeeShopWithOperation.ItemsBLL
{
    public class ItemManager
    {
        ItemRepository _ItemRepository = new ItemRepository();
        
        public bool additems(string name, int price)
        {
            return _ItemRepository.additems(name, price);
        }
        public bool isexitename(string name)
        {
            return _ItemRepository.isexitename(name);
        }
        public DataTable showitems()
        {
           return  _ItemRepository.showitems();
        }
        public bool update(string name, int price, int id)
        {
            return _ItemRepository.update(name, price, id);
        }
        public bool delete(int id)
        {
            return _ItemRepository.delete(id);
        }
        public DataTable search(string name)
        {
            return _ItemRepository.search(name);
        }
    }
}
