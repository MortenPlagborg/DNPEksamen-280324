using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Data
{
    public interface IChildData
    {
        Task<IList<Child>> getChildAsync();
        Task AddChildAsync(Child children);
        Task RemoveChildAsync(int Id);
    }
}