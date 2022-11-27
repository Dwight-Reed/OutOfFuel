using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private float screenWidth;
    private float screenHeight;
    public bool isClone;
    // how many times a projectile can wrap the screen before despawning
    // (horizontal and vertical are tracked separately, despawned when one reaches the cap) set to -1 for non-projectiles,
    public int maxWraps;
    // If self is a clone, reference to the "real" version of self, otherwise, it is a reference to self
    public GameObject realObject;
    private SpriteRenderer sr;
    private GameObject horizontalClone;
    private GameObject verticalClone;
    private GameObject cornerClone;
    private Camera mainCamera;
    private int horizontalWraps = 0;
    private int verticalWraps = 0;
    // Start is called before the first frame update

    void Start()
    {
        // Only create new clones if self is not a clone
        if (!isClone)
        {
            mainCamera = Camera.main;
            screenHeight = mainCamera.orthographicSize * 2;
            screenWidth = mainCamera.orthographicSize * mainCamera.aspect * 2;
            sr = GetComponent<SpriteRenderer>();

            horizontalClone = Instantiate<GameObject>(gameObject);
            horizontalClone.GetComponent<ScreenWrap>().isClone = true;
            horizontalClone.GetComponent<ScreenWrap>().realObject = gameObject;

            verticalClone = Instantiate<GameObject>(gameObject);
            verticalClone.GetComponent<ScreenWrap>().isClone = true;
            verticalClone.GetComponent<ScreenWrap>().realObject = gameObject;

            cornerClone = Instantiate<GameObject>(gameObject);
            cornerClone.GetComponent<ScreenWrap>().isClone = true;
            cornerClone.GetComponent<ScreenWrap>().realObject = gameObject;

            realObject = gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isClone)
        {
            // Always treat objects with maxWraps disabled as having fewer wraps than the cap
            if (maxWraps == -1)
            {
                horizontalWraps = -5;
                verticalWraps = -5;
            }
            // Teleport object to other side if its position is out of bounds
            if (horizontalWraps < maxWraps)
            {
                // Right
                if (transform.position.x > screenWidth / 2)
                {
                    transform.position = new Vector2(transform.position.x - screenWidth, transform.position.y);
                    horizontalWraps++;
                }
                // Left
                else if (transform.position.x < -screenWidth / 2)
                {
                    transform.position = new Vector2(transform.position.x + screenWidth, transform.position.y);
                    horizontalWraps++;
                }
            }
            // If the object has reached its max number of wraps, destroy it when it is no longer visible
            else if (transform.position.x - sr.bounds.size.x / 2 > screenWidth / 2
                || transform.position.x + sr.bounds.size.x < -screenWidth / 2)
            {
                Destroy(gameObject);
            }
            if (verticalWraps < maxWraps)
            {
                // Top
                if (transform.position.y > screenHeight / 2)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - screenHeight);
                    verticalWraps++;
                }
                // Bottom
                else if (transform.position.y < -screenHeight / 2)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + screenHeight);
                    verticalWraps++;
                }
            }
            else if (transform.position.y - sr.bounds.size.y / 2 > screenHeight / 2
                || transform.position.y + sr.bounds.size.y < -screenHeight / 2)
            {
                Destroy(gameObject);
            }

            // create clones of the object's sprite on the opposite border if it's partially out of bounds

            // Don't start rendering a clone if it's going to be despawned before the real object is teleported
            // If the clone is already active, it can be assumed that it just teleported and will be deactivated before the object would be despawned
            if (horizontalWraps < maxWraps || horizontalClone.activeSelf)
            {
                horizontalClone.SetActive(true);
                // Right
                if (transform.position.x + sr.bounds.size.x / 2 > screenWidth / 2)
                {
                    horizontalClone.transform.position = new Vector2(transform.position.x - screenWidth, transform.position.y);
                }
                // Left
                else if (transform.position.x - sr.bounds.size.x / 2 < -screenWidth / 2)
                {
                    horizontalClone.transform.position = new Vector2(transform.position.x + screenWidth, transform.position.y);
                }
                else
                {
                    // Sprite is not on the left or right edge, so deactivate its horizontal clone
                    horizontalClone.SetActive(false);
                }
            }

            if (verticalWraps < maxWraps || verticalClone.activeSelf)
            {
                verticalClone.SetActive(true);
                // Top
                if (transform.position.y + sr.bounds.size.y / 2 > screenHeight / 2)
                {
                    verticalClone.transform.position = new Vector2(transform.position.x, transform.position.y - screenHeight);
                }
                // Bottom
                else if (transform.position.y - sr.bounds.size.y / 2 < -screenHeight / 2)
                {
                    verticalClone.transform.position = new Vector2(transform.position.x, transform.position.y + screenHeight);
                }
                else
                {
                    verticalClone.SetActive(false);
                }
            }
            // Any corner
            if (horizontalClone.activeSelf && verticalClone.activeSelf)
            {
                cornerClone.SetActive(true);
                cornerClone.transform.position = new Vector2(horizontalClone.transform.position.x, verticalClone.transform.position.y);
            }
            else
            {
                cornerClone.SetActive(false);
            }
        }
    }


    private void OnDestroy()
    {
        Destroy(horizontalClone);
        Destroy(verticalClone);
        Destroy(cornerClone);
    }
}
