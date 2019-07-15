using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float moveForce = 20f, jumpForce = 700f, maxVelocity = 4f;
    Rigidbody2D myBody;
    Animator anim;
    bool grounded = true;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
    }

    void FixedUpdate() {
        PlayerWalkKeyboard();
    }

    void PlayerWalkKeyboard() {
        float forceX = 0f;
        float forceY = 0f;
        float vel = myBody.velocity.x;
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0) {
            if (vel < maxVelocity) {
                forceX = moveForce * (grounded ? 1f : 1.1f);
            }

            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
            anim.SetBool("Walk", true);
        }
        else if (h < 0) {
            if (vel > -maxVelocity) {
                forceX = -moveForce * (grounded ? 1f : 1.1f);
            }

            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            anim.SetBool("Walk", true);
        }
        else {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.Space)) {
            if (grounded) {
                grounded = false;
                forceY = jumpForce;
            }
        }

        myBody.AddForce(new Vector2(forceX, forceY));
    }

    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "Ground") {
            grounded = true;
        }
    }

    public void BoucePlayerWithBouncy(float force) {
        if (grounded) {
            grounded = false;
            myBody.AddForce(new Vector2(0,force));
        }
    }
}
