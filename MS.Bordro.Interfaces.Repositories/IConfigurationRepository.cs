using MS.Bordro.Domain.Entities.BaseEntities;

namespace MS.Bordro.Interfaces.Repositories
{
    public interface IConfigurationRepository<T>: IRepository<T> where T: BaseModel
    {
        T[] GetActiveValues();
    }
}
