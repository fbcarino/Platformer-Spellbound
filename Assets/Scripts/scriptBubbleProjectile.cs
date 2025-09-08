using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBubbleProjectile : MonoBehaviour
{
    public float speed;
    public float ymax;

    void Start()
    {
        speed = Random.Range(5f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if(transform.position.y > ymax)
        {
            Destroy(gameObject);
        }
    }
}
