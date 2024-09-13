namespace test_pwi.DL.Services.DAL
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(long id);

        Task<TEntity> Create(TEntity entity);

        Task<TEntity> Update(long id, TEntity entity);

        Task Delete(long id);
    }
}