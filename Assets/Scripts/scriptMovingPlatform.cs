using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMovingPlatform : MonoBehaviour
{
    public float xMin;
    public float xMax;
    bool goRight;
    public float speed;

    void Start()
    {
        goRight = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!goRight)
        {
            speed = -Mathf.Abs(speed);
        }
        if (goRight)
        {
            speed = Mathf.Abs(speed);
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (transform.position.x >= xMax)
        {
            goRight = false;
        }
        if (transform.position.x <= xMin)
        {
            goRight = true;
        }
    }
}
