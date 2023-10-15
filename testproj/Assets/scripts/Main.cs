using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Sproto;
using SprotoType;

public class Main : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> userObjs = new List<GameObject>();
    //由于玩家发送请求的时候需要知道是玩家调用的，比如聊天请求，所以这里的想法是将玩家的object等相应消息声明为全局变量，这样每次主动调用请求的时候就知道是玩家在调用
    public static class User 
    {
        public static string name;
        public static int id;
    }

    // Start is called before the first frame update
    private void _join_room(object data)
    {
        var req = new SprotoType.joinroom.request();
        req.pos = 0;
        string name = (string)data;
        User.name = name;
        req.name = name;
        Debug.Log("send joinroom server");
        NetSender.Send<Protocol.joinroom>(req);
    }
    private void Awake() {
        EventManager.AddListener("get_name", _join_room);
    }

    void Start()
    {
        NetCore.Init();
        NetSender.Init();
        NetReceiver.Init();
        NetCore.enabled = true;
        NetCore.Connect("123.249.92.14", 8888, () =>
        {
            // 连接结果
            Debug.Log("connect result: " + NetCore.connected);
            if(NetCore.connected)
            {
                //SendSayHello();
                //Chat();
                //joinRoom();
            }
        });
        NetReceiver.AddHandler<Protocol.chatInfo>(chatInfoRsp);
        NetReceiver.AddHandler<Protocol.createuser>(createUser);
    }

    SprotoTypeBase chatInfoRsp(SprotoTypeBase _)
    {
        SprotoType.chatInfo.request rsp = _ as SprotoType.chatInfo.request;
        Debug.LogFormat("get chatInfo msg: {0}", rsp.msg, rsp.sender);
        EventManager.Trigger("chat_info", rsp);
        //sender show msg
        return null;
    }

    SprotoTypeBase createUser(SprotoTypeBase _)
    {
        SprotoType.createuser.request rsp = _ as SprotoType.createuser.request;
        Debug.LogFormat("get createuser msg: {0}", rsp.pos);
        System.Random r1 = new System.Random();
        int a = r1.Next(1,10);
        Debug.LogFormat("postion: {0}", a);
        GameObject objA = Instantiate(prefab, new Vector3(a, 0, a - 1), Quaternion.identity);
        objA.name = rsp.name;
        return null;
    }

    //这里可以将调用的方法通过传参抽象出来, 先不写
    SprotoTypeBase playerMove(SprotoTypeBase _)
    {
        SprotoType.playermove.request rsp = _ as SprotoType.playermove.request;
        Debug.LogFormat("get move msg, username: {0}, move : {1}", rsp.name, rsp.move_msg);
        return null;
    }

    void SendSayHello()
    {
        var req = new SprotoType.sayhello.request();
        req.what = "hi, im xushuaige";
        Debug.Log("send msg to server");
        NetSender.Send<Protocol.sayhello>(req, (data) =>
        {
            var rsp = data as SprotoType.sayhello.response;
            Debug.LogFormat("server seyhello response, error_code: {0}, msg: {1}", rsp.error_code, rsp.msg);
        });
    }

    // Update is called once per frame
    void Update()
    {
        NetCore.Dispatch();
    }
}
