using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI goldAmountText;
    public float goldAmount, highscore;
    public Text highScore;

    public GameObject mainMenu, modeMenu, advMode;

    public int gameMode;

    //Character Buy
    private string unlock = "Unlock";

    private float sumoCharCost = 2;
    private float astroCharCoast = 300;
    public Button buyButton;

    public bool unlock2nd;
    public bool unlock3rd;

    //Character
    public bool unlockSecond;
    public bool unlockThird;

    void Awake()
    {
        //GameManager.Instance.SaveData();
    }

    void Start()
    {
        highscore = PlayerPrefs.GetFloat("hScore");

        highScore.text = highscore.ToString("0");
    }


    public void loadSceneTimeTrial()
    {
      SceneManager.LoadScene("TimeTrial");
    }
  

    public void LoadMenu()
    {
        PlayerData data = SaveSystem.LoadPlayer();
      
        highScore.text = ((int)data.highscore).ToString();
        goldAmountText.text = ((int)data.gold).ToString();
    }
    public void timeTrialMode()
    {
        GameManager.Instance.gamemode = 1;
        mainMenu.SetActive(false);
        modeMenu.SetActive(true);

        LoadMenu();
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void adventureMode()
    {
        advMode.SetActive(true);
        modeMenu.SetActive(false);

        GameManager.Instance.gamemode = 2;
    }

    public void Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Stage3()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void Stage4()
    {
        SceneManager.LoadScene("Stage4");
    }
    public void Stage5()
    {
        SceneManager.LoadScene("Stage5");
    }
    public void Stage6()
    {
        SceneManager.LoadScene("Stage6");
    }
}
