using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonController : MonoBehaviour{

    public CharacterController controller;
    public Transform cam;
    public static bool can_move = true;
    public float speed = 6f;
    public float gravity = -9f;
    public float turnSmoothTime = 0.1f;
    public float jumpHeight = 1.5f;
    
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    float turnSmoothVelocity;
    public CinemachineBrain CMBrain;
    public GameObject objectToFind;
    public static bool can_move_camera = true;
    

    void Update(){

        objectToFind = GameObject.FindGameObjectWithTag("MainCamera");
        CMBrain = objectToFind.GetComponent<CinemachineBrain>();
        CMBrain.enabled = can_move_camera;

        if(can_move){

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if(isGrounded && velocity.y < 0){
                velocity.y = -2f;
            }

            if(Input.GetButtonDown("Jump") && isGrounded){
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if(direction.magnitude >= 0.1f){

                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);           
            }


        }
    }
}