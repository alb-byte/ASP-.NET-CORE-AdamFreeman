using ASP_.NET_CORE_AdamFreeman.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class GuestResponseTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { GetGuestResponses1() };
            yield return new object[] { GetGuestResponses2() };

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private GuestResponse[] GetGuestResponses1() => new GuestResponse[]
        {
            new GuestResponse{Name = "Ali",Email = "aaa",Phone = "112233", WillAttend = true},
            new GuestResponse{Name = "Bli",Email = "bbb",Phone = "112244", WillAttend = true},
            new GuestResponse{Name = "Cli",Email = "ccc",Phone = "112255", WillAttend = true},
            new GuestResponse{Name = "Dli",Email = "ddd",Phone = "112266", WillAttend = true},
            new GuestResponse{Name = "Eli",Email = "eee",Phone = "112277", WillAttend = true}
        };
        private GuestResponse[] GetGuestResponses2() => new GuestResponse[]
        {
            new GuestResponse{Name = "Ali",Email = "aab",Phone = "112233", WillAttend = true},
            new GuestResponse{Name = "Bli",Email = "bbc",Phone = "112244", WillAttend = true},
            new GuestResponse{Name = "Cli",Email = "ccd",Phone = "112255", WillAttend = true},
            new GuestResponse{Name = "Dli",Email = "dde",Phone = "112266", WillAttend = true},
            new GuestResponse{Name = "Eli",Email = "eef",Phone = "112277", WillAttend = true}
        };
    }
}
