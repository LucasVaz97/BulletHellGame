using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour
{
    public float score = 0;
    // public GameObject scoreText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        handleText();
    }

    // Update is called once per frame
 

    public void handleText(){
        scoreText.text = score.ToString()+"%";
    }

    public void modifyScore(float points){
        score += points;
        handleText();
        print(score);
    }
}
