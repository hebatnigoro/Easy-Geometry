using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHandler : MonoBehaviour
{
    public GameObject welcomeScreen;
    public GameObject homeScreen;

    public void ChangetoHome()
    {
        welcomeScreen.SetActive(false);
        homeScreen.SetActive(true);
    }
}
