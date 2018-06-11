using System;
using System.Collections.Generic;
using System.Text;

namespace PhonemikeServer.WebApi.Hubs
{
    public class PhoneClientModel
    {
        public string ConnectionId;

        public string LocalIpAddress;

        public string LocalPort;

        public string RemoteIpAddress;

        public string RemotePort;
    }
}
