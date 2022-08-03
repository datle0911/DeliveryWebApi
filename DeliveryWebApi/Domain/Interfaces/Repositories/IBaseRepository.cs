namespace DeliveryWebApi.Domain.Interfaces.Repositories;

public interface IBaseRepository<BaseEntity> where BaseEntity : class
{
    public Task<BaseEntity?> FindByIdAsync(int id);
    public Task Add(BaseEntity baseEntity);
    public void Delete(BaseEntity baseEntity);
    public Task<IEnumerable<BaseEntity>> GetListAsync();
}
