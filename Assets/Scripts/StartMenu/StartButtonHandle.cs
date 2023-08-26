using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonHandle : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

}
