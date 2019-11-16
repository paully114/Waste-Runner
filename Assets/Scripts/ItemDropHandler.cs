using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDropHandler : MonoBehaviour
{
    public Text plasticText;

    public GameObject currentGO;

    public void dropItem()
    {
        if (gameObject.name == "BioPanel" && ItemDragHandler.itemTag == "Bio")
        {
            currentGO = GameObject.Find(ItemDragHandler.itemName);
            currentGO.SetActive(false);
        }

        else if (gameObject.name == "NonPanel" && ItemDragHandler.itemTag == "NonBio")
        {
            currentGO = GameObject.Find(ItemDragHandler.itemName);
            currentGO.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong");
        }

        UpdateGarbage.Instace.checkNext();
    }

}
