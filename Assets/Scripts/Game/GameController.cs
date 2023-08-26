using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public ShipController Player;
    public EnemyController Enemies;

    // Start is called before the first frame update
    void Start()
    {
        Player.Init();

        Enemies.Init(Player);

        //Gnerat
    }

    // Update is called once per frame
    void Update()
    {

    }


    

    private void SetGameData(Data data)
    {
        DataCounting._instance.currentHealth.text = data.Health.ToString();
        DataCounting._instance.currentScore.text = data.Score.ToString();
        DataCounting._instance.HighestScore.text = data.HighestScore.ToString();
    }



    private void SaveByPlayerPrefs()
    {
        PlayerPrefs.SetInt("Hightestcore", DataCounting._instance.HighestScore);
        PlayerPrefs.Save();
    }
    private void LoadByPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("HighestScore"))
        {
            DataCounting._instance.currentScore.text = PlayerPrefs.GetInt("HighestScore").ToString();
        }
        else
        {
            Debug.Log("------Can not find the data------");
        }

    }
}

