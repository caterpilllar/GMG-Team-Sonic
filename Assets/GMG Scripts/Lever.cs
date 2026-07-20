using UnityEngine;

public class Lever : MonoBehaviour
{
    public Sprite deactivatedSprite;
    public Sprite activatedSprite;
    public bool active;

    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;

    void Awake()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = deactivatedSprite;
        }

        audioSource = GetComponent<AudioSource>();

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            active = !active;
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = active ? activatedSprite : deactivatedSprite;
            }
            Debug.Log("lever activated");

            //play SFX
            if (audioSource != null)
            {
                audioSource.Play();
            }

        }
    }
}
