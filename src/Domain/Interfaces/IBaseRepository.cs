using System.Transactions;

namespace ExampleStore.src.Domain.Interfaces;

public interface IBaseRepository
{
    public void BeginTransaction();
    public void CommitChanges();
    public void Rollback();
}