using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Spawner spawner;

    void OnTriggerEnter2D(Collider2D other)
    {
        spawner.StartSpawn();
    }
}
