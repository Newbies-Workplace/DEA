using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiDrag : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform DesktopPanel;
    [SerializeField] private RectTransform TaskBarPanel;
    private Canvas canvas;
    private float DragXPosition;
    private float DragYPosition;
    private float objectWidth;
    private float objectHeight;
    private float panelWidth;
    private float panelHeight;
    private float TaskBarWidth;
    private float TaskBarHeight;

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

        objectWidth = rectTransform.rect.width;
        objectHeight = rectTransform.rect.height;

        panelWidth = DesktopPanel.rect.width;
        panelHeight = DesktopPanel.rect.height;

        TaskBarHeight = TaskBarPanel.rect.height;
        TaskBarWidth = TaskBarPanel.rect.width;

        DragXPosition = (rectTransform.anchoredPosition.x + eventData.delta.x) / canvas.scaleFactor;
        DragYPosition = (rectTransform.anchoredPosition.y + eventData.delta.y) / canvas.scaleFactor;
 
        if (DragXPosition <= -(panelWidth-objectWidth)/2)
        {
            DragXPosition = -(panelWidth-objectWidth)/2;
        }
 
        if (DragXPosition >= (panelWidth-objectWidth)/2)
        {
            DragXPosition = (panelWidth-objectWidth)/2;
        }
 
        if (DragYPosition <= -(panelHeight-objectHeight)/2)
        {
            DragYPosition = -(panelHeight-objectHeight)/2;
        }
 
        if (DragYPosition >= ((panelHeight-objectHeight)/2)-TaskBarHeight)
        {
            DragYPosition = ((panelHeight-objectHeight)/2)-TaskBarHeight;
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