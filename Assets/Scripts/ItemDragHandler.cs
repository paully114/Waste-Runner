using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public static ItemDragHandler Instance { get; set; }

    public static string itemTag, itemName;

    public Vector3 origPos;

    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        origPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemTag = gameObject.tag;
        itemName = gameObject.name;

        transform.position = Input.mousePosition ;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = origPos;
    }
}
