using QCWService.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCWService.Domain.FrameUserAggregate
{
    public interface IFrameUserRepository : IRepository<FrameUser>
    {
        long Add(FrameUser order);
        void Update(FrameUser order);
    }
}
