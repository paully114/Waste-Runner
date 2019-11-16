using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DeadQuest : MonoBehaviour {

    public static DeadQuest Instance { get; set; }

    public Image bgImg;
    public bool isShowned = false;
    private float transition = 0.0f;
    public GameObject mainPanel;
    public GameObject nextStageGO;
    public int gamemode = 2;

    public GameObject s1g, s2g, s3g;
    public float stage;
    public float star;
    public TextMeshProUGUI scoreText;
    public float s1, s2, s3, s4, s5, s6, xs3, xs5;

    void Awake()
    {
        
        Instance = this;
        mainPanel.SetActive(false);
        Debug.Log(stage);
    }

    

    public void ClickMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    void Update()
    {
        if (!isShowned)
            return;

        transition += Time.deltaTime;
        //Debug.Log(gameUI.name);
    }

    public void ToggleThis(float score, float garbageScore)
    {
        isShowned = true;
        
        mainPanel.SetActive(true);
        scoreText.text = ((int)score).ToString();
       // gameUI.SetActive(false);

        if (garbageScore >= 2 && garbageScore <= 4)
        {
            nextStageGO = GameObject.Find("nextGO");
            nextStageGO.GetComponent<Button>().interactable = true;
            s1g.SetActive(true);
            star = 1;
        }

        if(garbageScore >= 5 && garbageScore <=8)
        {
            nextStageGO = GameObject.Find("nextGO");
            nextStageGO.GetComponent<Button>().interactable = true;
            s1g.SetActive(true);
            s2g.SetActive(true);
            star = 2;
        }

        if(garbageScore >= 9)
        {
            nextStageGO = GameObject.Find("nextGO");
            s1g.SetActive(true);
            s2g.SetActive(true);
            s3g.SetActive(true);
            nextStageGO.GetComponent<Button>().interactable = true;
            star = 3;
        }

        if (stage == 1)
        {
            s1 = star;
        }
        if (stage == 2)
        {
            s2 = star;

        }
        if (stage == 3)
        {
            xs3 = star;
        }
        if (stage == 4)
        {
            s4 = star;
        }
        if (stage == 5)
        {
            s5 = star;
        }
        if (stage == 6)
        {
            s6 = star;
        }

        Debug.Log("Show " + s5);
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void nextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
