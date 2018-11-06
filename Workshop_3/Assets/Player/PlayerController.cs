using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float movementSpeed = 200.0f;

    [SerializeField]
    float rotateSpeed = 4.0f;

    [SerializeField]
    CharacterController characterController;

    [SerializeField]
    Camera mainCamera;

    Vector3 lastIntersectionPoint;

    private void Start()
    {
        lastIntersectionPoint = transform.position + transform.forward;
    }

    void Update () {
        transform.position = new Vector3(Input.GetAxis("Horizontal"), transform.position.y, Input.GetAxis("Vertical"));

        Vector3 mousePosition = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        bool didIntersectPlane = Physics.Raycast(ray, out hit);//plane.Raycast(ray, out intersectionDistance);
        if (didIntersectPlane)
        {
            Vector3 intersectionPoint = hit.point;
            Debug.DrawLine(intersectionPoint + Vector3.back, intersectionPoint + Vector3.forward, Color.cyan);
            Debug.DrawLine(intersectionPoint + Vector3.left, intersectionPoint + Vector3.right, Color.cyan);
            Debug.DrawLine(ray.origin, intersectionPoint, Color.green);

            intersectionPoint = Vector3.Lerp(lastIntersectionPoint, intersectionPoint, Time.deltaTime);
            transform.LookAt(intersectionPoint);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);
            lastIntersectionPoint = intersectionPoint;
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
        }
    }
}
