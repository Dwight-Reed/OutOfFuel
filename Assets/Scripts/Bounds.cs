using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private float screenWidth;
    private float screenHeight;
    private Rigidbody2D rb;
    private Camera mainCamera;
    private CircleCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        screenHeight = mainCamera.orthographicSize * 2;
        screenWidth = mainCamera.orthographicSize * mainCamera.aspect * 2;
        Debug.Log(screenWidth);
        // collider = GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Right
        if (transform.position.x + collider.bounds.extents.x / 2 > screenWidth / 2)
        {
            transform.position = new Vector2((screenWidth - collider.bounds.size.x) / 2, transform.position.y);
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
        // Left
        else if (transform.position.x - collider.bounds.extents.x / 2 < -screenWidth / 2)
        {
            transform.position = new Vector2(-(screenWidth - collider.bounds.size.x) / 2, transform.position.y);
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
        // Top
        if (transform.position.y + collider.bounds.extents.y / 2 > screenHeight / 2)
        {
            transform.position = new Vector2(transform.position.x, (screenHeight - collider.bounds.size.y) / 2);
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
        // Bottom
        else if (transform.position.y - collider.bounds.extents.y / 2 < -screenHeight / 2)
        {
            transform.position = new Vector2(transform.position.x, -(screenHeight - collider.bounds.size.y) / 2);
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
    }
}
