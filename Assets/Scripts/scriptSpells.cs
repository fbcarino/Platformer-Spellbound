using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptSpells : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Solid")
        {
            Destroy(gameObject);
        }
    }
}
