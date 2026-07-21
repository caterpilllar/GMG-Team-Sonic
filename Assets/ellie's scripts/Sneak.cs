using Unity.Properties;
using UnityEngine;
public class Sneak : Physics2DObject
{
    public Sprite StandingSprite;
    public Sprite CrouchingSprite;
    private SpriteRenderer spriteRenderer;
    private bool underObject = false;
    public KeyCode sneakKey = KeyCode.Space;
    private bool isSneaking = false;
    
    private PolygonCollider2D StandCollider;
    private BoxCollider2D CrouchCollider;

    private Move moveScript;
    public float sneakSpeed = 0.3f;
    private float WalkSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         StandCollider = GetComponentInChildren<PolygonCollider2D>(true);
         CrouchCollider = GetComponentInChildren<BoxCollider2D>(true);
         moveScript = GetComponent<Move>();
         WalkSpeed = moveScript.speed;
         spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(sneakKey))
        {
            isSneaking = true;
        }
        else if (underObject == false)
        {
            isSneaking = false;
        }

        if (isSneaking == true)
        {
            StandCollider.enabled = false;
            CrouchCollider.enabled = true;
            moveScript.speed = sneakSpeed;
            spriteRenderer.sprite = CrouchingSprite;
        }
        else 
        {
            StandCollider.enabled = true;
            CrouchCollider.enabled = false;
            moveScript.speed = WalkSpeed;
            spriteRenderer.sprite = StandingSprite;
        }
    }
    private void FixedUpdate()
    {
     underObject = Physics2D.BoxCast(transform.position, CrouchCollider.bounds.size, 0f, Vector2.up, 0.1f);
     if (underObject == true)
        {
            isSneaking = true;
        }
    }
}
