using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFix : MonoBehaviour
{
    [SerializeField] private Rigidbody Rb;
    void Update()
    {
        Rb = GetComponent<Rigidbody>();
        if ((Mathf.Abs(Rb.velocity.x) + Mathf.Abs(Rb.velocity.y) + Mathf.Abs(Rb.velocity.z)) /3 < 0.00001f)
        Rb.velocity = new Vector3(0.00001f, 0.00001f, 0.00001f);
    }
}
