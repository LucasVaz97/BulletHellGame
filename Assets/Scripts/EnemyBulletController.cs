using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDelay;
    public float bulletLifespan;

    Rigidbody2D rb;

    void Awake() {

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.down * bulletSpeed;

        Destroy(this.gameObject, bulletLifespan);
    }

    // void Update()
    // {
    //     hitCheck();
    // }




    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.transform.CompareTag("Player")) {
            //collision.gameObject.GetComponent<EnemyController>().Die();
            //Destroy(this.gameObject);
            print("Ouch!");
            collision.gameObject.GetComponent<PlayerController>().TakeHit();
            Destroy(this.gameObject);
        }

        if (collision.transform.CompareTag("ForegroundObject"))
        {
            Destroy(this.gameObject);
        }

        
    }
}
