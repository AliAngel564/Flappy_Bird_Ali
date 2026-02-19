using UnityEngine;

public class Player : MonoBehaviour
{
    public float flapVelocity = 2f;
    private Rigidbody2D birdRB;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            birdRB.velocity = Vector2.up * flapVelocity;
        }
    }
}
