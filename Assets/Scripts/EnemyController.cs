using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D col;
    SpriteRenderer sprite;
    Animator anim;
    // GameObject explosion;


    public float animationLoopTime;
    float timeCounter = 0f;
    public float x_animationMovementSize;
    public float x_timeMultiplier;
    public float y_animationMovementSize;
    public float y_timeMultiplier;
    public float time_between_attacks;
    public float level_speed;
    public float maxHealth;

    Vector3 initialPosition;
    public bool active = false;

    public GameObject bullet;
    public GameObject scoreCounter;
    public GameObject explosion;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        initialPosition = transform.position;
        
    }
    
    private void Update() {

        // Making it fly in direction of the player
        
        
        if (!active) {
            rb.velocity = new Vector2(0, -level_speed);
            return;
        }

        timeCounter += Time.deltaTime;

        float xpos = Mathf.Cos(timeCounter/(animationLoopTime/x_timeMultiplier)) * x_animationMovementSize + initialPosition.x;
        float ypos = Mathf.Sin(timeCounter/(animationLoopTime/y_timeMultiplier)) * y_animationMovementSize + initialPosition.y;

        transform.position = new Vector3(xpos, ypos - level_speed*timeCounter);
        // rb.velocity = new Vector2(0, -level_speed);

        
    }

    public void TakeHit(){
        maxHealth -= 1;
        if (maxHealth <= 0){
            scoreCounter.GetComponent<ScoreController>().modifyScore(100);
            Die();
        }

    }

    public void Die() {
        //anim.enabled = false;
        // sprite.color =  Color.grey;
        // rb.freezeRotation = false;
        // col.enabled = false;
        // rb.isKinematic = true;
        FindObjectOfType<AudioManager>().Play("Explosion");

        active = false;
        GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
        
    }

    public void Activate(){
        active = true;
        initialPosition = transform.position;
        StartCoroutine(ShootRoutine(time_between_attacks));
    }

    

    private IEnumerator ShootRoutine(float waitTime)
    {
        while(active)
        {
            yield return new WaitForSeconds(waitTime);
            Shoot();
            // print("Pew!");
        }
        
    }

    private void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, transform.position, transform.rotation);
    }

}
