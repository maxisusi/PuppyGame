using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{

    public float points = 20f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EnergyScore energyManager = collision.gameObject.GetComponent<EnergyScore>();
            energyManager.reducer -= points;

            Destroy(gameObject);
        }
    }
}
