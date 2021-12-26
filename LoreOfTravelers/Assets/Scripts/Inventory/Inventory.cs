using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject player;
    [Header("StatValuesInventory")]
    public Text availableExpOrb;
 
    public Text healthValue;
    public Text staminaValue;
    public Text charismaValue;
    public Text magicValue;
    public Text pAtkValue;
    public Text mAtkValue;
    public Text cAtkValue;
    public Text sAtkValue;
    public Text pDefValue;
    public Text mDefValue;
    public Text cDefValue;
    public Text sDefValue;
    public Text speedValue;
    public Text accuracyValue;
    public Text reflexValue;
    public Text evasivenessValue;

    int healthCurrentValue;
    int staminaCurrentValue;
    int charismaCurrentValue;
    int magicCurrentValue;
    int pAtkCurrentValue;
    int mAtkCurrentValue;
    int cAtkCurrentValue;
    int sAtkCurrentValue;
    int pDefCurrentValue;
    int mDefCurrentValue;
    int cDefCurrentValue;
    int sDefCurrentValue;
    int speedCurrentValue;
    int accuracyCurrentValue;
    int reflexCurrentValue;
    int evasivenessCurrentValue;

    public ClassInventoryManager cim; 

    //public GameObject juggernaut;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitializeInventory()
    {
        cim.UnsetClassInventory();
        setStatValuesInventory();
        setAvailableExpOrbInventory();
        cim.SetArmorInventory();


        //NO
        availableExpOrb.text = this.player.GetComponent<PartyResources>().countExperienceOrb.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void setStatValuesInventory()
    {
        PlayerStats ps = player.GetComponent<PartyMemberManager>().activeCFP.playerStats;

        healthValue.text = ps.health.initValue.ToString();
        magicValue.text = ps.magic.initValue.ToString();
        staminaValue.text = ps.stamina.initValue.ToString();
        charismaValue.text = ps.charisma.initValue.ToString();
        pAtkValue.text = ps.pAtk.initValue.ToString();
        pDefValue.text = ps.pDef.initValue.ToString();
        mAtkValue.text = ps.mAtk.initValue.ToString();
        mDefValue.text = ps.mDef.initValue.ToString();
        cAtkValue.text = ps.cAtk.initValue.ToString();
        cDefValue.text = ps.cDef.initValue.ToString();
        sAtkValue.text = ps.sAtk.initValue.ToString();
        sDefValue.text = ps.sDef.initValue.ToString();
        speedValue.text = ps.speed.initValue.ToString();
        accuracyValue.text = ps.accuracy.initValue.ToString();
        reflexValue.text = ps.reflex.initValue.ToString();
        evasivenessValue.text = ps.evasiveness.initValue.ToString();
    }

    public void setAvailableExpOrbInventory()
    {
        player = GameObject.FindWithTag("Player");

        availableExpOrb.text = player.GetComponent<PartyResources>().countExperienceOrb.ToString();
    }

    public void OnClickStatChangeButton(string buttonId)
    {
        PlayerStats ps = player.GetComponent<PartyMemberManager>().activeCFP.playerStats;
        PartyResources pr = player.GetComponent<PartyResources>();

        string[] buttonKey = buttonId.Split('_');
   
        switch (buttonKey[0])
        {               
            case "1":
                if (buttonKey[1] != "1" && ps.health.baseInitValue < ps.health.initValue)
                {
                    ps.health.initValue--;
                    healthValue.text = (ps.health.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(healthValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    healthValue.text = temp.ToString();
                    ps.health.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "2":
                if (buttonKey[1] != "1" && ps.stamina.baseInitValue < ps.stamina.initValue)
                {
                    ps.stamina.initValue--;
                    staminaValue.text = (ps.stamina.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if (buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(staminaValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    staminaValue.text = temp.ToString();
                    ps.stamina.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "3":
                if (buttonKey[1] != "1" && ps.charisma.baseInitValue < ps.charisma.initValue)
                {
                    ps.charisma.initValue--;
                    charismaValue.text = (ps.charisma.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(charismaValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    charismaValue.text = temp.ToString();
                    ps.charisma.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "4":
                if (buttonKey[1] != "1" && ps.magic.baseInitValue < ps.magic.initValue)
                {
                    ps.magic.initValue--;
                    magicValue.text = (ps.magic.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {                        
                    int.TryParse(magicValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    magicValue.text = temp.ToString();
                    ps.magic.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "5":
                if (buttonKey[1] != "1" && ps.pAtk.baseInitValue < ps.pAtk.initValue)
                {
                    ps.pAtk.initValue--;
                    pAtkValue.text = (ps.pAtk.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(pAtkValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    pAtkValue.text = temp.ToString();
                    ps.pAtk.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "6":
                if (buttonKey[1] != "1" && ps.mAtk.baseInitValue < ps.mAtk.initValue)
                {
                    ps.mAtk.initValue--;
                    mAtkValue.text = (ps.mAtk.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(mAtkValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    mAtkValue.text = temp.ToString();
                    ps.mAtk.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "7":
                if (buttonKey[1] != "1" && ps.cAtk.baseInitValue < ps.cAtk.initValue)
                {
                    ps.cAtk.initValue--;
                    cAtkValue.text = (ps.cAtk.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(cAtkValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    cAtkValue.text = temp.ToString();
                    ps.cAtk.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "8":
                if (buttonKey[1] != "1" && ps.sAtk.baseInitValue < ps.sAtk.initValue)
                {
                    ps.sAtk.initValue--;
                    sAtkValue.text = (ps.sAtk.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {                        
                    int.TryParse(sAtkValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    sAtkValue.text = temp.ToString();
                    ps.sAtk.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "9":
                if (buttonKey[1] != "1" && ps.pDef.baseInitValue < ps.pDef.initValue)
                {
                    ps.pDef.initValue--;
                    pDefValue.text = (ps.pDef.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(pDefValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    pDefValue.text = temp.ToString();
                    ps.pDef.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "10":
                if (buttonKey[1] != "1" && ps.mDef.baseInitValue < ps.mDef.initValue)
                {
                    ps.mDef.initValue--;
                    mDefValue.text = (ps.mDef.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(mDefValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    mDefValue.text = temp.ToString();
                    ps.mDef.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "11":
                if (buttonKey[1] != "1" && ps.cDef.baseInitValue < ps.cDef.initValue)
                {
                    ps.cDef.initValue--;
                    cDefValue.text = (ps.cDef.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(cDefValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    cDefValue.text = temp.ToString();
                    ps.cDef.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "12":
                if (buttonKey[1] != "1" && ps.sDef.baseInitValue < ps.sDef.initValue)
                {
                    ps.sDef.initValue--;
                    sDefValue.text = (ps.sDef.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(sDefValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    sDefValue.text = temp.ToString();
                    ps.sDef.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "13":
                if (buttonKey[1] != "1" && ps.accuracy.baseInitValue < ps.accuracy.initValue)
                {
                    ps.accuracy.initValue--;
                    accuracyValue.text = (ps.accuracy.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(accuracyValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    accuracyValue.text = temp.ToString();
                    ps.accuracy.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "14":
                if (buttonKey[1] != "1" && ps.speed.baseInitValue < ps.speed.initValue)
                {
                    ps.speed.initValue--;
                    speedValue.text = (ps.speed.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(speedValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    speedValue.text = temp.ToString();
                    ps.speed.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "15":
                if (buttonKey[1] != "1" && ps.reflex.baseInitValue < ps.reflex.initValue)
                {
                    ps.reflex.initValue--;
                    reflexValue.text = (ps.reflex.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(reflexValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    reflexValue.text = temp.ToString();
                    ps.reflex.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
            case "16":
                if (buttonKey[1] != "1" && ps.evasiveness.baseInitValue < ps.evasiveness.initValue)
                {
                    ps.evasiveness.initValue--;
                    evasivenessValue.text = (ps.evasiveness.initValue).ToString();
                    pr.countExperienceOrb++;
                    setAvailableExpOrbInventory();
                }
                else if(buttonKey[1] == "1" && pr.countExperienceOrb > 0)
                {
                    int.TryParse(evasivenessValue.text, out int temp);
                    temp++;
                    pr.countExperienceOrb--;
                    evasivenessValue.text = temp.ToString();
                    ps.evasiveness.initValue = temp;
                    setAvailableExpOrbInventory();
                }
                break;
        }        
    }

    public void OnClickFistWeapon()
    {
        player.GetComponent<PartyMemberManager>().activeCFP.emptyHanded = true;   

        player = GameObject.FindWithTag("Player");
        if (!player.GetComponent<PlayerInputManager>().isAttacking && !player.GetComponent<PlayerInputManager>().animatingStop)
        {
            player.GetComponent<PartyMemberManager>().activeCFP.SetBareHanded();
        }
        InitializeInventory();
    }
}
