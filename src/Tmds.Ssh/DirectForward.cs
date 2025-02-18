// This file is part of Tmds.Ssh which is released under MIT.
// See file LICENSE for full license details.

using System.Net;
using Microsoft.Extensions.Logging;

namespace Tmds.Ssh;

public sealed class DirectForward : IDisposable
{
    private readonly LocalForwardServer<DirectForward> _forwarder;

    internal DirectForward(ILogger<DirectForward> logger)
    {
        _forwarder = new(logger);
    }

    internal ValueTask StartAsync(SshSession session, EndPoint bindEP, RemoteEndPoint remoteEndPoint, CancellationToken cancellationToken)
        => _forwarder.StartDirectForwardAsync(session, bindEP, remoteEndPoint, cancellationToken);

    public EndPoint LocalEndPoint
        => _forwarder.LocalEndPoint;

    public CancellationToken Stopped
        => _forwarder.Stopped;

    public void ThrowIfStopped()
        => _forwarder.ThrowIfStopped();

    public void Dispose()
        => _forwarder.Dispose();
}