using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemies;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("generateEnemies",3f);
    }

    void generateEnemies()
    {
        Instantiate(enemies,transform.position,Quaternion.identity);
        Invoke("generateEnemies", 3f);
    }


}
