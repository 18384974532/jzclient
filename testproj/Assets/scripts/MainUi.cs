using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using Sproto;
using SprotoType;

public class MainUi : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_InputField inputFiledChat;
    public Button quitButton;
    public GameObject objName;
    // Start is called before the first frame update
    void Start()
    {
        inputField.onEndEdit.AddListener(delegate { InputEndName(inputField); });
        inputFiledChat.onEndEdit.AddListener(delegate {InputEndChat(inputFiledChat); });
        quitButton.onClick.AddListener(OnClick);
        EventManager.AddListener("usercreateUi", _user_create_ui);
    }

    private void _user_create_ui()
    {
        quitButton.GetComponent<CanvasGroup>().alpha = 1;
        inputFiledChat.GetComponent<CanvasGroup>().alpha = 1;
    }

    private void OnClick()
    {
        EventManager.Trigger("quitRoom", Main.User.name);
    }

    private void InputEndName(TMP_InputField inputField)
    {
        UnityEngine.Debug.Log("press enter:" + inputField.text);
        string msg = inputField.text;
        if(msg!=string.Empty)
        {
            EventManager.Trigger("get_name", inputField.text);
            //inputField.GetComponent<CanvasGroup>().alpha = 0;
            objName.SetActive(false);
        }
        
    }

    private void InputEndChat(TMP_InputField inputField)
    {
        UnityEngine.Debug.Log("chat info"  + inputField.text);
        string msg = inputField.text;
        if(msg!= string.Empty)
        {
            inputField.text = string.Empty;
            Chat(msg);
        }
    }

    void Chat(string msg)
    {
        var req = new SprotoType.chat.request();
        req.sender = Main.User.name;
        req.msg = msg;
        UnityEngine.Debug.Log("chat msg to server sender:" + Main.User.name);
        NetSender.Send<Protocol.chat>(req, (data) =>
        {
            var rsp = data as SprotoType.chat.response;
            UnityEngine.Debug.LogFormat("server chat response, error_code: {0}, msg: {1}", rsp.error_code, rsp.msg);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
