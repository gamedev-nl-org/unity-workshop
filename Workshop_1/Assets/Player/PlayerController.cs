using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float movementSpeed = 200.0f;

    [SerializeField]
    float rotateSpeed = 4.0f;
	
	void Update () {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward;
        }

        GetComponent<CharacterController>().SimpleMove(movement * Time.deltaTime * movementSpeed);

        Vector3 orientation = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            orientation -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            orientation += transform.right;
        }

        transform.forward = Vector3.Lerp(transform.forward, orientation.normalized, rotateSpeed * Time.deltaTime);
    }
}
