using Microsoft.EntityFrameworkCore;
using ProductsManagement.Application.IRepositories;
using ProductsManagement.Infrastructure.Data;

namespace ProductsManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductDbContext _dbContext;

        public UnitOfWork(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChanges()
        {
            bool returnValue = true;
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {                     
                    returnValue = false;
                    dbContextTransaction.Rollback();
                }
            }

            return returnValue;
        }

        public DbContext GetContext()
        {
            return _dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
