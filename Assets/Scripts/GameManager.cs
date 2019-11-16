using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const int COIN_SCORE_AMOUNT = 5;

    public static GameManager Instance { set; get; }

    public bool isGameStarted = false;
    
    public bool IsDead { get; set; }
    private PlayerMotor motor;
    public float totalCoin;
    public int gamemode;
    public float starCounter;

    // UI and the UI fields
    public TextMeshProUGUI scoreText, coinText, modifierText, garbageText;
    public float score, coinScore = 0, modifierScore, garbageScore, lastGold;
    public float lastScore, lastHScore, lastStar;

    public GameObject player,tileManager;

    //Item
    public float plasticCounter, canCounter, paperCounter, bagCounter, cpCounter,
        plantCounter;

    //Skill
    public static int coinMultiplier;

    //Stage
    public float s1, s2, s3, s4, s5, s6, xs3;

    private void Awake()
    {
        Instance = this;
        modifierScore = 1;
        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();

        modifierText.text = "x" + modifierScore.ToString("0.0");
        coinText.text = coinScore.ToString("0");
        scoreText.text = scoreText.text = score.ToString("0");
        garbageText.text = garbageScore.ToString("0");

        player = GameObject.FindGameObjectWithTag("Player");
        tileManager = GameObject.Find("TileManager");
        player.SetActive(true);
        tileManager.SetActive(true);

    }
    private void Update()
    {
        if(MobileInput.Instance.Tap && !isGameStarted)
        {
            isGameStarted = true;
            motor.isRun = true;
        }

        if (isGameStarted && !IsDead)
        {
            // Bump the score
            lastScore = (int)score;
            if (!PlayerSkill.usingSpell && PlayerSkill.skillType == 2)
            {
                score += (Time.deltaTime * modifierScore);
            }
            else
            {
                score += ((Time.deltaTime * 2) * modifierScore);
            }
            if (lastScore != (int)score)
            {
                lastScore = (int)score;
                scoreText.text = score.ToString("0");
            }
        }
        
        if (IsDead)
        {
            //gamemode = 2;
            Debug.Log(gamemode);
            if (gamemode == 1)
            {
                DeadMenu.Instance.ToggleEndMenu(score, garbageScore, coinScore, plasticCounter, canCounter, cpCounter,
                    bagCounter, paperCounter, plantCounter);
            }
            if (gamemode == 2)
            {
                DeadQuest.Instance.ToggleThis(score, garbageScore);
            }
        }

        
    }

    public void GetCoin()
    {
        if(PlayerSkill.usingSpell && PlayerSkill.skillType == 0 )
        {
            coinScore += 2;
            coinText.text = coinScore.ToString();
            score += COIN_SCORE_AMOUNT;
            scoreText.text = scoreText.text = score.ToString("0");
        }
        if (!PlayerSkill.usingSpell || PlayerSkill.skillType != 0)
        {
            coinScore++;
            coinText.text = coinScore.ToString();
            score += COIN_SCORE_AMOUNT;
            scoreText.text = scoreText.text = score.ToString("0");
        }
        
    }

    public void GetGarbage()
    {
        garbageScore++;
        garbageText.text = garbageScore.ToString("0");

        if (gamemode == 2)
        {
            QuestManager.Instance.QuestCounter();
        }
    }

    public void UpdateModifier(float modifierAmount)
    {
        modifierScore = 1.0f + modifierAmount;
        modifierText.text = "x" + modifierScore.ToString("0.0");
    }

    public void GameRestart()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);

        SaveData();
    }

    public void SaveData()
    {
        
        if (gamemode == 1)
        {
            if (DeadMenu.Instance.newScore < lastHScore)
            {
                PlayerPrefs.SetFloat("score", DeadMenu.Instance.newScore);
                Debug.Log("highscore is " + PlayerPrefs.GetFloat("score") + " score is " + DeadMenu.Instance.newScore);
            }
        }
        if (gamemode == 2)
        {

        }


    }

    public void LoadData()
    {

        lastGold = PlayerPrefs.GetFloat("gold") ;
        lastHScore = PlayerPrefs.GetFloat("score");
        lastStar = PlayerPrefs.GetFloat("star");

        s1 = PlayerPrefs.GetFloat("s1");
        s2 = PlayerPrefs.GetFloat("s2");
        s3 = PlayerPrefs.GetFloat("s3");
        s4 = PlayerPrefs.GetFloat("s4");
        s5 = PlayerPrefs.GetFloat("s5");
        s6 = PlayerPrefs.GetFloat("s6");  

        Debug.Log("Stageg 3 is " + xs3);
    }
}
