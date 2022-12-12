using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float initialVelocity;
    public bool friendlyFire;
    public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * initialVelocity, ForceMode2D.Impulse);
        if (!friendlyFire) {
            GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // TODO: test if inactive objects trigger collision
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (friendlyFire) {
            if (collider.GetComponent<Player>()) {
                ScreenWrap sw = collider.GetComponent<ScreenWrap>();
                Health health = sw.realObject.GetComponent<Health>();
                health.hitPoints -= damage;
                if (health.hitPoints <= 0) {
                    Destroy(health.gameObject);
                }
                Destroy(gameObject);

            }
        } else {
            try {
                Health health = collider.GetComponent<Health>();
                health.hitPoints -= damage;
                if (health.hitPoints <= 0) {
                    Destroy(health.gameObject);
                }
                // Destroy(gameObject);

            } catch (System.Exception) {

            }
        }

    }
}
