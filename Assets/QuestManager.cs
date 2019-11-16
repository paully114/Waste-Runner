using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; set; }

    private float totalQuest = 10f;
    private float questCount;
    public GameObject panel;
	
    void Awake()
    {
        Instance = this;
    }

	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(questCount);	
	}

    public void QuestCounter()
    {
        if(questCount == (totalQuest-1))
        {
           
            PlayerMotor.Instance.Crash();
        }
        else
        {
            questCount++;
            Debug.Log(questCount);
        }
    }


}
