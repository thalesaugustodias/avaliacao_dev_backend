using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Entities;

namespace Vectra.Avaliacao.Backend.Interfaces
{
    public interface IEFContext
    {
        DbSet<Conta> Contas { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
