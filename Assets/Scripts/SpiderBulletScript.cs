using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBulletScript : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player") {
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
        else if (target.tag == "Ground") {
            Destroy(gameObject);
        }
    }
}
