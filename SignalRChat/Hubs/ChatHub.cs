using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
	public class ChatHub : Hub
	{
		//method that recive the name of the user and the message and send them to onther methods on client level
		public async Task SendMessage(string user, string message)
		{
			//Clients: descripe the connected clients with the applic
			// All; descripte that i want to send the recived message for all connected users
			//ReccieveMessage: is the name of the method that will be in the clientside that will recive the message

			await Clients.All.SendAsync("ReceiveMessage", user, message);
			// if i want to send the response to my self to one who initialise the request
			await Clients.Caller.SendAsync("ReceiveMessage", user, message);
			//if i want to send the response to otheres client except the caller/myself
			await Clients.Others.SendAsync("ReceiveMessage", user, message);
			// if i want to send the respone to a specific client using coonection Id
			await Clients.Client("connection Id").SendAsync("ReceiveMessage", user, message);
			//if i want to send the message for all clients except of a specific client
			await Clients.AllExcept("connection Id").SendAsync("ReceiveMessage", user, message);
			//if i want to send a notification a bout a specific process to athe user for example export excel 
			//and notify him when the process is finished
			await Clients.User("uer email").SendAsync("ReceiveMessage", user, message);


		}
	}
}
