using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManagerDomain.Models;

namespace TaxiManagerDataAccess//dependencies->add project reference
{
    public interface  IDb<T>where T: BaseEntity//tipot samo kje go pusti i kje pravime istanca, genericka kje e
    {
        List<T> GetAll();//ne prima nishto, vrakja lista
        T GetById(int id);//vrakja eden single entitet, ako bide povikana od koli vrakja koli
        int Insert(T entity);//primame car, driver ili user
        void RemoveById(int id);//primame id
        void Update(T entity);

    }
}
