using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManagerDataAccess;
using TaxiManagerDomain.Models;
using TaxiManagerServices.Abstraction;

namespace TaxiManagerServices.Implementation
{
    public abstract class ServiceBase<T> : iServiceBase<T> where T : BaseEntity//abstract zoshto ne sakame da praime istanci
    {
        protected IDb<T> _db;
        public ServiceBase()
        {
            _db = new LocalDb<T>();
        }
        public void Add(T item)//ja povikuvame Insert metodata od IserviceBase
        {
            _db.Insert(item);
        }

        public List<T> GetAll()
        {
            return _db.GetAll();
        }

        public List<T> GetAll(Func<T, bool> wherePredicate)
        {
            return _db.GetAll().Where(wherePredicate).ToList();
        }

        public T GetSingle(int id)
        {
            return _db.GetById(id);
        }

        public void Remove(int id)
        {
            _db.RemoveById(id);
        }

        public void Seed(List<T> items)
        {
            if(_db.GetAll().Count > 0)//proveruvame dali ima neshto vo bazata, ako ima ne praime nishto
            {
                return;
            }
            items.ForEach(item => _db.Insert(item));//ako e prazna bazata, za sekoj item posebno kje ja povikame insert metodata i kje go zapiseme
            //istoto e ko gore ova
            //foreach(var item in items)
            //{
            //    _db.Insert(item)
            //}
        }
    }
}
