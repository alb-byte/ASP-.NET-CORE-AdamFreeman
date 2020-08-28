using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_.NET_CORE_AdamFreeman.Models
{
    public class MyRepository:IRepository
    {
        private static MyRepository sharedRepository = new MyRepository();
        private List<GuestResponse> responses =
        new List<GuestResponse>();
        public MyRepository()
        {
            var InitialItems = new GuestResponse[]
            {
                new GuestResponse{Name = "Ali",Email = "ali@gmail.com",Phone = "112233", WillAttend = true},
                new GuestResponse{Name = "Bli",Email = "bli@gmail.com",Phone = "112244", WillAttend = true},
                new GuestResponse{Name = "Cli",Email = "cli@gmail.com",Phone = "112255", WillAttend = true},
                new GuestResponse{Name = "Dli",Email = "dli@gmail.com",Phone = "112266", WillAttend = true},
                new GuestResponse{Name = "Eli",Email = "eli@gmail.com",Phone = "112277", WillAttend = true}
            };
            foreach (var item in InitialItems)
            {
                AddResponse(item);
            }
        }
        public static MyRepository SharedRepository => sharedRepository;
        public IEnumerable<GuestResponse> Responses => responses;
        public void AddResponse(GuestResponse response) => responses.Add(response);
    }

}
