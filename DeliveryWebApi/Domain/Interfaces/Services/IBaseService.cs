namespace DeliveryWebApi.Domain.Interfaces.Services;

public interface IBaseService<BaseEntity> where BaseEntity : class
{
    public Task AddAsync(BaseEntity baseEntity);

    public Task UpdateAsync(int id, JsonPatchDocument<BaseEntity> basePatchEntity);

    public Task DeleteAsync(BaseEntity baseEntity);

    public Task<IEnumerable<BaseEntity>> GetListAsync();

}
