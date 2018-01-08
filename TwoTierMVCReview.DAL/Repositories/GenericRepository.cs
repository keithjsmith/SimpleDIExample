using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoTierMVCReview.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        //field 
        private readonly ZMoviesEntities _repo;

        //ctor to instantiate our EF context for database communications
        public GenericRepository()
        {
            _repo = new ZMoviesEntities();
        }

        public void Add(TEntity entity)
        {
            //normally we would call _repo.WGProducts or _repo.WGCategory,
            //but we want this to be abstract (or generalized) so we need to 
            //use _repo.Set<TEntity>().Method which represents the generic version
            //of the exact samet hing

            //from our TwoTierMVCReview project
            //db.Set<Employee>().Add(employee);
            // is functionally identical to
            //db.Employees.Add(employee);
            _repo.Set<TEntity>().Add(entity);
            _repo.SaveChanges();
        }

        public TEntity Find(int? Id)
        {
            return _repo.Set<TEntity>().Find(Id);
        }

        public List<TEntity> GetAll()
        {
            return _repo.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            _repo.Set<TEntity>().Remove(entity);
            _repo.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _repo.Set<TEntity>().Remove(entity);
            _repo.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                    _repo.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        //Unmanaged resources would be resources that don't exist in the .net framework so the
        //framework doesn't track and GC them
        // ~GenericRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            //In other words, we did the _repo.Dispose(); manually above, so tell the
            // automatic garbage collection to ignore the _repo object!
             GC.SuppressFinalize(this);
        }
        #endregion
    }
}
