using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStar : MonoBehaviour
{
    private float star;
    public GameObject[] starUnlocked;
    public int stage;
    public GameObject[] s1Star, s2Star, s3Star, s4Star, s5Star, s6Star;

    void Start()
    {
        LoadPlayer();
        Debug.Log(PlayerPrefs.GetFloat("s6"));
    }

    void LoadPlayer()
    {
        Debug.Log(PlayerPrefs.GetFloat("s5"));
        if (PlayerPrefs.GetFloat("s1") == 1)
        {
            starUnlocked[0].SetActive(false);
            s1Star[0].SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("s1") == 2)
        {
            starUnlocked[0].SetActive(false);
            
            s1Star[0].SetActive(true);
            s1Star[1].SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("s1") == 3)
        {
            starUnlocked[0].SetActive(false);
            s1Star[0].SetActive(true);
            s1Star[1].SetActive(true);
            s1Star[2].SetActive(true);
        }

        if (PlayerPrefs.GetFloat("s2") == 1)
        {
            starUnlocked[1].SetActive(false);
            s2Star[0].SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("s2") == 2)
        {
            starUnlocked[1].SetActive(false);
            s2Star[0].SetActive(true);
            s2Star[1].SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("s2") == 3)
        {
            starUnlocked[1].SetActive(false);
            s2Star[0].SetActive(true);
            s2Star[1].SetActive(true);
            s2Star[2].SetActive(true);
        }

        if (PlayerPrefs.GetFloat("xs3") == 1)
        {
            starUnlocked[2].SetActive(false);
            s3Star[0].SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("xs3") == 2)
        {
            starUnlocked[2].SetActive(false);
            s3Star[0].SetActive(true);
            s3Star[1].SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("xs3") == 3)
        {
            starUnlocked[2].SetActive(false);
            s3Star[0].SetActive(true);
            s3Star[1].SetActive(true);
            s3Star[2].SetActive(true);
        }

        if (PlayerPrefs.GetFloat("s4") == 1)
        {
            starUnlocked[3].SetActive(false);
            s4Star[0].SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("s4") == 2)
        {
            starUnlocked[3].SetActive(false);
            s4Star[0].SetActive(true);
            s4Star[1].SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("s4") == 3)
        {
            starUnlocked[3].SetActive(false);
            s4Star[0].SetActive(true);
            s4Star[1].SetActive(true);
            s4Star[2].SetActive(true);
        }

        if (PlayerPrefs.GetFloat("s5") == 1)
        {
            starUnlocked[4].SetActive(false);
            s5Star[0].SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("s5") == 2)
        {
            starUnlocked[4].SetActive(false);
            s5Star[0].SetActive(true);
            s5Star[1].SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("s5") == 3)
        {
            starUnlocked[4].SetActive(false);
            s5Star[0].SetActive(true);
            s5Star[1].SetActive(true);
            s5Star[2].SetActive(true);
        }

        if (PlayerPrefs.GetFloat("s6") == 1)
        {
            s6Star[0].SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("s6") == 2)
        {
            //starUnlocked[5].SetActive(false);
            s6Star[0].SetActive(true);
            s6Star[1].SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("s6") == 3)
        {
            //starUnlocked[6].SetActive(false);
            s6Star[0].SetActive(true);
            s6Star[1].SetActive(true);
            s6Star[2].SetActive(true);
        }
    }


}
