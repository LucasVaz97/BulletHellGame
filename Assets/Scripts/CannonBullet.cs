using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    private void Awake()
    {
        Destroy(this.gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
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
