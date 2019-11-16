using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float gold;
    public bool unlockSec;
    public bool unlockThird;
    public float highscore;
    public float Star;
    public float totalStar;
    public float s1, s2, s3, s4, s5, s6, x3;

    public PlayerData(GameManager gm)
    {
        gold += gm.lastGold;
        Star += gm.lastStar;
        highscore = gm.lastHScore;

        

        if(s1 > gm.s1)
        {
            Debug.Log("True");
            s1 = gm.s1;
        }
        if (s2 < gm.s2)
        {
            Debug.Log("True");
            s2 = gm.s2;
        }
        if (s3 < gm.s3)
        {
            Debug.Log("True");
            s3 = gm.s3;
        }
        if (s4 < gm.s4)
        {
            Debug.Log("True");
            s4 = gm.s4;
        }
        if (s5 < gm.s5)
        {
            Debug.Log("True");
            s5 = gm.s5;
        }
    }
}
