using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManagerDomain.Models;

namespace TaxiManagerServices.Abstraction
{
    public interface iServiceBase<T> where T: BaseEntity//add reference to taximanagerdomain
    {
        List<T> GetAll();
        List<T> GetAll(Func<T,bool>wherePredicate);//getall so delegat, i vnatresnosta kje sodrzi nekoi filtri
        T GetSingle(int id);
        void Add(T item);
        void Remove(int id);
        void Seed(List<T> items);//seed za da napolnime baza, prima lista so nekoj entitet

    }
}
