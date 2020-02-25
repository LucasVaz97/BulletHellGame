using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public int attackType;
    float coolDown;
    public GameObject Cannon1;
    public GameObject Cannon2;
    public GameObject Cannon3;
    CannonController can1S;
    CannonController can2S;
    CannonController can3S;
    SpriteRenderer sprite;
    Rigidbody2D boosRd;
    int health;


    // Start is called before the first frame update
    void Start()
    {
        coolDown = 3f;
        health = 170;
        sprite = GetComponent<SpriteRenderer>();
        boosRd = GetComponent<Rigidbody2D>();
        can1S = Cannon1.GetComponent<CannonController>();
        can2S= Cannon2.GetComponent<CannonController>();
        can3S = Cannon3.GetComponent<CannonController>();

        sprite.color = Color.cyan;

        CallRoutine();


    }


    // Update is called once per frame
    void Update()
    {

        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
        if (coolDown<=0) {
            attackType=Random.Range(1, 3);
            if (attackType == 1)
            {
            can1S.CallRoutine();
            can2S.CallRoutine();
            coolDown = 7f;
            }
            else
            {
                can3S.CallRoutine();
                coolDown = 7f;
            }

        }
    }


    public void TakeHit()
    {
        health -= 1;
        StartCoroutine(DisplayDamage());
        if (health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("WinMenu");
        }
    }

    private IEnumerator StartWalk()
    {
        print("opa");
        boosRd.velocity = Vector2.down * 10f;

        yield return new WaitForSeconds(2f);
        boosRd.velocity = Vector2.zero;
       

    }

    private IEnumerator DisplayDamage(){
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.6f);
        sprite.color = Color.cyan;
    }
    


    public void CallRoutine()
    {
        StartCoroutine(StartWalk());
       
    }
}
