using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public Transform leftBoundaryPosition;
    public Transform rightBoundaryPosition;
    public Transform bottomBoundaryPosition;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        bool hasBoundary = false;
        if (leftBoundaryPosition == null && rightBoundaryPosition == null && bottomBoundaryPosition == null)
        {
            Vector3 goalPos = target.position;
            transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
            return;
        }

        if (target != null)
        {
            // ToDo: we need to differ in which direction movement is allowed
            float x = transform.position.x;
            float y = transform.position.y;
            if (target.transform.position.x > leftBoundaryPosition.position.x && target.transform.position.x < rightBoundaryPosition.position.x)
            {
                // We are allowed to move along the x axis
                x = target.position.x;

            }

            if (target.transform.position.y > bottomBoundaryPosition.position.y)
            {
                y = target.position.y;
            }
            Vector3 goalPos = new Vector3(x, y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
        }


    }
}
