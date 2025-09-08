using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBoar : MonoBehaviour
{
    public float speed;
    public float hitPoints;
    public GameObject player;
    public float distanceCheck;

    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        if (player.transform.position.x < transform.position.x)
        {
            speed = Mathf.Abs(speed) * -1;
        }
        else
        {
            speed = Mathf.Abs(speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < distanceCheck)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Spell")
        {
            hitPoints -= 1;
            Destroy(other.gameObject);
            if (hitPoints <= 0)
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
