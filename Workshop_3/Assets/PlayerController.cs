using UnityEngine;

public class PlayerController : MonoBehaviour {

    Vector3 inputVector = Vector3.zero;
    RaycastHit2D[] directHits = new RaycastHit2D[1];
    RaycastHit2D[] tangentHits = new RaycastHit2D[1];

    [SerializeField]
    float playerSpeed = 6.0f;

    [SerializeField]
    ContactFilter2D obstructionsToPlayer = new ContactFilter2D();

    [SerializeField]
    float wallBounceDistance = 0.001f;

    void Update() {
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

        Vector3 moveVector = inputVector * playerSpeed * Time.deltaTime;
        int directHitCount = GetComponent<CapsuleCollider2D>().Cast(inputVector, directHits);

        if (directHitCount > 0)
        {
            RaycastHit2D directHit = directHits[0];

            if (moveVector.magnitude >= directHit.distance)
            {
                float diameter = GetComponent<CapsuleCollider2D>().size.x;
                float radius = diameter / 2.0f;
                Vector2 positionAtWall = directHit.point + directHit.normal * radius;
                   
                float wallBounceDistance = 0.001f;
                positionAtWall += (directHit.normal * wallBounceDistance);

                Vector2 previousPosition = transform.position;
                float distanceSoFar = (positionAtWall - previousPosition).magnitude;

                DebugUtil.DrawCircle(transform.position + moveVector, radius, Color.red);

                Vector2 wallTangent = Vector3.Cross(Vector3.forward, directHit.normal);
                float remainingDistance = moveVector.magnitude - distanceSoFar;

                float dotForSign = Vector3.Dot(wallTangent, moveVector);
                Vector2 directionalWallTangent = (wallTangent * dotForSign).normalized;
                Vector2 finalTangentOffset = directionalWallTangent * remainingDistance;

                int tangentHitCount = Physics2D.CapsuleCast(positionAtWall, GetComponent<CapsuleCollider2D>().size, CapsuleDirection2D.Horizontal, 0, directionalWallTangent, obstructionsToPlayer, tangentHits);
                if(tangentHitCount > 0)
                {
                    RaycastHit2D tangentHit = tangentHits[0];
                    if(remainingDistance >= tangentHit.distance)
                    {
                        DebugUtil.DrawCircle(positionAtWall + finalTangentOffset, radius, Color.magenta);
                        transform.position = tangentHit.point + tangentHit.normal * radius;
                        return;
                    }
                }

                Debug.DrawLine(positionAtWall, positionAtWall + directionalWallTangent);
                transform.position = positionAtWall + finalTangentOffset;
                return;
            }
        }

        transform.position += moveVector;
    }
}
