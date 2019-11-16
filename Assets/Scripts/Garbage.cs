using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public static Garbage Instance { get; set; }

    
    
    void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("PickSound");

            gameObject.SetActive(false);

            GameManager.Instance.GetGarbage();
            if (gameObject.tag == "NonBio")
            {               
                if(gameObject.name == "Plastic")
                {
                    GameManager.Instance.plasticCounter++;
                   // QuestManager.Instance.QuestCounter();
                   // Debug.Log("ww");
                }
                else if(gameObject.name == "Can")
                {
                    GameManager.Instance.canCounter++;
                }
                else if(gameObject.name == "Cellphone")
                {
                    GameManager.Instance.cpCounter++;
                }
            }
            if (gameObject.tag == "Bio")
            {
                if (gameObject.name == "Paper")
                {
                    GameManager.Instance.paperCounter++;
                }
                else if (gameObject.name == "Paper Bag")
                {
                    GameManager.Instance.bagCounter++;

                    
                }
                else if (gameObject.name == "Plant")
                {
                    GameManager.Instance.plantCounter++;
                    Debug.Log("Count");
                }
            }
        }
    }
}
