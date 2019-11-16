using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAdventure : MonoBehaviour
{
    private float lastGold, lastHScore, lastStar, s1, s2, xs3, s4, s5, s6;

	// Use this for initialization
	void Start ()
    {
        LoadData();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (GameManager.Instance.IsDead)
        {
            
            if (GameManager.Instance.gamemode == 2)
            {
                Debug.Log(DeadQuest.Instance.star + " > " + s6);
                if (DeadQuest.Instance.s1 > s1)
                {
                    PlayerPrefs.SetFloat("s1", DeadQuest.Instance.s1);
                }
                if (DeadQuest.Instance.s2 > s2)
                {
                    PlayerPrefs.SetFloat("s2", DeadQuest.Instance.s2);
                }
                if (DeadQuest.Instance.xs3 > xs3)
                {
                    PlayerPrefs.SetFloat("xs3", DeadQuest.Instance.xs3);
                }
                if (DeadQuest.Instance.s4 > s4)
                {
                    PlayerPrefs.SetFloat("s4", DeadQuest.Instance.s4);
                }
                if (DeadQuest.Instance.s5 > s5)
                {                   
                    PlayerPrefs.SetFloat("s5", DeadQuest.Instance.s5);
                    Debug.Log("true");
                }
                if (DeadQuest.Instance.s6 > s6)
                {
                    PlayerPrefs.SetFloat("s6", DeadQuest.Instance.s6);
                }
            }
        }
	}

    public void LoadData()
    {

        lastGold = PlayerPrefs.GetFloat("gold");
        lastHScore = PlayerPrefs.GetFloat("score");
        lastStar = PlayerPrefs.GetFloat("star");

        s1 = PlayerPrefs.GetFloat("s1");
        s2 = PlayerPrefs.GetFloat("s2");
        xs3 = PlayerPrefs.GetFloat("xs3");
        s4 = PlayerPrefs.GetFloat("s4");
        s5 = PlayerPrefs.GetFloat("s5");
        s6 = PlayerPrefs.GetFloat("s6");
    }
}
