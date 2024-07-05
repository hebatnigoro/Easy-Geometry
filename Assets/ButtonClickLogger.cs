using UnityEngine;
using UnityEngine.UI;

public class ButtonClickLogger : MonoBehaviour
{
    public Button myButton;

    void Start()
    {
        myButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Button clicked!");
    }
}
