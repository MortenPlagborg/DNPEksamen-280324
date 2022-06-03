using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Data
{
    public interface IToyData
    {
        Task<IList<Toy>> getToysAsync();
        Task AddToyAsync(Toy toys);
        Task RemoveToyAsync(string Name);
    }
}