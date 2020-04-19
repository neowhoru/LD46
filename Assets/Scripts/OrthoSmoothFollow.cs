using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class OrthoSmoothFollow : MonoBehaviour {
 
     public Transform target;
     public float followSpeed = 3f;
 
     private Vector3 velocity = Vector3.zero;
 
     void Update () {
        Vector3 newPosition = target.position;
        newPosition.z = -10;
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
 }
