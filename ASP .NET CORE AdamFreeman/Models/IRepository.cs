using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_.NET_CORE_AdamFreeman.Models
{
    public interface IRepository
    {
        IEnumerable<GuestResponse> Responses { get; }
        void AddResponse(GuestResponse response);
    }
}
