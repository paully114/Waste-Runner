using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowNextChar : MonoBehaviour
{
    public GameObject[] listOfChar;

    public static int indexChar = 0;

    private bool secChar = false;
    private bool thirdChar = false;

    public Button runButton, buyButton;

    //Character Buy
    private string unlock = "Unlock";
    public TextMeshProUGUI textPrice;
    private float sumoCharCost = 2;
    private float astroCharCoast = 300;

    void Start()
    {
        LoadData();
        checkIfUnlock();
        Debug.Log(secChar.ToString() + thirdChar.ToString());
    }

    void Update()
    {
        checkIfUnlock();
    }

    void checkIfUnlock()
    {
        if (indexChar == 0)
        {
            runButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);

            textPrice.text = unlock;
        }
        if (indexChar == 1)
        {
            if (secChar)
            {
                runButton.gameObject.SetActive(true);
                buyButton.gameObject.SetActive(false);
                textPrice.text = unlock;
            }
            else
            {
                runButton.gameObject.SetActive(false);
                buyButton.gameObject.SetActive(true);

                textPrice.text = sumoCharCost.ToString();
            }
        }

        if (indexChar == 2)
        {
            if (thirdChar)
            {
                runButton.gameObject.SetActive(true);
                buyButton.gameObject.SetActive(false);
                textPrice.text = unlock;
            }
            else
            {
                runButton.gameObject.SetActive(false);
                buyButton.gameObject.SetActive(true);
                textPrice.text = astroCharCoast.ToString();
            }
        }
    }

    public void clickNext()
    {
         switch (indexChar)
         {
            case 0:
                listOfChar[0].SetActive(false);
                listOfChar[1].SetActive(true);
                indexChar = 1;
                checkIfUnlock();
                break;
            case 1:
                listOfChar[1].SetActive(false);
                listOfChar[2].SetActive(true);
                indexChar = 2;
                checkIfUnlock();
                break;
            case 2:
                listOfChar[2].SetActive(false);
                listOfChar[0].SetActive(true);
                indexChar = 0;
                checkIfUnlock();
                break;
         }
       
    }

    public void clickPrev()
    {
        switch (indexChar)
        {
            case 0:
                listOfChar[0].SetActive(false);
                listOfChar[2].SetActive(true);
                indexChar = 2;
                checkIfUnlock();
                break;
            case 1:
                listOfChar[1].SetActive(false);
                listOfChar[0].SetActive(true);
                indexChar = 0;
                checkIfUnlock();
                break;
            case 2:
                listOfChar[2].SetActive(false);
                listOfChar[1].SetActive(true);
                indexChar = 1;
                checkIfUnlock();
                break;
        }
    }

    void LoadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        secChar = data.unlockSec;
        thirdChar = data.unlockSec;
    }
}
