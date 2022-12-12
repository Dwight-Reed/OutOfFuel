using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    public Score score;
    private Rigidbody2D rb;
    private Enemy newEnemy;
    // Start is called before the first frame update
    void Start()
    {
        newEnemy = Instantiate(enemy, new Vector2(), new Quaternion());
        newEnemy.player = player;
        newEnemy.score = score;
        rb = newEnemy.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (!newEnemy) {
            newEnemy = Instantiate(enemy, new Vector2(), new Quaternion());
            newEnemy.player = player;
            rb = newEnemy.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)), ForceMode2D.Impulse);
        }

    }
}
