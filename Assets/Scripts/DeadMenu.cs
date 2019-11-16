using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeadMenu : MonoBehaviour
{
    public static DeadMenu Instance { get; set; }

    public Text scoreText, garbageText, coinText,totalScoreText, plasticText, cpText, canText, bagText, leavesText, 
        paperText, currentScoreText;
    public Image bgImg;
    public float newScore, highScore;

    public float plasticCount,cpCount,canCount,bagCount,leavesCount,paperCount, lastGold, lastHScore;
    public Button plasticB, cpB, bagB, leavesB, paperB, canB;

    public bool isShowned = false;
    private float transition = 0.0f;

    public GameObject player;
    public GameObject tileManager;
    public GameObject myPanel;
    public GameObject nextObj, prevObj;

    public TextMeshProUGUI scoreTextTMP;

    void Awake()
    {
        Instance = this;
        //myPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isShowned)
            return;
        
            transition += Time.deltaTime;
            bgImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
              
	}

    public void ToggleEndMenu(float score, float garbage,float coin, float plastic, float can, float cp, float bag, 
        float paper, float leaves)
    {
        player.SetActive(false);
        tileManager.SetActive(false);
        newScore = score;

        isShowned = true;
        myPanel.SetActive(true);
        scoreText.text = ((int)score).ToString();
        garbageText.text = ((int)garbage).ToString();
        coinText.text = ((int)coin).ToString();
        totalScoreText.text = ((int)score + garbage).ToString();

        plasticCount = plastic;
        cpCount = cp;
        canCount = can;
        paperCount = paper;
        bagCount = bag;
        leavesCount = leaves;

        if (plastic == 0)
        {
            plasticB.gameObject.SetActive(false);
        }
        if (can == 0)
        {
            canB.gameObject.SetActive(false);
        }
        if (cp == 0)
        {
            cpB.gameObject.SetActive(false);
        }
        if (bag == 0)
        {
            bagB.gameObject.SetActive(false);
        }
        if (paper == 0)
        {
            paperB.gameObject.SetActive(false);
        }
        if (leaves == 0)
        {
            leavesB.gameObject.SetActive(false);
        }

    }

    private void ToggleAdventure()
    {
        scoreTextTMP.text = "Hello";
    }

    public void addScore()
    {
        newScore++;
               
        if (ItemDragHandler.itemName == "Bottle Button")
        {        
            plasticCount--;
            plasticText.text = plasticCount.ToString();
            if (plasticCount <= 0)
            {
                plasticB.gameObject.SetActive(false);         
            }
        }
        if (ItemDragHandler.itemName == "CanButton")
        {
            canCount--;
            Debug.Log(ItemDragHandler.itemName);
            if (canCount <= 0)
            {
                canB.gameObject.SetActive(false);
            }
        }
        if (ItemDragHandler.itemName == "CP Button")
        {
            cpCount--;

            if (cpCount <= 0)
            {
                cpB.gameObject.SetActive(false);
            }
        }
        if (ItemDragHandler.itemName == "Bag Button")
        {
            bagCount--;

            if (bagCount <= 0)
            {
                bagB.gameObject.SetActive(false);
            }
        }
        if (ItemDragHandler.itemName == "Paper Button")
        {        
            paperCount--;
            
            if (paperCount <= 0)
            {
                paperB.gameObject.SetActive(false);         
            }
        }
        if (ItemDragHandler.itemName == "Leaves Button")
        {
            leavesCount--;

            if (leavesCount <= 0)
            {
                leavesB.gameObject.SetActive(false);
            }
        }
    }

    public void nextScore()
    {
        nextObj.SetActive(true);
        prevObj.SetActive(false);
    }

    public void MenuScene()
    {
        GameManager.Instance.SaveData();
        SceneManager.LoadScene("Menu");
    }

    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        highScore = data.highscore;
    }
}
