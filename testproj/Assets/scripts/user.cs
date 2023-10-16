﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sproto;
using SprotoType;
using TMPro;

public class user : MonoBehaviour
{
    //public float = 1.0f;
    // Start is called before the first frame update
    public TMP_Text ChatInfo;
    public TMP_Text UserName;
    private void Awake() {
        EventManager.AddListener("chat_info", _chat_info);
        EventManager.AddListener("userCreate", _user_create);
    }
    public void getInfo(string msg)
    {
        Debug.LogFormat("user get chatInfo {0}", msg);
    }
    private void disableChat()
    {
        ChatInfo.GetComponent<CanvasGroup>().alpha = 0;
    }
    private void _user_create(object data)
    {
        string name = (string)data;
        UserName.text = name;
        UserName.GetComponent<CanvasGroup>().alpha = 1;
    }
    private void _chat_info(object data)
    {
        SprotoType.chatInfo.request rsp = (SprotoType.chatInfo.request)data;
        GameObject user = GameObject.Find(rsp.sender);
        string chat_msg = rsp.msg;
        ChatInfo.GetComponent<CanvasGroup>().alpha = 1;
        ChatInfo.text = chat_msg;
        Invoke("disableChat", 3);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
