using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject;
    private TextMeshPro textMeshPro;
    void Update()
    {
        uiObject.SetActive(false);
    }
    private void Awake(){
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    public void OnTriggerEnter(Collider playerObject)
    {
        if(playerObject.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine(WaitForSec());
        }
        IEnumerator WaitForSec()
        {
            yield return new WaitForSeconds(3);
            Destroy(uiObject);
            Destroy(gameObject);
        }
    }

     private void SeeText()
     {
        switch(Person){

            case Kurier:
            GenerateText("Siema uwielbiam placki");
            break;

            case Pudzian:
            GenerateText("Siema uwielbiam placki");
            break;

            case Dostawca:
            GenerateText("Siema uwielbiam placki");
            break;

            case Fotowoltaika:
            GenerateText("Siema uwielbiam placki");
            break;
        }
    }
    private void GenerateText(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);
    }
}
