using UnityEngine;
using System.Collections;

public class Randomratotar : MonoBehaviour {

    public float tumble;
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        Vector3 movement = new Vector3(0.0f, 0.0f, -10.0f);
        GetComponent<Rigidbody>().velocity = movement;
    }
}
