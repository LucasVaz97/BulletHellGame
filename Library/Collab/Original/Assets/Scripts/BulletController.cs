using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDelay;
    public float bulletLifespan;

    Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.up * bulletSpeed;

        Destroy(this.gameObject, bulletLifespan);
    }

    // void Update()
    // {
    //     hitCheck();
    // }


    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(this.gameObject);

        if (collision.transform.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<EnemyController>().Die();
            Destroy(this.gameObject);
        }

        if (collision.transform.CompareTag("ForegroundObject"))
        {
            Destroy(this.gameObject);
        }

        if (collision.transform.CompareTag("Dead")) {
            Destroy(collision.gameObject);
        }

    }
}
