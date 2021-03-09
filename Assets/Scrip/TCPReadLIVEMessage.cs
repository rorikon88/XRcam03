using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TCPReadLIVEMessage : MonoBehaviour
{
    TextAsset t;
    public GameObject[] chat = new GameObject[6];
    public int i=1;
    string s;

  


    void Start()
    {
        //chat[0].GetComponent<Text>().text = "哈囉";
        for (i = 0; i < 6; i++)
        {
            chat[i].GetComponent<Text>().text = "0";
        }
        i = 0;
        //Connect();
    }

    private const int portNum = 26950;
    private const string hostName = "127.0.0.1";
    private void Update()
    {

       // while (true)
       // {

            try
            {
               // var client = new TcpClient(hostName, portNum);
             TcpClient client;
             client = new TcpClient(hostName, portNum);
             NetworkStream ns = client.GetStream();

                byte[] bytes = new byte[4096];
                int bytesRead = ns.Read(bytes, 0, bytes.Length);

                // t = Resources.Load<TextAsset>(Encoding.ASCII.GetString(bytes, 0, bytesRead));
                chat[1].GetComponent<Text>().text = Encoding.ASCII.GetString(bytes, 0, bytesRead);

                client.Close();

            }
            catch (Exception e)
            {
            i++;
            chat[2].GetComponent<Text>().text = i.ToString();
            //Console.WriteLine(e.ToString());

              }
       // }
        

        

       // if (Input.GetKeyDown("space")){
       /*
            t = Resources.Load<TextAsset>("Write");
            
            if(s != t.text)
            {
                s = t.text;
                i++;
                if (i >= 6) i = 0;
                chat[i].GetComponent<Text>().text = s;
            }
       */
            //GetComponent<Text>().text = s;
            //chat[0].text = s;
           // Debug.Log(s);
        //}
        
    }
}
