using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float len, initialpos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        initialpos = transform.position.y;
        len = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = speed*Time.deltaTime; //(cam.transform.position.y*speed);

        transform.position = new Vector3(transform.position.x, transform.position.y - move);

        if(transform.position.y <= initialpos-len){
            transform.position = new Vector3(transform.position.x, initialpos);
        }

    }
}
