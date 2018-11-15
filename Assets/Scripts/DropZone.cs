using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {

    public CardManager cm;

    private GameObject cardManager;

    void Start()
    {
        //cardManager = GameObject.Find()
    }

    public void OnDrop(PointerEventData eventData)
    {

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }

        string name = eventData.pointerDrag.name;

        //sends card name to CardManager
        cm.ActivateCard(eventData.pointerDrag.name);

        //Destroy dropped card
        Destroy(eventData.pointerDrag);
    }
}
