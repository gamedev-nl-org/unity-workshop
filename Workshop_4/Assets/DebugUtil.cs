using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUtil : MonoBehaviour {
    // not going to bother explaining this, there are lots of resources on how to draw circles.
    static public void DrawCircle(Vector3 position, float radius, Color color, int segments = 100, float duration = 0)
    {
        float angle = 0f;
        Vector3 lastPoint = Vector3.zero;
        Vector3 thisPoint = Vector3.zero;

        for (int i = 0; i < segments + 1; i++)
        {
            thisPoint.x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            thisPoint.y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            if (i > 0)
            {
                Debug.DrawLine(lastPoint + position, thisPoint + position, color, duration);
            }

            lastPoint = thisPoint;
            angle += 360f / segments;
        }
    }
}
