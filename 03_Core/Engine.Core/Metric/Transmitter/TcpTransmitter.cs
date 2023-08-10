using System.Net.Sockets;
using System.Text;
using Engine.Core.Metric.Abstraction;

namespace Engine.Core.Metric.Transmitter;

/// <summary>
///     This class implements the IMetricsTransmitter interface and provides the specific
///     behavior for transmitting performance metrics over a TCP connection.
/// </summary>
public class TcpTransmitter : IMetricsTransmitter
{
    private readonly NetworkStream? _stream;

    public TcpTransmitter(string hostname, int port)
    {
        try
        {
            var client = new TcpClient(hostname, port);
            _stream = client.GetStream();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    ///     Transmits the specified performance metrics over the TCP connection.
    /// </summary>
    public void Transmit()
    {
        if (_stream != null && _stream.CanWrite)
        {
            var data = Encoding.UTF8.GetBytes(PerformanceMetricManager.Instance.ToJson());
            _stream.WriteAsync(data, 0, data.Length);
        }
    }
}
