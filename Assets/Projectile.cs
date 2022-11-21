using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float initialVelocity;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * initialVelocity, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
