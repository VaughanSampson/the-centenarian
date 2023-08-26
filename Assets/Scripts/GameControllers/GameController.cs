using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] private ShipController shipControllerPrefab;
    [SerializeField] private EnemyController enemyControllerPrefab;
    [SerializeField] private GameWorldGenerator worldGeneratorPrefab;

    private ShipController shipController;
    private EnemyController enemyController;
    private GameWorldGenerator worldGenerator;

    private int score;

    public void AddScore(int amount)
    {
        score += amount;
    }

    private void Start()
    {
        Init();
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
    
}

