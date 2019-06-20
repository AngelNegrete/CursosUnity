using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemies;

    public void StartSpawn()
    {
        Invoke("generateEnemies",0);
    }

    void generateEnemies()
    {
        Instantiate(enemies,transform.position,Quaternion.identity);
        Invoke("generateEnemies", 3f);
    }


}
