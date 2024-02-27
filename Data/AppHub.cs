using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Hosting;
using HKBlog.Models;
using HKBlog.UI.Views;
using HKBlog.States.SubStates;

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
        public async void UpdateProducts(List<Product> products)
        {
            await Clients.All.SendAsync("UpdateProducts", products);
        }
        public async void NewOrderReceived(NewOrder order)
        {
            await Clients.All.SendAsync("NewOrderReceived", order);
        }
        public async void OrderReceived(Orders order)
        {
            await Clients.All.SendAsync("OrderReceived", order);
        }
        public async void AddNewWalletUpdate(Wallet wallet, AccountNotification notification)
        {
            await Clients.All.SendAsync("NewWalletUpdate", wallet, notification);
        }
        public async void AddNewUser(User user,string operation)
        {
            await Clients.All.SendAsync("AddNewUser", user, operation);
        }
    }
}
