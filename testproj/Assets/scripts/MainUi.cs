using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUi : MonoBehaviour
{
    public TMP_InputField inputField;
    private void InputEnd(TMP_InputField inputField)
    {
        Debug.Log("print msg:" + inputField.text);
        inputField.GetComponent<CanvasGroup>().alpha = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        inputField.onEndEdit.AddListener(delegate { InputEnd(inputField);});
    }

    // Update is called once per frame
    void Update()
    {
    }
}
