using System.Collections;
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
    public GameObject User;
    private void Awake() {
        EventManager.AddListener("chat_info", _chat_info);
        EventManager.AddListener("userCreate", _user_create);
        EventManager.AddListener("quitRoom", _quit_room);
    }
    private void _quit_room(object data)
    {
        string name = (string)data;
        if(name == User.name)
        {
            var req = new SprotoType.quitroom.request();
            req.name = User.name;
            Debug.LogFormat("username:{0}", req.name);
            NetSender.Send<Protocol.quitroom>(req);
            Application.Quit();
        }
        
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
        Debug.LogFormat("username:{0}", User.name);
        if(User.name == "Player")
        {
            Debug.LogFormat("username11:{0}", name);
            User.name = name;
            UserName.text = name;
            UserName.GetComponent<CanvasGroup>().alpha = 1;
            EventManager.Trigger("usercreateUi");
            EventManager.Trigger("setCamera", name);
        }
    }
    private void _chat_info(object data)
    {
        SprotoType.chatInfo.request rsp = (SprotoType.chatInfo.request)data;
        if(User.name == rsp.sender)
        {
            string chat_msg = rsp.msg;
            ChatInfo.GetComponent<CanvasGroup>().alpha = 1;
            ChatInfo.text = chat_msg;
            Invoke("disableChat", 3);
    }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
