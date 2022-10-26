using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTitleFadeOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvGroup;
    [SerializeField] private GameObject panel;
    // [SerializeField] private bool isDone = true;

    private bool mFaded = false;
    public float Duration = 5.4f;

    void Start(){
        panel.SetActive(true);
        Fade();
    }

    public void Fade(){

        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));

        mFaded = !mFaded;
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end){
        yield return new WaitForSecondsRealtime(2);
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);
            
            yield return null;
        }
        panel.SetActive(false);
        
    }

    
}
