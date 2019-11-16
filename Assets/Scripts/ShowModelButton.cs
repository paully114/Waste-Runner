using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class ShowModelButton : MonoBehaviour
{
    private Transform objectToShow;
    private Action<Transform> clickAction;

    public void Initialize(Transform objectToshow, Action<Transform> clickAtion)
    {
        this.objectToShow = objectToShow;
        this.clickAction = clickAction;
        GetComponentInChildren<Text>().text = objectToShow.gameObject.name;
    }

	// Use this for initialization
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(HandleButtonClick);
	}
	
    public void HandleButtonClick()
    {
        clickAction(objectToShow);
    }
}
