using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace PhonemikeServer.WebApi.Hubs
{
    public class ChatHub : Hub
    {
        public static Guid CurManageClientMark = Guid.NewGuid();

        public static List<PhoneClientModel> clientList = new List<PhoneClientModel>();

        private const string AdminGroupName = "AdminGroup";


        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public Task MarkManageClient(Guid adminClientMark)
        {
            if (adminClientMark == CurManageClientMark)
            {
                Groups.AddToGroupAsync(Context.ConnectionId, AdminGroupName);
            }
            RefreshClientList();
            return Task.CompletedTask;
        }

        /// <summary>
        /// 向管理员客户端发送当前Signalr连接情况
        /// </summary>
        /// <returns></returns>
        public Task RefreshClientList()
        {
            Clients.Group(AdminGroupName).SendAsync("RefreshClientList", clientList);
            return Task.CompletedTask;
        }

        public override Task OnConnectedAsync()
        {
            base.OnConnectedAsync();

            var connection = Context.GetHttpContext().Connection;

            clientList.Add(new PhoneClientModel
            {
                ConnectionId = Context.ConnectionId,
                LocalIpAddress = connection.LocalIpAddress.ToString(),
                LocalPort = connection.LocalPort.ToString(),
                RemoteIpAddress = connection.RemoteIpAddress.ToString(),
                RemotePort = connection.RemotePort.ToString()
            });
            RefreshClientList();
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            
            base.OnDisconnectedAsync(exception);
            clientList.RemoveAll(a => a.ConnectionId == Context.ConnectionId);
            RefreshClientList();
            return Task.CompletedTask;
        }
    }
}
