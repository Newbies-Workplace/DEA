using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ThirdPersonController : MonoBehaviour
{    
    [SerializeField] private CharacterController controller;
    [SerializeField] private GameObject animator;
    [SerializeField] private AudioSource source;
    [SerializeField] private bool isWalking = false;
    [SerializeField] private CinemachineBrain cinemaBrain;
    private float moveAmount;
    [SerializeField] private Transform cam;
    [SerializeField] private float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public bool can_move = true;
    public float groundDistance = 0.2f;
    public float gravity = -9f;
    public float jumpHeight = 1.5f;
    public LayerMask groundMask;
    public Transform groundCheck;
    public CinemachineBrain CMBrain;
    Vector3 velocity;
    public GameObject objectToFind;
    public bool can_move_camera = true;
    bool isGrounded;
    float horizontal = 0;
    float vertical = 0;
    [SerializeField] public static bool isVisibleCursor = false; 

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update(){

        Cursor.visible = isVisibleCursor;

        cinemaBrain.enabled = can_move_camera;
        if(can_move){

            GravitationAndJump();

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            if (animator != null){
                moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
                animator.GetComponent<AnimatorManager>().UpdateAnimatorValues(0, moveAmount);
            }
            if(Mathf.Abs(vertical) + Mathf.Abs(horizontal) > 0 ) {
                isWalking = true;
            }else{
                isWalking = false;
            }
            if (isWalking && !source.isPlaying) source.Play();
            if (!isWalking) source.Stop();

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

    private void GravitationAndJump(){
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if(isGrounded && velocity.y < 0){
                velocity.y = -2f;
            }

            if(Input.GetButtonDown("Jump") && isGrounded){
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
    }
}
