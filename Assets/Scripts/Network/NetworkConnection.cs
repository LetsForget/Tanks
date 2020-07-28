using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;

public class NetworkConnection : MonoBehaviour
{
    public static NetworkConnection Instance;

    public string IP;

    public int Port;
    public int MaximumConnections;

    private byte UnreliableCh;
    private byte ReliableCh;
    private int HostId;
    private int ConnectionId;

    private byte[] Buffer;
    public int BufferSize;

    [System.Obsolete]
    void Start()
    {
        Instance = this;

        ConnectionConfig cc = new ConnectionConfig();
        UnreliableCh = cc.AddChannel(QosType.Unreliable);
        ReliableCh = cc.AddChannel(QosType.Reliable);
        HostTopology ht = new HostTopology(cc, MaximumConnections);

        NetworkTransport.Init();

        HostId = NetworkTransport.AddHost(ht, 0);
        ConnectionId = NetworkTransport.Connect(HostId, IP, Port, 0, out byte error);


        if ((NetworkError)error != NetworkError.Ok)
        {
            Debug.Log("Message send error: " + (NetworkError)error);
        }
    }

    [System.Obsolete]
    public void SendData(byte[] data)
    {
        NetworkTransport.Send(HostId, ConnectionId, UnreliableCh, data, BufferSize, out byte error);

        if ((NetworkError)error != NetworkError.Ok)
        {
            Debug.Log("Message send error: " + (NetworkError)error);
        }
    }
}