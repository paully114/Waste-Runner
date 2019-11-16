using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSkill : MonoBehaviour
{
    public static PlayerSkill Instace { get; set; }

    public static int skillType;

    private float skillTime = 10f;
    private float skillCooldown = 6f;

    //public bool canSkill = false;
    //public bool useSkill = false;

    public bool spellIsReady;
    public static bool usingSpell;

    public Button skill;
    public TextMeshProUGUI skillDuration;

    void Start()
    {
        //skill = GameObject.Find("SkillButton").GetComponent<Button>();
        spellIsReady = true;
        usingSpell = false;

        skillType = ShowNextChar.indexChar;
        Debug.Log("Your skill is " + skillType.ToString());
    }

    void Update()
    {
       if(usingSpell)
        {
            skillTime -= Time.deltaTime;
            skillDuration.text = ((int)skillTime).ToString();
            if(skillTime <= 0)
            {
                skillDuration.text = "Not Ready";
            }
        }
    }

    public void ClickSpell()
    {
        //if (skillType == 0)
        {
            if (spellIsReady & !usingSpell)
            {
                Debug.Log("Using Spell");
                usingSpell = true;
                spellIsReady = false;
                StartCoroutine("UsingSpell");
                skill.interactable = false;
                skillTime = 10f;

            }
        }     
    }
    public IEnumerator UsingSpell()
    {
        yield return new WaitForSeconds(10);
        usingSpell = false;
        StartCoroutine("SpellReady");
        Debug.Log("1 Car");
    }

    public IEnumerator SpellReady()
    {
        yield return new WaitForSeconds(20);
        Debug.Log("2 Car");
        spellIsReady = true;
        skill.interactable = true;
        skillDuration.text = "Ready";
    }

}
