using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject CameraTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        Vector3 TargetPos = CameraTarget.transform.position;
        TargetPos.z = transform.position.z;
        transform.position = TargetPos;
    }
}
