using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private ScreenWrap sw;
    public GameObject projectile;
    public float rotationOffset;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sw = GetComponent<ScreenWrap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!sw.isClone)
            {
                // Point the player towards the mouse
            Vector2 mousePos = Input.mousePosition;
            Vector2 objectPos = Camera.main.WorldToScreenPoint (transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));

            if (Input.GetButtonDown("Fire1"))
            {
                GameObject proj = Instantiate(projectile, transform.position, transform.rotation);
                rb.AddForce(-transform.up, ForceMode2D.Impulse);
            }
        }
    }
    private void OnDestroy() {
        Debug.Log("next scene");
        SceneManager.LoadScene("End");
    }

    // // TODO: test if inactive objects trigger collision
    // void OnTriggerEnter2D(Collider2D collider)
    // {
    //     try
    //     {
    //         Debug.Log(collider);
    //         sw.realObject.GetComponent<Enemy>().hitPoints -= collider.GetComponent<Projectile>().damage;
    //         Destroy(collider.gameObject);
    //     }
    //     catch (Exception e)
    //     {
    //         Debug.Log(e);
    //     }
    // }
}
