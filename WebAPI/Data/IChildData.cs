using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IChildData
    {
        Task<IList<Child>> getChild();
        Task<Child> addChild(Child children);
        Task removeChild(string name);
    }
}