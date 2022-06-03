using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.DataAccess;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class ChildDBData : IChildData
    {
        private KinderGartenContext ctx;
        private IList<Child> children;

        public ChildDBData(KinderGartenContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<IList<Child>> getChild()
        {
            return await ctx.Children.ToListAsync();
        }

        public async Task<Child> addChild(Child children)
        {
            EntityEntry<Child> newChild = await ctx.Children.AddAsync(children);
            await ctx.SaveChangesAsync();
            return newChild.Entity;
        }

        public async Task removeChild(string name)
        {
            Child removeChild = await ctx.Children.FirstOrDefaultAsync(t => t.Name == name);
            if (removeChild != null)
            {
                ctx.Children.Remove(removeChild);
                await ctx.SaveChangesAsync();
            }
        }
    }
}