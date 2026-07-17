using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlayer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public bool player1Active = true;
    public bool player2Active = false;
    public bool player3Active = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        player1.GetComponent<Move>().enabled = true;
        player1.GetComponent<Flap>().enabled = true;
        player2.GetComponent<Move>().enabled = false;
        player2.GetComponent<Jump>().enabled = false;
        player3.GetComponent<Move>().enabled = false;
        player3.GetComponent<Sneak>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
           SwitchPlayer();
        }
    }
    public void SwitchPlayer()
    {
        if(player1Active == true)
        {
            player1.GetComponent<Move>().enabled = false;
            player1.GetComponent<Flap>().canFlap = false;
            player2.GetComponent<Move>().enabled = true;
            player2.GetComponent<Jump>().enabled = true;
            player1Active = false;
            player2Active = true;
        }
        else if(player2Active == true)
        {
            player3.GetComponent<Move>().enabled = true;
            player3.GetComponent<Sneak>().enabled = true;
            player2.GetComponent<Move>().enabled = false;
            player2.GetComponent<Jump>().enabled = false;
            player2Active = false;
            player3Active = true;
        }
        else
        {
            player1.GetComponent<Move>().enabled = true;
            player1.GetComponent<Flap>().canFlap = true;
            player3.GetComponent<Move>().enabled = false;
            player3.GetComponent<Sneak>().enabled = false;
            player3Active = false;
            player1Active = true;
        }
    }
}
