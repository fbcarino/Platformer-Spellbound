using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptSlime : MonoBehaviour
{
    public GameObject player;
    public float healthPoints;
    public float distanceFromPlayer;
    public float distanceCheck;
    public float fireRate;
    public float time = 0f;
    public GameObject slimeBalls;


    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceFromPlayer < distanceCheck && time > fireRate)
        {
            Fire();
        }


        if (time < fireRate)
        {
            time += Time.deltaTime;
        }
    }
    void Fire()
    {
        Instantiate(slimeBalls, transform.position, transform.rotation);
        time = 0;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Spell")
        {
            Destroy(other.gameObject);
            healthPoints -= 1;
            if (healthPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
