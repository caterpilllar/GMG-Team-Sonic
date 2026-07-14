using UnityEngine;

public class Flap : MonoBehaviour
{
    private Vector3 direction;
     public float gravity = -9.8f;
     public float strength = 5f;

     private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * strength;
        }

    }

}
