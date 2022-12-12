using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Score : MonoBehaviour
{
    public int score;
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
