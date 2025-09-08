using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptUISystem : MonoBehaviour
{
    public Text healthsPoints;
    public Text gemPoints;
    public Text manaBlast;
    public Text NPCquest;
    public Text playerQuest;

    public GameObject player;
    scriptPlayer playerBrain;

    // Start is called before the first frame update
    void Start()
    {
        playerBrain = player.GetComponent<scriptPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        healthsPoints.text = ": " + playerBrain.healthPoints;
        gemPoints.text = ": " + playerBrain.gemScore;
        manaBlast.text = ": " + playerBrain.currentMana;
        if (playerBrain.isReloading)
        {
            manaBlast.text = ": Reloading";
        }
        if (playerBrain.questComplete == true)
        {
            playerQuest.text = "Quest Complete!";
        }
        if (playerBrain.talkingToNPC == true)
        {
            NPCquest.text = "Can you help me find my shovel young wizard? It is on top of that tree.";
            playerQuest.text = "Retrieve shovel for farmer.";
            if (playerBrain.talkingToNPC == true && playerBrain.questComplete == true)
            {
                playerQuest.text = "Shovel Returned.";
                NPCquest.text = "Thank you! Heres some gems for your kindness.";
                playerBrain.gemScore = 10;
            }
        }
        else if (playerBrain.talkingToNPC == false)
        {
            NPCquest.text = " ";
        }
    }
}
