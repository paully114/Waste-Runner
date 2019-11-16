using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public int gMode;

    void Start()
    {
        GameManager.Instance.gamemode = gMode;
    }
}
