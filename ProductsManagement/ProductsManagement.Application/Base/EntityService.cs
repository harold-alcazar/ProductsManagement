using ProductsManagement.Application.IRepositories;

namespace ProductsManagement.Application.Base
{
    public abstract class EntityService<T> : IDisposable, IEntityService<T> where T : class
    {
        protected IUnitOfWork _unitOfWork;
        protected IGenericRepository<T> _repository;
        bool disposed = false;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async virtual Task<bool> SaveChanges()
        {
            return await _unitOfWork.SaveChanges();
        }

        public async virtual Task Add(T entity)
        {
            EntityService<T>.Check(entity);
            await _repository.Add(entity);
        }

        public async virtual Task AddRange(IEnumerable<T> items)
        {
            EntityService<T>.Check(items);
            await _repository.AddRange(items);
        }

        public virtual void Delete(T entity)
        {
            EntityService<T>.Check(entity);
            _repository.Delete(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> items)
        {
            EntityService<T>.Check(items);
            _repository.DeleteRange(items);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public async virtual Task<T?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public virtual void Update(T entity)
        {
            EntityService<T>.Check(entity);
            _repository.Update(entity);
        }

        public void UpdateRange(T[] entities)
        {
            EntityService<T>.Check(entities);
            _repository.UpdateRange(entities);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing && _unitOfWork != null)
            {
                _unitOfWork.Dispose();
            }
            disposed = true;
        }

        private static void Check(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        private static void Check(IEnumerable<T> entities)
        {
            foreach (T oneEntity in entities)
            {
                if (oneEntity == null)
                {
                    throw new ArgumentNullException(nameof(entities));
                }
            }
        }
    }
}
