using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var horizontal = Input.GetAxis("Horizontal") * transform.right;
        var vertical = Input.GetAxis("Vertical") * transform.up;
		GetComponent<Rigidbody2D>().AddForce(horizontal + vertical);
	}
}
