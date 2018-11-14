using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour {
    Vector3 inputVector = Vector3.zero;

    [SerializeField]
    float playerSpeed = 6.0f;

    private void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        Vector3 lookAtTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAtTarget.z = 0;

        // don't bother reorienting if we're right on top of our character
        Vector2 lookAtVector = lookAtTarget - transform.position;
        if (lookAtVector.magnitude > GetComponent<CapsuleCollider2D>().size.x)
        {
            // We might normally use the code below in a 3D game but...
            // transform.LookAt(LookAtTarget); makes z face the target, therefore doesn't work in 2D
            transform.right = lookAtTarget - transform.position;
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = inputVector * playerSpeed;
        rigid.angularVelocity = 0;
    }
}
