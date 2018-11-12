using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMenager : MonoBehaviour {

    public float speed;
    //public Rigidbody2D rb;
    private Vector3 moveVelocity;
	void Start () {
        //rb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
        Vector2 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        moveVelocity = moveInput.normalized * speed;
        transform.Translate(moveVelocity);
	}

    //private void FixedUpdate()
    //{
    //    rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    //}
}
