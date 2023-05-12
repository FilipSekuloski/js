using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManagerDomain.Models;

namespace TaxiManagerDataAccess
{
    public class LocalDb<T> : IDb<T> where T : BaseEntity//na IDb odime implement interface za pobrzo
    {
        private List<T> _db;//
        public int IdCount { get; set; }// da znaeme do kaj se Id-njata, da vrsime couunt
        public LocalDb()
        {
            _db = new List<T>();
            IdCount = 1;//sekogash koga startame aplikacijata imame prazna baza, i sekogash da pocnuva od 1
        }
        public List<T> GetAll()
        {
            return _db;//vrakja db, db e lista od entitetot, vrakja se vo nea
        }

        public T GetById(int id)
        {
            return _db.SingleOrDefault(entity=>entity.Id == id);//vrakja eden entitet
        }

        public int Insert(T entity)
        {
            entity.Id=IdCount;
            _db.Add(entity);
            IdCount++;
            return entity.Id;
        }

        public void RemoveById(int id)
        {
            T entity= _db.SingleOrDefault(entity=>entity.Id==id);//go naogjame soodvetniot entitet
            if (entity != null)
            {
                _db.Remove(entity);//ako e razlicno od nula go briseme
            }
        }

        public void Update(T entity)//naogjame id na toa shto sakame da go smenime, i prakjame novata vrednost na toa id
        {
            T item= _db.SingleOrDefault(item=>item.Id==entity.Id);//go zamenuvame so vlezniot parametar entity
            item = entity;
        }
    }
}
