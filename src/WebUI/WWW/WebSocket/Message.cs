using System;
using System.Threading;
using System.Threading.Tasks;
using WebExpress.WebCore.WebSocket;
using WebExpress.WebCore.WebSocket.Protocol;

namespace WebExpress.Tutorial.WebUI.WWW.WebSocket
{
    public sealed class Message : ISocket
    {
        private readonly ISocketContext _socketContext;
        private readonly ISocketWriteStream _writeStream;

        /// <summary>
        /// Initializes a new instance of the Message class with the specified socket 
        /// context and write stream.
        /// </summary>
        /// <param name="socketContext">
        /// The socket context to associate with this message. Cannot be null.
        /// </param>
        /// <param name="writeStream">
        /// The write stream used to send data over the socket. Cannot be null.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if socketContext or writeStream is null.
        /// </exception>
        public Message(ISocketContext socketContext, SocketWriteStream writeStream)
        {
            _socketContext = socketContext ?? throw new ArgumentNullException(nameof(socketContext), "Parameter cannot be null or empty.");
            _writeStream = writeStream ?? throw new ArgumentNullException(nameof(writeStream), "Parameter cannot be null or empty.");
        }

        /// <summary>
        /// Handles logic to be executed when a new connection is established asynchronously.
        /// </summary>
        /// <param name="connectMessage">
        /// An optional message containing information about the connection request. May 
        /// be null if no message is provided.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used to cancel the asynchronous operation.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        public async Task OnConnectedAsync(ISocketMessage connectMessage = null, CancellationToken cancellationToken = default)
        {
        }

        /// <summary>
        /// Processes an incoming socket message asynchronously.
        /// </summary>
        /// <param name="message">
        /// The message received from the socket to be processed. Cannot be null.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used to cancel the asynchronous operation.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous message processing operation.
        /// </returns>
        public async Task OnReceiveAsync(ISocketMessage message, CancellationToken cancellationToken = default)
        {
        }

        /// <summary>
        /// Handles logic to be executed when a socket connection is disconnected.
        /// </summary>
        /// <param name="closeInfo">
        /// Information about the reason and context for the socket disconnection. Cannot be null.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        public async Task OnDisconnectedAsync(SocketCloseInfo closeInfo)
        {
        }

        /// <summary>
        /// Handles an error asynchronously by processing the specified exception.
        /// </summary>
        /// <param name="exception">
        /// The exception that occurred. Cannot be null.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous error handling operation.
        /// </returns>
        public async Task OnErrorAsync(Exception exception)
        {
        }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
