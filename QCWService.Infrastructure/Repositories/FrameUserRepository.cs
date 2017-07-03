using QCWService.Domain.FrameUserAggregate;
using QCWService.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCWService.Infrastructure.Repositories
{
    public class FrameUserRepository : IFrameUserRepository
    {
        private readonly FrameContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public FrameUserRepository(FrameContext context)
        {
            _context = context.Init();
        }

        public long Add(FrameUser frameUser)
        {
            return _context.FrameUser.Insert(frameUser);
        }

        public IEnumerable<FrameUser> All()
        {
            return _context.FrameUser.All() as IEnumerable<FrameUser>;
        }

        public void Update(FrameUser frameUser)
        {
            _context.FrameUser.Update(frameUser.ID, frameUser);
        }
    }
}
