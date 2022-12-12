using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private ScreenWrap sw;
    public Player player;
    private Enemy realEnemy;
    public GameObject projectile;
    public float fireRate;
    public Score score;
    private float posX;
    private float posY;
    private Rigidbody2D rb;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        posX = transform.position.x - player.transform.position.x;
        posY = player.transform.position.y - transform.position.y;
        float angle = Mathf.Atan2(posX, posY) * Mathf.Rad2Deg;
        // Debug.Log(angle);
        if (timer > fireRate) {
            Debug.Log("fire");
            timer = 0f;
            GameObject proj = Instantiate(projectile, transform.position, transform.rotation);
            proj.GetComponent<Projectile>().friendlyFire = true;
            Debug.Log(proj.GetComponent<Projectile>().friendlyFire);
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        try
        {
            collider.GetComponent<ScreenWrap>().realObject.GetComponent<Health>().hitPoints -= 1;
            GetComponent<Health>().hitPoints -= 1;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    private void OnDestroy() {
        score.score += 1;
    }
}
