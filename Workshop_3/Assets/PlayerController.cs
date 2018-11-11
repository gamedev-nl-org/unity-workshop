using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Vector2 TargetVelocity = Vector2.zero;
    Vector3 LookAtTarget = Vector3.zero;
    RaycastHit2D[] results = new RaycastHit2D[16];

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TargetVelocity.x = Input.GetAxis("Horizontal");
        TargetVelocity.y = Input.GetAxis("Vertical");

        LookAtTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        LookAtTarget.z = 0;

        //We might normally use the code below in a 3D game but...
        //transform.LookAt(LookAtTarget); makes z face the target, therefore doesn't work in 2D
        transform.right = LookAtTarget - transform.position;
    }

    private void FixedUpdate()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        
        rigid.velocity = TargetVelocity * 3.0f;
        //rigid.Cast(rigid.velocity, results);
        //if(results.Length > 0)
        //{
        //    rigid.velocity = Vector2.zero;
        //}

    }
}
