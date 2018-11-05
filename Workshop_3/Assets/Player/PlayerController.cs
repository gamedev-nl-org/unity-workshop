using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float movementSpeed = 200.0f;

    [SerializeField]
    float rotateSpeed = 4.0f;
	
	void Update () {
        Vector3 movement = transform.forward * Input.GetAxis("Vertical");
        GetComponent<CharacterController>().SimpleMove(movement * Time.deltaTime * movementSpeed);

        Vector3 orientation = transform.right * Input.GetAxis("Horizontal");
        transform.forward = Vector3.Lerp(transform.forward, orientation.normalized, rotateSpeed * Time.deltaTime);
    }
}
