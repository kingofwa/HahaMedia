using System.Threading.Tasks;

namespace HahaMedia.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
