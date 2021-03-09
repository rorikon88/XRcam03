using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPReadLIVEMessage : MonoBehaviour
{
    TextAsset t;
    public GameObject[] chat = new GameObject[6];
    public int i=1;
    string s,last_s;

    private IPEndPoint ipEndPoint;
    private UdpClient udpClient;
    private Thread receiveThread;
    private byte[] receiveByte;
    private string receiveData = "";


    void Start()
    {
        //chat[0].GetComponent<Text>().text = "哈囉";
        for (i = 0; i < 6; i++)
        {
            chat[i].GetComponent<Text>().text = "0";
        }
        i = 0;

        ipEndPoint = new IPEndPoint(IPAddress.Any, 5501);
        udpClient = new UdpClient(ipEndPoint.Port);

        receiveThread = new Thread(ReceiveData);
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }

    void Update()
    {

        // if (Input.GetKeyDown("space")){

       // chat[1].GetComponent<Text>().text = s;

       //  t = Resources.Load<TextAsset>(receiveData);

         if(s != last_s)
         {
             last_s = s;
             i++;
             if (i >= 6) i = 0;
             chat[i].GetComponent<Text>().text = s;
         }
        //GetComponent<Text>().text = s;
        //chat[0].text = s;
        // Debug.Log(s);
        //}
    }

    void ReceiveData()
    {
        while (true)
        {
            receiveByte = udpClient.Receive(ref ipEndPoint);
            receiveData = System.Text.Encoding.UTF8.GetString(receiveByte);

            s = receiveData;
            //chat[1].GetComponent<Text>().text = s;
            //Debug.Log("接收到：" + s);
        }
    }

    private void OnDisable()
    {
        udpClient.Close();
        receiveThread.Join();
        receiveThread.Abort();
    }

    private void OnApplicationQuit()
    {
        receiveThread.Abort();
    }

}
