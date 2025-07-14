using NajotTalim.HR.DataAccess.Entities;
using System.Threading.Tasks;
namespace NajotTalim.HR.DataAccess
{
    public interface IGenericRepository<TRepo> where TRepo : class
    {
        Task<TRepo> Create(TRepo data);

        Task<IEnumerable<TRepo>> GetAll();

        Task<TRepo> Get(int id);
        Task<TRepo> Update(int id, TRepo data);
        Task<bool> Delete(int id);
    }
}

