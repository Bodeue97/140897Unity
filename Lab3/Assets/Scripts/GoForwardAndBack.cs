using UnityEngine;

public class CubeGoFandB : MonoBehaviour
{
    public float speed = 5f; 
    public float moveRange = 10f;
    private Rigidbody rb;
    private bool moveRight = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.velocity = new Vector3(speed, 0f, 0f);
    }

    void FixedUpdate()
    {
       
        if ((transform.position.x >= moveRange && moveRight) || (transform.position.x <= 0 && !moveRight))
        {
            ChangeDirection();
        }
    }

   
    void ChangeDirection()
    {
        moveRight = !moveRight; 
        rb.velocity = moveRight ? new Vector3(speed, 0f, 0f) : new Vector3(-speed, 0f, 0f);
    }
}
