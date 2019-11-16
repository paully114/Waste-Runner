using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGarbage : MonoBehaviour
{
    public static UpdateGarbage Instace { get; set; }

    public GameObject plasticB, cpB, bagB, leavesB, paperB, canB;
    public Button nextButton;

    public bool updateNow = false;

    void Awake()
    {
        Instace = this;

    }

    void Start()
    {
        checkNext();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (updateNow)
        {
            Debug.Log("pleaseUpdate");

            checkNext();
        }
	}

    public void checkNext()
    {
        if(!plasticB.activeSelf && !cpB.activeSelf && !canB.activeSelf && !leavesB.activeSelf && 
            !paperB.activeSelf && !bagB.activeSelf)
        {
            nextButton.gameObject.SetActive(true);
            Debug.Log("check");
        }
    }
}
