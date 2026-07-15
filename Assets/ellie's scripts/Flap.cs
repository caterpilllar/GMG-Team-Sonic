using UnityEngine;
using System.Threading;
public class Flap : Physics2DObject
{
    private Vector3 direction;
     public float gravity = -9.8f;
     public float strength = 5f;

    public string groundTag = "Ground";
    private bool onGround = false;

     private void Update()
    { 
      if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * strength;
            if (onGround == true)
            {
              onGround = false;  
            }
        }
    if (onGround == false)
        {
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
        }
    }
        private void OnCollisionEnter2D(Collision2D collisionData)
	{
		if(collisionData.gameObject.CompareTag(groundTag))
		{
			onGround = true;
		}
	}

}
