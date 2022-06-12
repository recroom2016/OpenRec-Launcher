using System;
using System.IO;
using System.Net;
using WebSocketSharp;
using WebSocketSharp.Server;
using OpenRec2;

namespace OpenRec2
{
	// Token: 0x02000010 RID: 16
	internal class WebSocket
	{
		// Token: 0x06000031 RID: 49 RVA: 0x000066D4 File Offset: 0x000048D4
		public WebSocket()
		{
			WebSocketServer webSocketServer = new WebSocketServer(string.Format("ws://localhost:20161", Array.Empty<object>()));
			webSocketServer.AddWebSocketService<WebSocket.NotificationV2>("/api/notification/v2");
			webSocketServer.AddWebSocketService<WebSocket.NotificationV2>("/hub/v1");
			webSocketServer.Start();
			Program.ConsoleWrite("[WebSocket.cs] has started.");
			Program.ConsoleWrite("[WebSocket.cs] is listening.");
		}

		// Token: 0x02000058 RID: 88
		public class NotificationV2 : WebSocketBehavior
		{
			// Token: 0x0600023F RID: 575 RVA: 0x0000BDF8 File Offset: 0x00009FF8
			protected override void OnMessage(MessageEventArgs e)
			{
				Program.ConsoleWrite("WebSocket.cs called for.");
				base.Send(Websocketapi.Notification.ProcessRequest(e.Data));
			}
		}
	}
}
