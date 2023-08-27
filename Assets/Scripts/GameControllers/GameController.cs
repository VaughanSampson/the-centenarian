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
    [SerializeField] private ReplayCanvas restartMenu;

    private int score;
    public static event Action<int> OnScoreChange;
    public static event Action<bool> OnPausedStateChange;


    public static event Action OnReset;

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChange?.Invoke(score);
    }

    public void SetScore(int amount)
    {
        score = amount;
        OnScoreChange?.Invoke(amount);
    }

    private void Start()
    {
        instance = this;
        Invoke("Init", 0.05f);
    }

    // Start is called before the first frame update
    void Init()
    {

        KeyboardAndMouseInput.EscapeCalled += TogglePause;
        if (!ArduinoInput.IsDisabled)
            ArduinoInput.Pause += TogglePause;

        shipController = Instantiate(shipControllerPrefab);
        shipController.Init();

        worldGenerator = Instantiate(worldGeneratorPrefab);
        worldGenerator.Init(shipController);

        enemyController = Instantiate(enemyControllerPrefab);
        enemyController.Init(shipController);

        mainCameraController.Init(shipController);


        pausable = true;
    }

    private void OnDisable()
    {
        KeyboardAndMouseInput.EscapeCalled -= TogglePause;
        ArduinoInput.Pause -= TogglePause;
    }

    public void FinishGame()
    {
        
        restartMenu.gameObject.SetActive(true);

        pausable = false;

        // Set high score
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }


    }

    public void Reset()
    {
        OnReset.Invoke();
        SetScore(0);
        restartMenu.gameObject.SetActive(false);

        // Destroy old stuff
        if (shipController)
            Destroy(shipController.gameObject);

        Destroy(worldGenerator.gameObject);
        Destroy(enemyController.gameObject);


        KeyboardAndMouseInput.EscapeCalled -= TogglePause;
        ArduinoInput.Pause -= TogglePause;

        // Start game again
        Init();
    }


    private static bool pausable, paused = false;
    public static bool IsPaused { get => paused; }


    public void TogglePause()
    {
        if (paused)
        {
            Resume();
        }
        else
        {
            if (pausable)
                Pause();
        }
    }

    private void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        OnPausedStateChange.Invoke(false);
    }

    private void Pause()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        OnPausedStateChange.Invoke(true);
    }

}

