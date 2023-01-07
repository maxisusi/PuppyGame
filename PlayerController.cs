using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    public float maxPushForce = 1000.0f;
    public float minDragDistance = 0.1f;
    public float maxDragDistance = 20f;

    Vector2 startPosition;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dragDirection = endPosition - startPosition;
            float dragDistance = dragDirection.magnitude;
            dragDirection.Normalize();

            float pushForce = Mathf.Lerp(0, maxPushForce, (dragDistance - minDragDistance) / (maxDragDistance - minDragDistance));

            Debug.Log(pushForce);
            // Apply the push force to the player
            playerRigidbody.AddForce(new Vector2(-dragDirection.x, Mathf.Abs(dragDirection.y)) * pushForce, ForceMode2D.Force);
        }
    }
}