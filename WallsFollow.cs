using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallsFollow : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, player.position.y);
    }
}
