using UnityEngine;

public class BubbleKiller : MonoBehaviour
{
    public float speed = 5, rotationSpeed = 5;
    public float growthFactor = 0.01f, maxGrowth = 20;
    
    public BubbleMaker bubbleMaker;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //movement.Normalize();

        //transform.position += new Vector3(speed*Time.deltaTime* movement.x, speed * Time.deltaTime * movement.y);
        transform.Rotate(0, 0, -movement.x * rotationSpeed * Time.deltaTime);
        transform.position += transform.up *movement.y* speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bubbleMaker.DeleteBubble(collision.gameObject);
        if(transform.localScale.x < maxGrowth)
            transform.localScale += new Vector3(growthFactor, growthFactor);
    }
}
