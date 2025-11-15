using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task JoinDoctorGroup(string doctorId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"Doctor_{doctorId}");
        }

        public async Task LeaveDoctorGroup(string doctorId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Doctor_{doctorId}");
        }

        public async Task JoinReceptionistGroup()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Receptionist");
        }

        public async Task LeaveReceptionistGroup()
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Receptionist");
        }

        public async Task JoinAdminGroup()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Admin");
        }

        public async Task LeaveAdminGroup()
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Admin");
        }

        public async Task JoinUserGroup(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"User_{userId}");
        }

        public async Task LeaveUserGroup(string userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"User_{userId}");
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}









