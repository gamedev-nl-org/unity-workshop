using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject cameraTarget;

    private void LateUpdate()
    {
        Vector3 targetPos = cameraTarget.transform.position;
        targetPos.z = transform.position.z;
        transform.position = targetPos;
    }
}
