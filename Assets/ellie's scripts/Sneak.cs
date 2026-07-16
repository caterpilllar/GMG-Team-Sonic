using UnityEngine;

public class Sneak : Physics2DObject
{
    public KeyCode sneakKey = KeyCode.Space;
    private bool isSneaking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(sneakKey))
        {
            isSneaking = true;
        }
        else
        {
            isSneaking = false;
        }

        if (isSneaking == true)
        {
            Debug.Log("Sneaking...");
        }
        else 
        {
            Debug.Log("Not Sneaking...");
        }
    }
}
