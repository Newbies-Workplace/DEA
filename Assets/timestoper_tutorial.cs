using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timestoper_tutorial : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject todo;
    [SerializeField] private GameObject indi;
    [SerializeField] private AudioSource player;

    public void CloseTutorial(){
        InGameTime.time_stop = false;
        GameObject.Find("Player").GetComponent<ThirdPersonController>().can_move = true;
        GameObject.Find("Player").GetComponent<ThirdPersonController>().can_move_camera = true;
        ThirdPersonController.isVisibleCursor = false;
        player.enabled = true;
        Fade();
    }


    [SerializeField] private CanvasGroup canvGroup;

    private bool mFaded = false;
    public float Duration = 0.4f;

    public void Fade(){

        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));

        mFaded = !mFaded;
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end){
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);
            
            yield return null;
        }
        panel.SetActive(false);
        indi.SetActive(true);
        todo.SetActive(true);
    }
}
