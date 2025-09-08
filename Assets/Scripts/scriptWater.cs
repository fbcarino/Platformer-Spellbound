using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptWater : MonoBehaviour
{
    public GameObject player;
    public float distanceFromPlayer;
    public float distanceCheck;
    public float fireRate;
    public float time = 0f;
    public GameObject waterBubbles;

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
        Instantiate(waterBubbles, transform.position, transform.rotation);
        time = 0;
    }

}
