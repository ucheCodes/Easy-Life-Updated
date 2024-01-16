using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Hosting;
using HKBlog.Models;

namespace HKBlog.UI.Data
{
    public class AppHub : Hub
    {
        public const string HubUrl = "/signalr";
        public async void SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("Send", user, message);
        }
        public async void DeleteReview(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                await Clients.All.SendAsync("DeleteReview", id);
            }
        }
        public async void AddReview(Review review)
        {
            if (review.Id != "" && review.Comment != "")
            {
                await Clients.All.SendAsync("AddReview", review);
            }
        }
    }
}
