using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerScript : MonoBehaviour {
    float force = 500f;
    Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    IEnumerator AnimateBouncy() {
        anim.Play("Up");
        yield return new WaitForSeconds(.5f);
        anim.Play("Down");
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player") {
            target.gameObject.GetComponent<PlayerScript>().BoucePlayerWithBouncy(force);
            StartCoroutine(AnimateBouncy());
        }
    }
}
