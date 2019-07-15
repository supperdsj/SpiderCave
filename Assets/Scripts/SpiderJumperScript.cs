using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class SpiderJumperScript : MonoBehaviour {
    float forceY = 300f;

    Rigidbody2D myBody;
    Animator anim;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start() {
        StartCoroutine(Attack());
    }

    IEnumerator Attack() {
        yield return new WaitForSeconds(Random.Range(2,7));
        forceY = Random.Range(250, 550);
        myBody.AddForce(new Vector2(0,forceY));
        anim.SetBool("Attack",true);
        StartCoroutine(Attack());
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Ground") {
            anim.SetBool("Attack",false);
        }else if (target.tag == "Player") {
            Destroy(target.gameObject);
        }
    }
}
