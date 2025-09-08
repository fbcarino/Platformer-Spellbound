using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptClimb : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            scriptPlayer playerBrain = other.GetComponent<scriptPlayer>();
            playerBrain.isInClimbSpace = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            scriptPlayer playerBrain = other.GetComponent<scriptPlayer>();
            playerBrain.isInClimbSpace = false;
        }
    }
}
