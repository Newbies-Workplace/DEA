using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiDrag : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private RectTransform rectTransform;
    private Canvas canvas;
    private float DragXPosition;
    private float DragYPosition;

    private void Awake(){
        
        if(canvas == null){
            Transform testCanvasTransform = transform.parent;
            while(testCanvasTransform != null){
                canvas = testCanvasTransform.GetComponent<Canvas>();
                if (canvas != null){
                    break;
                }
                testCanvasTransform = testCanvasTransform.parent;
            }
        }
    }

    public void OnDrag(PointerEventData eventData){

        DragXPosition = (rectTransform.anchoredPosition.x + eventData.delta.x) / canvas.scaleFactor;
        DragYPosition = (rectTransform.anchoredPosition.y + eventData.delta.y) / canvas.scaleFactor;
 
        if (DragXPosition <= -553f)
        {
            DragXPosition = -553f;
        }
 
        if (DragXPosition >= 553f)
        {
            DragXPosition = 553f;
        }
 
        if (DragYPosition <= -339f)
        {
            DragYPosition = -339f;
        }
 
        if (DragYPosition >= 291f)
        {
            DragYPosition = 291f;
        }
 
 
        rectTransform.anchoredPosition = new Vector2(DragXPosition, DragYPosition);
    }

    public void OnEndDrag(PointerEventData eventData){
        //Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData){
        rectTransform.SetAsLastSibling();
    }

}