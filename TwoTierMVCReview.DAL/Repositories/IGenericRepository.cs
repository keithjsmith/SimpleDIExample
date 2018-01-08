using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoTierMVCReview.DAL.Repositories
{
    //the where is a generic type constraint
    //it means that the generic type T has to be a 
    //reference type(class, interface, delegate, or array type).
    //It is also a good practice to inherit the IDisposable interface
    //classes IMPLEMENT interfaces, interfaces INHERIT from interfaces
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        //members
        List<TEntity> GetAll();
        TEntity Find(int? Id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        //by inheriting the IDisposable interface we essentially put
        //void Dispose(); as a member
    }
}
