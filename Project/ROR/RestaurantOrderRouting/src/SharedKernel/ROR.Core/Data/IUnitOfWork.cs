using System.Threading.Tasks;

namespace ROR.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
