﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float x_input;
    float y_input;
    public float movespeed;
    public float playableAreaBorder;

    public bool canShoot;
    public float fireRate;
    public int health;

    Rigidbody2D rb;
    Vector3 screenSize;
    

    public GameObject bullet;
    public GameObject healthUI;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        fireRate = 0.2f;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");

        Move();
        if (canShoot && Input.GetKey(KeyCode.Space))
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

    public void TakeHit()
    {
        health -= 1;

        // Changes UI
        healthUI.GetComponent<Health>().health = health;

        if (health <= 0){
            Die();
        }
    }

    public void Die(){
        Destroy(this.gameObject);
        SceneManager.LoadScene("LoseMenu");
    }

    IEnumerator AttackRoutine()
    {
        FindObjectOfType<AudioManager>().Play("Laser");

        GameObject bulletInstance = Instantiate(bullet, transform.position, transform.rotation);
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
