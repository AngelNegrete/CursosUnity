using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed, speedBala;
    public GameObject bala, shootPoint;
    public float force;
    public bool facingRight;
    // Start Dis called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        facingRight = true;
    }
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (x > 0 & facingRight == false)
        {
            facingRight = true;
            transform.Rotate(0, 180, 0);

        }
        else if (x < 0 & facingRight == true)
        {
            facingRight = false;
            transform.Rotate(0, 180, 0);

        }
        rb.velocity = new Vector2((speed * Time.deltaTime) * x, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var balita = Instantiate(bala, shootPoint.transform.position, Quaternion.identity);
            balita.SetActive(true);

            Rigidbody2D rdBala = balita.GetComponent<Rigidbody2D>();

            /* if(facingRight==false)
             {
                 rdBala.velocity = (Vector2.left) * (speedBala * Time.deltaTime);

             }

            else if (facingRight == true)
             {
                 rdBala.velocity = (Vector2.right) * (speedBala * Time.deltaTime);

             }*/

            rdBala.velocity = facingRight ? Vector2.right * (speedBala * Time.deltaTime) : Vector2.left * (speedBala * Time.deltaTime);
            Destroy(balita, 2f);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * force);

        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            
                Destroy(gameObject);
            
        }
    }


}