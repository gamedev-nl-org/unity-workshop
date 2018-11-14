using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject cameraTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        Vector3 targetPos = cameraTarget.transform.position;
        targetPos.z = transform.position.z;
        transform.position = targetPos;
    }
}
