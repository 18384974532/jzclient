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

using UnityEngine.InputSystem;

public class MainUi : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_InputField inputFiledChat;
    public GameObject objName;
    public GameObject EscMenu;
    public GameObject ChatContent;
    public static bool PlayerIsChat = false;
    // Start is called before the first frame update
    void Start()
    {
        inputField.onEndEdit.AddListener(delegate { InputEndName(inputField); });
        UnityEngine.Debug.Log("init name input" + inputField.text);
        EventManager.AddListener("usercreateUi", _user_create_ui);
    }

    private void _user_create_ui()
    {
        inputFiledChat.GetComponent<CanvasGroup>().alpha = 1;
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
            ChatContent.SetActive(false);
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

    public void Pause(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            UnityEngine.Debug.Log("press" + context.phase);
            EventManager.Trigger("PausePress");
        }
    }

    public void EnterPress(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            UnityEngine.Debug.Log("chat info"  + inputFiledChat.text);
            if(PlayerIsChat)
            {
                if(inputFiledChat.text == string.Empty)
                {
                    Cursor.visible = false;
                    PlayerIsChat = !PlayerIsChat;
                    ChatContent.SetActive(false);
                }
                else
                {
                    string msg = inputFiledChat.text;
                    inputFiledChat.text = string.Empty;
                    Chat(msg);
                    inputFiledChat.ActivateInputField();
                }
                
            }
            else
            {
                ChatContent.SetActive(true);
                inputFiledChat.ActivateInputField();
                Cursor.visible = true;
                PlayerIsChat = !PlayerIsChat;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
