using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private float halfScreenWidth;
    private float halfScreenHeight;
    private bool isClone;
    private SpriteRenderer sr;
    private GameObject horizontalClone;
    private GameObject verticalClone;
    private GameObject cornerClone;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        if (!isClone)
        {
            mainCamera = Camera.main;
            halfScreenHeight = mainCamera.orthographicSize;
            halfScreenWidth = mainCamera.orthographicSize * mainCamera.aspect;
            sr = GetComponent<SpriteRenderer>();

            horizontalClone = Instantiate<GameObject>(gameObject);
            horizontalClone.GetComponent<ScreenWrap>().isClone = true;

            verticalClone = Instantiate<GameObject>(gameObject);
            verticalClone.GetComponent<ScreenWrap>().isClone = true;

            cornerClone = Instantiate<GameObject>(gameObject);
            cornerClone.GetComponent<ScreenWrap>().isClone = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!isClone)
        {
            // Teleport object to other side if its position is out of bounds
            if (transform.position.x > halfScreenWidth)
            {
                transform.position = new Vector2(transform.position.x - halfScreenWidth * 2, transform.position.y);
            }
            else if (transform.position.x < -halfScreenWidth)
            {
                transform.position = new Vector2(transform.position.x + halfScreenWidth * 2, transform.position.y);
            }

            if (transform.position.y > halfScreenHeight)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - halfScreenHeight * 2);
            }
            else if (transform.position.y < -halfScreenHeight)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + halfScreenHeight * 2);
            }

            // create clones of the object's sprite on the opposite border if it's partially out of bounds
            horizontalClone.SetActive(true);
            verticalClone.SetActive(true);
            cornerClone.SetActive(true);

            // Right edge
            if (transform.position.x + sr.bounds.size.x / 2 > halfScreenWidth)
            {
                horizontalClone.transform.position = new Vector2(transform.position.x - halfScreenWidth * 2, transform.position.y);
            }
            // Left edge
            else if (transform.position.x - sr.bounds.size.x / 2 < -halfScreenWidth)
            {
                horizontalClone.transform.position = new Vector2(transform.position.x + halfScreenWidth * 2, transform.position.y);
            }
            else
            {
                horizontalClone.SetActive(false);
            }
            // Top edge
            if (transform.position.y + sr.bounds.size.y / 2 > halfScreenHeight)
            {
                verticalClone.transform.position = new Vector2(transform.position.x, transform.position.y - halfScreenHeight * 2);
            }
            // Bottom edge
            else if (transform.position.y - sr.bounds.size.y / 2 < -halfScreenHeight)
            {
                verticalClone.transform.position = new Vector2(transform.position.x, transform.position.y + halfScreenHeight * 2);
            }
            else
            {
                verticalClone.SetActive(false);
            }
            // Any corner
            if (horizontalClone.activeSelf && verticalClone.activeSelf)
            {
                cornerClone.transform.position = new Vector2(horizontalClone.transform.position.x, verticalClone.transform.position.y);
            }
            else
            {
                cornerClone.SetActive(false);
            }
        }
    }
}
