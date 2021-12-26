using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFigurePieceIcon : MonoBehaviour
{
    //public UserInterface ui;
    public CharacterFigurePiece character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PartyMemberManager>().GetCurrentPartySize() != 3)
            {
                collision.GetComponent<PartyMemberManager>().MetPartyMember(character);
                GameObject.FindWithTag("UI").GetComponent<UserInterface>().SetMemberIcon(character.characterUIIcon);
                Destroy(gameObject);
            }            
        }
    }
}
