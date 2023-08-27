using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonHandle : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
