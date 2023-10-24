﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance = 8;
    public float rot = 0;
    private float roll = 30f * Mathf.PI * 2 / 360;
    private GameObject target;
    public float rotSpeed = 0.2f;
    private float maxRoll = 70f * Mathf.PI * 2 / 360;
    private float minRoll = -10f * Mathf.PI * 2 / 360;
    private float rollSpeed = 0.2f;
    public float maxDistance = 22f;
    public float minDistance = 5;
    public float zoomSpeed = 0.2f;

    void Start()
    {
        EventManager.AddListener("setCamera", _set_camera);
        EventManager.AddListener("senChange", _sen_change);
    }

    void _sen_change(object data)
    {
        float sen = (float)data;
        sen = sen/10 + 0.05f;
        rollSpeed = sen;
        rotSpeed = sen;
    }

    private void _set_camera(object data)
    {
        string name = (string)data;
        Debug.LogFormat("username:{0}, {1}", name, Main.User.name);
        if (name == Main.User.name)
        {
            SetTarget(GameObject.Find(name));
            Cursor.visible = false;
            MainUi.PlayerIsChat = false;
        }
    }
    public void SetTarget(GameObject target)
    {
        if(target.transform.Find("cameraPoint") != null)
            this.target = target.transform.Find("cameraPoint").gameObject;
        else
            this.target = target;
    }

    void LateUpdate()
    {
        if(target == null)
            return;
        if(Camera.main == null)
            return;
        if(EscMenu.GameIsPaused == true)
            return;
        if(MainUi.PlayerIsChat == true)
        {
            Debug.LogFormat("playerischat");
            return;
        }
        Vector3 targetPos = target.transform.position;
        Vector3 cameraPos;
        float d = distance * Mathf.Cos(roll);
        float height = distance * Mathf.Sin(roll);
        cameraPos.x = targetPos.x + d * Mathf.Cos(rot);
        cameraPos.y = targetPos.y + height;
        cameraPos.z = targetPos.z + d * Mathf.Sin(rot);
        Camera.main.transform.position = cameraPos;
        Camera.main.transform.LookAt(target.transform);
        Rotate();
        Roll();
        Zoom();
    }

    void Rotate()
    {
        float w = Input.GetAxis("Mouse X") * rotSpeed;
        rot -= w;
    }

    void Roll()
    {
        float w = Input.GetAxis("Mouse Y") * rollSpeed * 0.5f;
        roll -= w;
        if(roll > maxRoll)
            roll = maxRoll;
        if(roll < minRoll)
            roll = minRoll;
    }

    void Zoom()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0 )
        {
            if(distance > minDistance)
                distance -= zoomSpeed;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0 )
        {
            if (distance < maxDistance)
                distance += zoomSpeed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
