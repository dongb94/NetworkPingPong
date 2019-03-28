﻿
using System.IO;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UnityClient : MonoBehaviour
{

    public void ConnectServer()
    {
        TcpClient tc = new TcpClient("221.144.2.165", 80);
        string msg = "Hellow C#";
        byte[] buff = Encoding.ASCII.GetBytes(msg);

        NetworkStream stream = tc.GetStream();
        
        stream.Write(buff, 0, buff.Length);

        byte[] output = new byte[1024];
        int nbytes = 0;
        MemoryStream mem = new MemoryStream();
        while ((nbytes = stream.Read(output, 0, output.Length))>0)
        {
            mem.Write(output, 0, nbytes);
        }
        
        stream.Close();
        tc.Close();
        
        string outToByte = Encoding.ASCII.GetString(mem.ToArray());
        
        Debug.Log(outToByte);
    } 
}
