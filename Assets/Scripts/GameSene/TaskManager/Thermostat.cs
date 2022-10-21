using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermostat : MonoBehaviour
{
    public float range = 2;
    Quaternion rightAngle;
    Quaternion leftAngle;
    Quaternion centerAngle;
    Quaternion leftMaxAngle;
    Quaternion rightMaxAngle;

    void Start(){
        leftAngle = Quaternion.Euler(15,45,0);
        rightAngle = Quaternion.Euler(15,-45,0);
        centerAngle = Quaternion.Euler(15,0,0);
        leftMaxAngle = Quaternion.Euler(15,70,0);
        rightMaxAngle = Quaternion.Euler(15,-70,0);
    }

    void Update()
    {

        Vector3 forward = centerAngle*Vector3.forward;
        Vector3 left = leftAngle*Vector3.forward;
        Vector3 right = rightAngle*Vector3.forward;
        //Vector3 leftm = leftMaxAngle*Vector3.forward;
        //Vector3 rightm = rightMaxAngle*Vector3.forward;
        Ray RayForward = new Ray(transform.position, transform.TransformDirection(forward * range));
        Ray RayLeft = new Ray(transform.position, transform.TransformDirection(left * range));
        Ray RayRight = new Ray(transform.position, transform.TransformDirection(right * range));
        //Ray leftMaxAngle = new Ray(transform.position, transform.TransformDirection(leftm * range));
        //Ray rightMaxAngle = new Ray(transform.position, transform.TransformDirection(rightm * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(forward * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(left * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(right * range));
        //Debug.DrawRay(transform.position, transform.TransformDirection(leftm * range));
        //Debug.DrawRay(transform.position, transform.TransformDirection(rightm * range));


        if (Physics.Raycast(RayForward, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Player")
            {
                Debug.Log("hello");
            }
        }
    }
}
