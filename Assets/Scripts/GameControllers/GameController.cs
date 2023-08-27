using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private ShipController shipControllerPrefab;
    [SerializeField] private EnemyController enemyControllerPrefab;
    [SerializeField] private GameWorldGenerator worldGeneratorPrefab;

    private ShipController shipController;
    private EnemyController enemyController;
    private GameWorldGenerator worldGenerator;

    [SerializeField] private MainCameraController mainCameraController;
    [SerializeField] private PauseMenu pauseMenu;

    private int score;
    public static event Action<int> OnScoreChange;

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChange.Invoke(amount);
    }

    private void Start()
    {
        instance = this;
        Invoke("Init", 0.05f);
    }

    // Start is called before the first frame update
    void Init()
    {
        shipController = Instantiate(shipControllerPrefab);
        shipController.Init();

        worldGenerator = Instantiate(worldGeneratorPrefab);
        worldGenerator.Init(shipController);

        enemyController = Instantiate(enemyControllerPrefab);
        enemyController.Init(shipController);

        mainCameraController.Init(shipController);

        KeyboardAndMouseInput.EscapeCalled += TogglePause;
        if(!ArduinoInput.IsDisabled)
            ArduinoInput.Pause += TogglePause;
    }

    private void OnDisable()
    {
        KeyboardAndMouseInput.EscapeCalled -= TogglePause;
        ArduinoInput.Pause -= TogglePause;
    }

    public void FinishGame()
    {
        // Set high score
        if(PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }

        // Show finish message

    }

    public void Reset()
    {
        // Destroy old stuff
        if (shipController)
            Destroy(shipController.gameObject);

        Destroy(worldGenerator.gameObject);
        Destroy(enemyController.gameObject);

        // Start game again
        Init();
    }


    private static bool paused = false;
    public static bool IsPaused { get => paused; }


    public void TogglePause()
    {
        if (paused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    private void Pause()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

}

