using System.Threading.Tasks;

namespace my_cny.API.Data
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
    }
}