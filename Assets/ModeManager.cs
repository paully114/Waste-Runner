using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public GameObject thisGo, trialGo, advGo;

    public void AdvClick()
    {
        thisGo.SetActive(false);
        advGo.SetActive(true);
    }

    
}
