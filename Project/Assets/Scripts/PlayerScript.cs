using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector2 initialPosition = new Vector2(0f, -7f);
    private Vector2 initialForce = new Vector2(50f, 50f);
    private Rigidbody2D rigidbody = null;
    private float velocityMin = 100f;
    private float velocityNow = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        ResetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rigidbody.velocity.x) > 0f && Mathf.Abs(rigidbody.velocity.y / rigidbody.velocity.x) < 0.1f)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * 1.01f);
        }
        if (Mathf.Abs(rigidbody.velocity.y) > 0f && Mathf.Abs(rigidbody.velocity.x / rigidbody.velocity.y) < 0.1f)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x * 1.01f, rigidbody.velocity.y);
        }
        velocityNow *= 1.0001f;
        rigidbody.velocity *= velocityNow / rigidbody.velocity.SqrMagnitude();
    }

    public void ResetPlayer()
    {
        rigidbody.position = initialPosition;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0f;
        rigidbody.AddForce(initialForce);
    }
}
