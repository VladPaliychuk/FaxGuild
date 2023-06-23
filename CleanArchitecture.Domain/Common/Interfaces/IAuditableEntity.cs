using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common.Interfaces
{
    public interface IAuditableEntity : IEntity
    {
        DateTime? CreatedTime { get; set; }
        DateTime? UpdatedTime { get; set; }
    }
}
