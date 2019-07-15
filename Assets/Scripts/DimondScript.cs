using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimondScript : MonoBehaviour
{
    void Start() {
        DoorScript.instance.collectablesCount++;
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player") {
            Destroy(gameObject);
            DoorScript.instance.DecrementCollectable();
        }
    }
}
