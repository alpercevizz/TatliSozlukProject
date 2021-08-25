using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object; // T'nin değeri hangi class'a denk geliyor bilmiyoruz. Bu yüzden constructor oluştururuz.

        public GenericRepository()
        {
            _object = c.Set<T>(); // Dışarıdan gönderdiğimiz entity ne ise o olacak.
        }


        public void Delete(T entity)
        {

            var deletedEntity = c.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _object.Remove(entity);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); // sadece bir tane değer döndürür.
        }

        public void Insert(T entity)
        {
            var addedEntity = c.Entry(entity);
            addedEntity.State = EntityState.Added; // Ekleme işlemi entity state içerisinde.
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList(); // filterdan gelen değeri listeler. 
        }

        public void Update(T entity)
        {
            var updatedEntity = c.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
