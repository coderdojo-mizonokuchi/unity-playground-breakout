using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    private bool isMoveLeft = false;
    private bool isMoveRight = false;
    public GameObject tapAreaLeft = null;
    public GameObject tapAreaRight = null;
    public float velocity = 10f;
    private Rigidbody2D rigidbody = null;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i=0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                if (t.phase == TouchPhase.Began)
                {
                    Vector2 worldPoint = Camera.main.ScreenToWorldPoint(t.position);
                    RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject == tapAreaLeft) {
                            isMoveLeft = true;
                        }
                        else if (hit.collider.gameObject == tapAreaRight) {
                            isMoveRight = true;
                        }
                    }
                }
                else if (t.phase == TouchPhase.Ended)
                {
                    Vector2 worldPoint = Camera.main.ScreenToWorldPoint(t.position);
                    RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject == tapAreaLeft)
                        {
                            isMoveLeft = false;
                        }
                        else if (hit.collider.gameObject == tapAreaRight)
                        {
                            isMoveRight = false;
                        }
                    }
                }
            }
        }
        if (isMoveLeft && !isMoveRight)
        {
            rigidbody.velocity = new Vector2(-velocity, 0f);
        }
        else if (!isMoveLeft && isMoveRight)
        {
            rigidbody.velocity = new Vector2(velocity, 0f);
        }
    }
}
