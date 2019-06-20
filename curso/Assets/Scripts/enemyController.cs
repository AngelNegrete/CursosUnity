using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float vida = 15;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bala")
        {
            vida -= 1;
            Debug.Log("DAÑO");
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
