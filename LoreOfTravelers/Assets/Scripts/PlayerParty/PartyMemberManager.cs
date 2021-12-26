using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMemberManager : MonoBehaviour
{
    public List<CharacterFigurePiece> partyCFP;
    public CharacterFigurePiece activeCFP;

    int activeCFPindex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCurrentPartySize()
    {
        int currentPartySize = 0;

        foreach (var item in partyCFP)
        {
            if (item != null)
            {
                currentPartySize++;
            }
        }
        return currentPartySize;
    }

    public RuntimeAnimatorController ChangePartyMemberAnimator(int index)
    {
        int tempACFPI = activeCFPindex;
        activeCFPindex += index;

        int currentPartySize = GetCurrentPartySize();

        if (activeCFPindex<0)
        {
            activeCFPindex = currentPartySize - 1;
        }
        if (activeCFPindex == currentPartySize)
        {
            activeCFPindex = 0;
        }

        CharacterFigurePiece cfp = activeCFP;
        if (partyCFP[activeCFPindex] != null)
        {
            activeCFP = partyCFP[activeCFPindex];
            return partyCFP[activeCFPindex].characterAnimator;
        }
        else
        {
            return cfp.characterAnimator;
        }
    }

    public void MetPartyMember(CharacterFigurePiece cfp)
    {
        cfp.SetBareHanded();
        SetPartyCFP(cfp);
    }

    public void SetPartyCFP(CharacterFigurePiece cfp)
    {
        for (int i = 0; i < partyCFP.Count; i++)
        {
            if (partyCFP[i] == null)
            {
                partyCFP[i] = cfp;
                break;
            }
        }
    }

    public RuntimeAnimatorController SetAnimatorMovement()
    {
        return activeCFP.characterAnimator;
    }

    public CharacterFigurePiece GetActiveCFP()
    {
        return activeCFP;
    }
}
