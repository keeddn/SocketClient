using SocketProto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ClientManager : BaseManager
{
    private Socket socket;
    private Message message;
    public string username;
    public ClientManager(GameFace gameFace) : base(gameFace)
    {
        message = new Message();
    }
    public override void OnAwake()
    {
        
        InitSocket();
        StartReceive();
        base.OnAwake();
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        CloseSocket();
    }
    private void InitSocket()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Debug.Log(socket);
        try
        {
            socket.Connect("127.0.0.1", 6666);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
    private void CloseSocket()
    {
        if (socket != null && socket.Connected)
        {
            socket.Close();
        }
    }

    private void StartReceive()
    {
        socket.BeginReceive(message.Byte, message.EndIndex, message.Remsize, SocketFlags.None, ReceiveCallBack, null);
    }
    private void ReceiveCallBack(IAsyncResult async)
    {
        try
        {
            int len = socket.EndReceive(async);
            if (len == 0)
            {
                CloseSocket();
                return;
            }
            else
            {
                message.ReadMessage(len,HandleMessage);
                StartReceive();
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
    private void HandleMessage(MainPack pack)
    {
        gameFace.HandleMessage(pack);
    }
    public void Send(MainPack pack)
    {
        socket.Send(Message.PackData(pack));
    }
}
