using UnityEngine;

public class Key : MonoBehaviour
{
    //does the player have the key?
    public bool key = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //make sure the player does not start with a key
        key = false;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("Key - OnCollisionEnter2D");
        //if the player has the key, unlock the door
        if (col.CompareTag("Key"))
        {
            key = true;
        }
        
    }

}
