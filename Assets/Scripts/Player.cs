using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject projectile;
    public float rotationOffset;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject proj = Instantiate(projectile, transform.position, transform.rotation);
            Rigidbody2D projrb = proj.GetComponent<Rigidbody2D>();
            projrb.velocity = new Vector2(rb.velocity.x + projrb.velocity.x, rb.velocity.y + projrb.velocity.y);
            rb.AddForce(-transform.up, ForceMode2D.Impulse);
        }

    void OnCollisionEnter2D(Collision collision) {
        print("collide");
        if (collision.gameObject.name == "Border")
        {
            Debug.Log(collision.contacts[0].ToString() + " " + collision.contacts[1].ToString());
            // rb.AddForce(collision.contacts)
        }
    }

    }
}
