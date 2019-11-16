using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTimeTrial : MonoBehaviour
{
	// Update is called once per frame
	void Update () {
		if(GameManager.Instance.IsDead)
        {
            if (PlayerPrefs.GetFloat("hScore") < DeadMenu.Instance.newScore)
            {
                PlayerPrefs.SetFloat("hScore", DeadMenu.Instance.newScore);
            }
        }
	}
}
