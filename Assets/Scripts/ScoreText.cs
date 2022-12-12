using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "Score: " + GameObject.Find("Score").GetComponent<Score>().score;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
