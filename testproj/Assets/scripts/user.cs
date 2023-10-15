using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sproto;
using SprotoType;

public class user : MonoBehaviour
{
    //public float = 1.0f;
    // Start is called before the first frame update
    private void Awake() {
        EventManager.AddListener("chat_info", _chat_info);
    }
    public void getInfo(string msg)
    {
        Debug.LogFormat("user get chatInfo {0}", msg);
    }
    private void _chat_info(object data)
    {
        SprotoType.chatInfo.request rsp = (SprotoType.chatInfo.request)data;
        GameObject user = GameObject.Find(rsp.sender);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
