using Microsoft.EntityFrameworkCore;

namespace ProductsManagement.Application.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext GetContext();

        Task<bool> SaveChanges();
    }
}
