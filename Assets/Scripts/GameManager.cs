using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Asteroid;
    public int NumberOfAsteroids;
    public float MaxInitianRotationSpeed;
    public float Y_levelSize;

    Vector3 screenSize;

    GameObject renderArea;
    float renderAreaBorder = 10f;

    void Start()
    {
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        renderArea = GameObject.Find("RenderArea");
        renderArea.GetComponent<BoxCollider2D>().size = new Vector2(screenSize.x*2 + renderAreaBorder, screenSize.y*2 + renderAreaBorder);

        fillLevel(NumberOfAsteroids, Y_levelSize);

        FindObjectOfType<AudioManager>().Play("GameStart");
    }

    void fillLevel(int numOfAsteroids, float y_levelSize) {
        for (int i = 0; i < numOfAsteroids; i++) {

            float xpos = Random.Range(-screenSize.x, screenSize.x);
            float ypos = Random.Range(0f, y_levelSize) + screenSize.y;

            GameObject instantiatedAsteroid = Instantiate(Asteroid, new Vector3(xpos, ypos, 0f), this.transform.rotation);
            
            instantiatedAsteroid.transform.parent = GameObject.Find("Level").transform;
            instantiatedAsteroid.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-MaxInitianRotationSpeed, MaxInitianRotationSpeed));
        }
    }

    
}
