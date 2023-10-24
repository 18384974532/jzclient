using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EscMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Button quitButton;
    public Slider MouseSen;
    void Start()
    {
        pauseMenuUI.SetActive(false);
        quitButton.onClick.AddListener(OnClick);
        MouseSen.onValueChanged.AddListener(senChanged);
        quitButton.GetComponent<CanvasGroup>().alpha = 0;
        EventManager.AddListener("PausePress", _press_pause);
    }

    void OnClick()
    {
        EventManager.Trigger("quitRoom", Main.User.name);
    }

    void senChanged(float value)
    {
        EventManager.Trigger("senChange", value);
    }

    void checkGameState()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //checkGameState();
    }

    public void _press_pause()
    {
        UnityEngine.Debug.Log("press esc:");
        //暂停
        if(GameIsPaused == false)
        {
            pauseMenuUI.SetActive(true);
            quitButton.GetComponent<CanvasGroup>().alpha = 1;
            Cursor.visible = true;
            GameIsPaused = true;
            UnityEngine.Debug.Log("visible true:" + Cursor.visible);
        }
        else
        {
            pauseMenuUI.SetActive(false);
            quitButton.GetComponent<CanvasGroup>().alpha = 0;
            Cursor.visible = false;
            GameIsPaused = false;
            UnityEngine.Debug.Log("visible false:" + Cursor.visible);
        }

        Time.timeScale = GameIsPaused == true ? 0f : 1f;
        
    }
}