using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinFlag : MonoBehaviour
{   

    Rigidbody2D rb;
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    public float level_speed;

    void Update()
    {
        rb.velocity = new Vector2(0, -level_speed);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.transform.CompareTag("Player")) {
            print("ok");
            Vector3 position= new Vector3(0, 59.3f, 0);
            Instantiate(Boss, position, transform.rotation);
            Destroy(this.gameObject);
            //Win();
        }
    }

    private void Win(){
        SceneManager.LoadScene("WinMenu");
    }
}
