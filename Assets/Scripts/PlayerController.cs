using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;

    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float x_movement =Input.acceleration.x;
        float y_movement = Input.acceleration.y;
        //float x = Input.acceleration.x;
        //float y = Input.acceleration.y;
        Vector3 movement = new Vector3(speed* x_movement, speed * y_movement, 0.0f);
        rb.velocity = movement;
        rb.rotation = Quaternion.Euler(0.0f, 0.0f,  -5*rb.velocity.x);
    }
}
