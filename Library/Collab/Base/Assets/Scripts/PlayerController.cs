using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float x_input;
    float y_input;
    public float movespeed;
    public float playableAreaBorder;

    bool isAttacking;

    Rigidbody2D rb;
    Vector3 screenSize;

    public GameObject bullet;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Update is called once per frame
    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");

        Move();

        if (Input.GetKeyDown(KeyCode.J) && !isAttacking)
        {
            Attack();
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(x_input, y_input).normalized * movespeed;

        if (transform.position.x > screenSize.x - playableAreaBorder) {
            transform.position = new Vector3(screenSize.x - playableAreaBorder, transform.position.y, 0);
        }
        if (transform.position.x < -screenSize.x + playableAreaBorder) {
            transform.position = new Vector3(-screenSize.x + playableAreaBorder, transform.position.y, 0);
        }
        if (transform.position.y > 0 - playableAreaBorder) {
            transform.position = new Vector3(transform.position.x, -playableAreaBorder, 0);
        }
        if (transform.position.y < -screenSize.y + playableAreaBorder) {
            transform.position = new Vector3(transform.position.x, -screenSize.y + playableAreaBorder, 0);
        }
    }

    private void Attack()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;

        // FindObjectOfType<AudioManager>().Play("PlayerAttack");

        GameObject bulletInstance = Instantiate(bullet, transform.position, transform.rotation);

        yield return new WaitForSeconds(bulletInstance.GetComponent<BulletController>().bulletDelay);

        isAttacking = false;
    }
}
