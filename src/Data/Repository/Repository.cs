using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly FornecedorProdutoContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(FornecedorProdutoContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        #region Busca

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        #endregion Busca

        #region Manipulação

        public virtual async Task Adicionar(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            Db.Entry<TEntity>(entity).State = EntityState.Modified;
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        #endregion Manipulação

        #region Demais

        public void Dispose()
        {
            Db?.DisposeAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        #endregion Demais
    }
}