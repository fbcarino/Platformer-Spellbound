using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptGoblin : MonoBehaviour
{
    public float speed;
    public float healthPoints;

    public bool movingLeft;

    void Update()
    {
        if (movingLeft)        //moving left
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);   //move left
            transform.localScale = new Vector2(1, 1);                     // face left
        }
        else                  // moving right
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);      //move right
            transform.localScale = new Vector2(-1, 1);                        //face right
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boundary"))        //is enemy in contact with invisble boundary
        {
            if (movingLeft)                          //is enemy moving left
            {
                movingLeft = false;                  //go right
            }
            else                                     //is enemy moving right
            {
                movingLeft = true;                   //go left
            }
        }
        if (other.transform.tag == "Spell")
        {
            healthPoints -= 1;
            Destroy(other.gameObject);
            if (healthPoints <= 0)
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
