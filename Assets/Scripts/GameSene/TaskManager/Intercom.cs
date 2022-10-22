using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intercom : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject Panel;

    public float range = 3;
    int max_dist = 3;

    Quaternion rightAngle;
    Quaternion leftAngle;
    Quaternion centerAngle;

        //need for task
    private GameObject task;
    private int hour = 1; 
    private int minute = 30;
    private string taskname = "Intercom";
    private string tasktitle = "Decide about doors";
    private string taskdescription = "Go to the intercom and decide about opening doors";

    //task check variables
    public static bool TimesUp = false;
    public static bool isDone = false;
    //public static int TaskGoal = 40;
    private bool QuestActive;

    private bool isNear(int max_dist, GameObject target, GameObject heart){
        float distance = Vector3.Distance(heart.transform.position, target.transform.position);
        if (distance > max_dist) return false;
        return true;
    }


    void Start()
    {
        leftAngle = Quaternion.Euler(10,30,0);
        rightAngle = Quaternion.Euler(10,-30,0);
        centerAngle = Quaternion.Euler(10,0,0);
    }

    private void DisablePlayer(){
        bool isActive = Panel.activeSelf;
        ThirdPersonController.can_move = !isActive;
        ThirdPersonController.can_move_camera = !isActive;
    }

    private void AccessObject(){
        DisablePlayer();
        if(isNear(2, player, heart)) if (Input.GetKeyDown(KeyCode.E)) if(Panel != null) Panel.SetActive(true);
    }

    void Update()
    {

        Vector3 forward = centerAngle*Vector3.forward;
        Vector3 left = leftAngle*Vector3.forward;
        Vector3 right = rightAngle*Vector3.forward;
        Ray RayForward = new Ray(transform.position, transform.TransformDirection(forward * range));
        Ray RayLeft = new Ray(transform.position, transform.TransformDirection(left * range));
        Ray RayRight = new Ray(transform.position, transform.TransformDirection(right * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(forward * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(left * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(right * range));
        
        if (Physics.Raycast(RayForward, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true )
            {
                AccessObject();
            }
        }

            if (Physics.Raycast(RayLeft, out hit, range))
        {
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true )
            {
                AccessObject();
            }
        }

            if (Physics.Raycast(RayRight, out hit, range))
        {
            if (hit.collider.tag == "Player" && isNear(max_dist,player,heart) == true )
            {
                AccessObject();
            }
        }

    }
}
