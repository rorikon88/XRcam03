using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
public class ReadLIVEMessage : MonoBehaviour
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
    }

    void Update()
    {

       // if (Input.GetKeyDown("space")){
            t = Resources.Load<TextAsset>("Write");
            
            if(s != t.text)
            {
                s = t.text;
                i++;
                if (i >= 6) i = 0;
                chat[i].GetComponent<Text>().text = s;
            }
            //GetComponent<Text>().text = s;
            //chat[0].text = s;
           // Debug.Log(s);
        //}
    }
}
