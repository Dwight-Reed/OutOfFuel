using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private float screenWidth;
    private float screenHeight;
    private SpriteRenderer sr;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        screenHeight = mainCamera.orthographicSize * 2;
        screenWidth = mainCamera.orthographicSize * mainCamera.aspect * 2;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Right
        if (transform.position.x + sr.bounds.size.x / 2 > screenWidth / 2)
        {
            transform.position = new Vector2((screenWidth - sr.bounds.size.x), transform.position.y);
        }
        // Left
        else if (transform.position.x - sr.bounds.size.x / 2 < -screenWidth / 2)
        {
            transform.position = new Vector2(-(screenWidth - sr.bounds.size.x), transform.position.y);
        }
        // Top
        if (transform.position.y + sr.bounds.size.y / 2 > screenHeight / 2)
        {
            transform.position = new Vector2(transform.position.x, (screenHeight - sr.bounds.size.y) / 2);
        }
        // Bottom
        else if (transform.position.y - sr.bounds.size.y / 2 < -screenHeight / 2)
        {
            transform.position = new Vector2(transform.position.x, -(screenHeight - sr.bounds.size.y) / 2);
        }
    }
}
