using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    [SerializeField]
    Transform targetTransform;
    [SerializeField]
    float SmoothSpeed = 3.5f;
    [SerializeField]
    private Vector3 offset;
    // Update is called once per frame
    void LateUpdate()
    {
        if(targetTransform!=null)
        {
            Vector3 DesiredPosition = targetTransform.position + offset;
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed * Time.deltaTime);
            transform.position = SmoothedPosition;
        }
       
    }
}
