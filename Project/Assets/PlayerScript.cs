using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector2 initialPosition = new Vector2(0f, -7f);
    private Vector2 initialForce = new Vector2(50f, 50f);
    private Rigidbody2D rigidbody = null;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        ResetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity *= 1.0001f;
    }

    public void ResetPlayer()
    {
        rigidbody.position = initialPosition;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0f;
        rigidbody.AddForce(initialForce);
    }
}
