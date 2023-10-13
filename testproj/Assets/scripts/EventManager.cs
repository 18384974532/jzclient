using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<string, UnityEvent> _events;
    private static EventManager _eventManager;
    public static EventManager instance
    {
        get{
            if (!_eventManager)
            {
                _eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;
                if(!_eventManager)
                    Debug.LogError("1");
                else
                    _eventManager.Init();
            }
                return _eventManager;
        }
    }
    void Init()
    {
        if (_events == null)
            _events = new Dictionary<string, UnityEvent>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
