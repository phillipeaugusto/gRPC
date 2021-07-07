using System.Threading.Tasks;
using DomainInfo.Entity;

namespace ServerInfo.Repository.Contracts
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<bool> ExistsByDescription(string description);
    }
}