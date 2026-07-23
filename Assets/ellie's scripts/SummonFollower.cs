using UnityEngine;

public class SummonFollower : MonoBehaviour
{
    private float cooldown = 0.0f;
    public float summonCooldown = 5.0f;
    public float summonDuration = 10.0f;
    private float summonTimer = 0.0f;
    public KeyCode summonKey = KeyCode.E;
    public GameObject followerPrefab;
    private GameObject player = null;
    
    private bool followerExists = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = gameObject;
        cooldown = summonCooldown; // Allow immediate summoning at the start
    }

    void Summon()
    {// Logic to summon the follower
        if (!followerExists && player != null && followerPrefab != null && cooldown >= summonCooldown)
        {
            GameObject follower = Instantiate(followerPrefab, transform.position, Quaternion.identity);
            follower.GetComponent<PetFollow>().target = player.transform;
            followerExists = true;
            cooldown = 0.0f;
        } 
        else if (followerExists || cooldown < summonCooldown)
        {
            Debug.Log("Wait before summoning again.");
        }
        else if (player == null || followerPrefab == null)
        {
            Debug.Log("Player or followerPrefab is null.");
        }
    }
    void DestroyFollower()
    {
        GameObject follower = GameObject.FindWithTag("Follower");
        if (follower != null)
        {
            Destroy(follower);
            followerExists = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (followerExists)
        {
            summonTimer += Time.deltaTime;
            if (summonTimer >= summonDuration)
            {
                DestroyFollower();
                summonTimer = 0.0f; // Reset the timer after destroying the follower
            }
        }

        cooldown += Time.deltaTime;

        if (Input.GetKeyDown(summonKey))
        {
            Summon();
        }
    }
}
