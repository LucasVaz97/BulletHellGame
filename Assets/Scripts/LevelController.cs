using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public float currentVelocity;

    float y_position;

    private void Start() {
        y_position = this.transform.position.y;
    }

    void Update()
    {
        y_position -= currentVelocity * Time.deltaTime;

        this.transform.position = new Vector3(0f, y_position, 0f);
    }
}
