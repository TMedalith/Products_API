namespace si730ebu20211F955.API.Inventory.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}