using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.IO;
using System.Threading;

public class Client {

    private static readonly Client instance = new Client();
    public static  Client Instance {
        get {
            return instance;
        }
    }

    #region 变量
    //接收消息队列
    private ReceiveProtoMessageQueue recvMsgQueue = new ReceiveProtoMessageQueue();
    //发送消息队列
    private SendProtoMessageQueue sendMsgQueue = new SendProtoMessageQueue();
    //与服务器连接通道
    private TcpClient tcpClient = null;
    //与服务器连接的数据流
    private Stream stream = null;
    //接收消息线程
    private Thread recvMsgThread = null;
    //发送消息线程
    private Thread sendMsgThread = null;

    //断线编号
    private int SERVER_DISCONNECTED = -1;

    private int CLIENT_ERROR = -100;

    #endregion


    static Client()
    {
    }

    Client() { }


    #region 系统对外接口

    public bool Connect(string host, int port)
    {
        if (tcpClient == null)
        {
            try
            {
                tcpClient = new TcpClient(host, port);
                tcpClient.NoDelay = true;
                stream = tcpClient.GetStream();
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Connect error!");
                Debug.LogError(ex.ToString());
                Debug.LogError(ex.StackTrace);
                return false;
            }

            //启动收发线程
         //   recvMsgThread = new Thread(new ThreadStart(RecvMsgLoop));
         //   sendMsgThread = new Thread(new ThreadStart(SendMsgLoop));

            recvMsgThread.Start();
            sendMsgThread.Start();

            return true;
        }
        else {
            return false;
        }
    }


    #endregion

}
