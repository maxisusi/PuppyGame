using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidbody;

    EnergyScore energyManager;
    float maxPushForce = 2500.0f;
    float minDragDistance = 0.1f;
    float maxDragDistance = 20f;

    Vector2 startPosition;
    float forceReducer;


    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        energyManager = GetComponent<EnergyScore>();
    }

    void Update()
    {
        MovePlayer();
    }


    void MovePlayer()
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

            IncreaseMassByDragDistance(dragDistance);

            playerRigidbody.AddForce(new Vector2(-dragDirection.x, Mathf.Abs(dragDirection.y)) * (pushForce), ForceMode2D.Force);
        }

    }


    void IncreaseMassByDragDistance(float dragDistance)
    {

        if (playerRigidbody.mass >= 3f)
        {
            playerRigidbody.mass = 50f;
            return;
        }

        float NewEnergy = energyManager.reducer + dragDistance;
        playerRigidbody.mass = 1 + (NewEnergy / 100);
        energyManager.reducer = NewEnergy;
    }
}