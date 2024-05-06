using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        //CargoContext c = new CargoContext();
        //DbSet<T> _object;
        //public GenericRepository()
        //{
        //    _object = c.Set<T>();
        //}
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            //var value = c.Entry(id);
            //value.State= EntityState.Deleted;
            //c.SaveChanges();
            var values = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(values);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            //return _object.ToList();
            var values = _context.Set<T>().ToList();
            return values;
        }

        public T GetById(int id)
        {
            //return _object.Find(id);
            var value = _context.Set<T>().Find(id);
            return value;
        }

        public void Insert(T entity)
        {
            //var value=c.Entry(entity);
            //value.State= EntityState.Added;
            //c.SaveChanges();
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            //var value=c.Entry(entity);
            //value.State= EntityState.Modified;
            //c.SaveChanges();
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
