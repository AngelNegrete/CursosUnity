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
    public bool grounded;
    public float x;

    public Transform directionObject;
    bool pressedJump;
    bool pressedShoot;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        facingRight = true;
    }

    IEnumerator Wait(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        var balita = Instantiate(bala, shootPoint.transform.position, Quaternion.identity);
        balita.SetActive(true);

        Rigidbody2D rdBala = balita.GetComponent<Rigidbody2D>();

        rdBala.velocity = facingRight ? Vector2.right * (speedBala * Time.deltaTime) : Vector2.left * (speedBala * Time.deltaTime);
        Destroy(balita, 2f);
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.W))
        {
            pressedJump = true;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            pressedShoot = true;
        }
    }
    void FixedUpdate()
    {
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
        if (pressedShoot == true)
        {
            pressedShoot = false;
            var balita = Instantiate(bala, shootPoint.transform.position, Quaternion.identity);
            balita.SetActive(true);

            Rigidbody2D rdBala = balita.GetComponent<Rigidbody2D>();

            Vector2 direccion = directionObject.position - shootPoint.transform.position;
            direccion.Normalize();
            rdBala.velocity = direccion * speedBala * Time.deltaTime;

            //rdBala.velocity = facingRight ? Vector2.right * (speedBala * Time.deltaTime) : Vector2.left * (speedBala * Time.deltaTime);
            Destroy(balita, 2f);
            //StartCoroutine(Wait(0.5f));
        }

        if (pressedJump && grounded == true)
        {
            rb.AddForce(Vector2.up * force);
            grounded = false;
            pressedJump = false;
        }
    }



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }


}