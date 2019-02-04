using ErpDDDBasico.Domain.Interfaces.Repository;
using ErpDDDBasico.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErpDDDBasico.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ErpDDDBasicoContext _erpDDDBasicoContext = new ErpDDDBasicoContext();

        public void Add(TEntity entity)
        {
            _erpDDDBasicoContext.Set<TEntity>().Add(entity);
            _erpDDDBasicoContext.SaveChanges();
        }

        public void Dispose()
        {
            _erpDDDBasicoContext.Dispose();
        }

        public List<TEntity> GetAll()
        {
            return _erpDDDBasicoContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _erpDDDBasicoContext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            _erpDDDBasicoContext.Set<TEntity>().Remove(entity);
            _erpDDDBasicoContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _erpDDDBasicoContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _erpDDDBasicoContext.SaveChanges();
        }
    }
}
