using UnityEngine;
using System;
using WebSocketSharp;

public class CameraController : MonoBehaviour 
{
    public GameObject player;
    Vector3 offset;
    WebSocket ws;

    void Start () 
    {
        offset = transform.position;
        ws = new WebSocket("ws://localhost:8080");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message Received from "+((WebSocket)sender).Url + ", Data : "+e.Data);
        };
    }

    void LateUpdate () 
    {
        transform.position = player.transform.position + offset;
    }
 void Update()
    {
        if(ws == null)
        {
            return;
        }
if (Input.GetKeyDown(KeyCode.Space))
        {
            ws.Send("Hello");
        }  
    }
}