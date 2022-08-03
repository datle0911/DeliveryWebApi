namespace DeliveryWebApi.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    public Task SaveChanges();
}
