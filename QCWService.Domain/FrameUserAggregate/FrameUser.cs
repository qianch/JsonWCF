using QCWService.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCWService.Domain.FrameUserAggregate
{
    public class FrameUser : Entity, IAggregateRoot
    {
        public Guid UserGuid { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
    }
}
