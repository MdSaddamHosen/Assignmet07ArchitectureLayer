using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopWithOperation.OrderRepository;

namespace CoffeeShopWithOperation.OrderBLL
{
   public class OrderManager
    {
        OrdersRepository _OrdersRepository = new OrdersRepository();

        public bool addorder(string name, string item, int quantity,int totalprice)
        {
            return _OrdersRepository.addorder(name, item, quantity,totalprice);
        }
        public bool isexitename(string name)
        {
            return _OrdersRepository.isexitename(name);
        }
        public DataTable show()
        {
            return _OrdersRepository.show();
        }
        public bool update(string name, string iteam, int quantity,int totalprice, int id)
        {
            return _OrdersRepository.update(name, iteam, quantity,totalprice, id);
        }
        public bool delete(int id)
        {
            return _OrdersRepository.delete(id);
        }
        public DataTable search(string name)
        {
            return _OrdersRepository.search(name);
        }
    }
}
