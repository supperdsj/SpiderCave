using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalkerScript : MonoBehaviour {
    Rigidbody2D myBody;
    public float speed = 1f;
    [SerializeField]
    Transform startPos, endPos;
    bool collision;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Move();
        ChangeDirection();
    }

    void Move() {
        myBody.velocity=new Vector2(transform.localScale.x,0)* speed;
    }

    void ChangeDirection() {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(startPos.position,endPos.position,Color.green);
        if (!collision) {
            Vector3 temp = transform.localScale;
            temp.x = temp.x * -1f;
            transform.localScale = temp;
        }
    }
}
