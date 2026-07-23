using UnityEngine;

public class Locked : MonoBehaviour
{
    public bool isLocked = true;
    private Key playerKey;
    public GameObject doorOne;
    public GameObject doorTwo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isLocked = true;
    }

    void Update()
    {
        if (isLocked == false)
        {
            doorOne.SetActive(false);
            doorTwo.SetActive(true);
        }
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        //if colliding with key component AND key is true

        if (col.CompareTag("Player"))
        {
            Debug.Log("Locked - Enter Trigger Door");

            playerKey = col.GetComponent<Key>();
            isLocked = !playerKey.key;
            Debug.Log("isLocked: " + isLocked);
        }
    }
}
