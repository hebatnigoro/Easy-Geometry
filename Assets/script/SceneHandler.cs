using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void ChangeSceneTo(int sceneID)
    {
         // Menambahkan pesan debugging
        SceneManager.LoadScene(sceneID);
    }
}
