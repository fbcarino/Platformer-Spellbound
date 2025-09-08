using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptSlimeProjectile : MonoBehaviour
{
    public float speed;
    public GameObject player;


    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);

    }
}
