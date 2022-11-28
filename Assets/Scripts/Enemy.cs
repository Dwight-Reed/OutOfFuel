using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitPoints;
    private ScreenWrap sw;
    private Enemy realEnemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // TODO: test if inactive objects trigger collision
    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile proj = collider.gameObject.GetComponent<Projectile>();
        hitPoints -= proj.damage;
        Destroy(collider.gameObject);
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
