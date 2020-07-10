using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MatchColor : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform myParent;

    Transform tempParent;

    CanvasGroup cg;
    RectTransform rt;

    Vector3 newPosition;

    void Awake()
    {
        cg = this.gameObject.AddComponent<CanvasGroup>();

        rt = this.GetComponent<RectTransform>();

        tempParent = GameObject.Find("Canvas").transform;
    }




    /// <summary>
    /// Raises the begin drag event.
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        myParent = transform.parent;

        cg.blocksRaycasts = false;

        this.transform.SetParent(tempParent);
    }

    /// <summary>
    /// Raises the drag event.
    /// </summary>
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, Input.mousePosition, eventData.enterEventCamera, out newPosition);
        transform.position = newPosition;
    }

    /// <summary>
    /// Raises the end drag event.
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject target = eventData.pointerEnter;

        if (target.name == this.gameObject.name)
        {
            target.GetComponent<ActivateColor>().Colored.SetActive(true);
            target.GetComponent<Image>().color=new Color(0,0,0,0);
            this.transform.SetParent(myParent);
            this.transform.localPosition = Vector3.zero;
        }
        else
        {
            this.transform.SetParent(myParent);
            this.transform.localPosition = Vector3.zero;
        }

        cg.blocksRaycasts = true;

    }



}

