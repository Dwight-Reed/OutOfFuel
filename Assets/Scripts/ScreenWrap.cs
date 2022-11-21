using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private float halfScreenWidth;
    public float halfScreenHeight;
    private SpriteRenderer sr;
    private GameObject horizontalSpriteClone;
    private GameObject verticalSpriteClone;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        halfScreenHeight = camera.orthographicSize;
        halfScreenWidth = camera.orthographicSize * camera.aspect;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Teleport object to other side if its position is out of bounds
        if (transform.position.x > halfScreenWidth)
        {
            transform.position = new Vector3(transform.position.x - halfScreenWidth * 2, transform.position.y, 0);
        }
        else if (transform.position.x < -halfScreenWidth)
        {
            transform.position = new Vector3(transform.position.x + halfScreenWidth * 2, transform.position.y, 0);
        }

        if (transform.position.y > halfScreenHeight)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - halfScreenHeight * 2, 0);
        }
        else if (transform.position.y > halfScreenHeight)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + halfScreenHeight * 2, 0);
        }
        // create clones of the object's sprite on the opposite border if it's partially out of bounds
        if (transform.position.x + sr.bounds.size.x / 2 > halfScreenWidth)
        {

        }
        else if (transform.position.x - sr.bounds.size.x / 2 < -halfScreenWidth)
        {

        }
        if (transform.position.y + sr.bounds.size.y / 2 > halfScreenHeight)
        {

        }
        else if (transform.position.y - sr.bounds.size.y / 2 < -halfScreenHeight)
        {

        }
    }
}
