using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Vector2 TargetVelocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TargetVelocity.x = Input.GetAxis("Horizontal");
        TargetVelocity.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = TargetVelocity;
    }
}
