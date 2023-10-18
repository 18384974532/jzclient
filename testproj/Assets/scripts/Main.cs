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
    public class User 
    {
        public static string name;
        public static int id;
        //这里要改sproto的传参 传list和table的用法
        public static float posx;
        public static float posz;
    }

    // Start is called before the first frame update
    private void _join_room(object data)
    {
        var req = new SprotoType.joinroom.request();
        req.user = new SprotoType.User();

        string name = (string)data;
        req.user.name = name;

        System.Random r1 = new System.Random();
        int a = r1.Next(1, 5);
        List<long> pos = new List<long>();
        pos.Add(a);
        pos.Add(a+1);
        req.user.pos = pos;

        User.name = name;
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
        NetReceiver.AddHandler<Protocol.deleteuser>(deleteUser);
    }

    SprotoTypeBase deleteUser(SprotoTypeBase _)
    {
        SprotoType.deleteuser.request rsp = _ as SprotoType.deleteuser.request;
        string name = "pfb" + rsp.name;
        Destroy(GameObject.Find(name));
        return null;
    }

    SprotoTypeBase chatInfoRsp(SprotoTypeBase _)
    {
        SprotoType.chatInfo.request rsp = _ as SprotoType.chatInfo.request;
        Debug.LogFormat("get chatInfo msg: {0}, {1}", rsp.msg, rsp.sender);
        EventManager.Trigger("chat_info", rsp);
        //sender show msg
        return null;
    }

    SprotoTypeBase createUser(SprotoTypeBase _)
    {
        SprotoType.createuser.request rsp = _ as SprotoType.createuser.request;
        var user = new SprotoType.User();
        user = rsp.user;
        Debug.LogFormat("get createuser msg: {0}", user.name);
        GameObject objA = Instantiate(prefab, new Vector3(user.pos[0], 1, user.pos[1]), Quaternion.identity);
        Debug.LogFormat("user nmae: {0}", objA.name);
        objA.name = "pfb" + user.name;
        EventManager.Trigger("userCreate", rsp.user.name);
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
