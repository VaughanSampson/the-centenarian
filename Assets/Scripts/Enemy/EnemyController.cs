using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private ShipController Player;

    private List<EnemyFunction> enemies;


    public void Init(ShipController Player)
    {
        this.Player = Player;
    }

    public void GenerateEnemy()
    {
        
    }

}
