using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopWithOperation.CustomerRepository;

namespace CoffeeShopWithOperation.CustomerBLL
{
   public class CustoemerManager
    {
        CustomersRepository _CustomersRepository = new CustomersRepository();

        public bool addcustomer(string name, string address,int contract)
        {
            return _CustomersRepository.additems(name, address,contract);
        }
        public bool isexitename(string name)
        {
            return _CustomersRepository.isexitename(name);
        }
        public DataTable show()
        {
            return _CustomersRepository.show();
        }
        public bool update(string name, string address, int contract,int id)
        {
            return _CustomersRepository.update(name, address, contract,id);
        }
        public bool delete(int id)
        {
            return _CustomersRepository.delete(id);
        }
        public DataTable search(string name)
        {
            return _CustomersRepository.search(name);
        }
    }
}
