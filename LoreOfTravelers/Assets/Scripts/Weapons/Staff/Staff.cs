using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
	public LayerMask tallObjects;
	Vector2 directionFaced;
	public float distanceAdjuster;
	public float duration;
	Rigidbody2D player;

	GameObject Player;

    private void Start()
    {
		Player = GameObject.FindWithTag("Player");		
	}

    public void InitializeStaffAction(Vector2 direction, Rigidbody2D rb)
    {
		player = rb;
		directionFaced = direction;
		
		StartCoroutine(LerpPosition());
    }
     IEnumerator LerpPosition()
    {
		float time = 0;
        Vector2 startPosition = transform.position;
        Vector2 targetPoleVaulting = player.position + directionFaced.normalized * 2.66f*2;
		Vector2 targetPoleVaultingMid = new Vector2();

		RaycastHit2D hit = Physics2D.Raycast(startPosition,directionFaced.normalized,2.66f*2, tallObjects);

		Vector2 colliderSize = GetComponent<BoxCollider2D>().size;

		GetComponent<BoxCollider2D>().size = new Vector2(0, 0);

		if (hit.distance != 0)
		{
			targetPoleVaulting = player.position + directionFaced.normalized * (hit.distance - distanceAdjuster);
		}


		if (directionFaced.x == 0 && directionFaced.y == -1)
		{
			targetPoleVaultingMid = player.position + directionFaced.normalized * (-1f);
			//attackPosition.position = new Vector2(player.transform.position.x, player.transform.position.y - 1);
		}
		if (directionFaced.x == 0 && directionFaced.y == 1)
		{
			targetPoleVaultingMid = player.position + directionFaced.normalized * 3f;
			//attackPosition.position = new Vector2(player.transform.position.x, player.transform.position.y + 1);
		}
		if (directionFaced.x == -1 && directionFaced.y == 0)
		{
			targetPoleVaultingMid.x = player.position.x + directionFaced.normalized.x * (1.33f);
			targetPoleVaultingMid.y = player.position.y + 1.33f;
		}
		if (directionFaced.x == 1 && directionFaced.y == 0)
		{
			targetPoleVaultingMid.x = player.position.x + directionFaced.normalized.x * (1.33f);
			targetPoleVaultingMid.y = player.position.y + 1.33f;
		}
		if (directionFaced.x > 0 && directionFaced.y > 0)
		{
			targetPoleVaultingMid.y = player.position.y + directionFaced.y;
			targetPoleVaultingMid.x = player.position.x;
			//attackPosition.position = new Vector2(player.transform.position.x + 0.75f, player.transform.position.y + 0.75f);
		}
		if (directionFaced.x > 0 && directionFaced.y < 0)
		{
			targetPoleVaultingMid.x = player.position.x + directionFaced.x;
			targetPoleVaultingMid.y = player.position.y;
			//attackPosition.position = new Vector2(player.transform.position.x + 0.75f, player.transform.position.y - 0.75f);
		}
		if (directionFaced.x < 0 && directionFaced.y < 0)
		{
			targetPoleVaultingMid.x = player.position.x + directionFaced.x;
			targetPoleVaultingMid.y = player.position.y;
			//attackPosition.position = new Vector2(player.transform.position.x - 0.75f, player.transform.position.y - 0.75f);
		}
		if (directionFaced.x < 0 && directionFaced.y > 0)
		{
			targetPoleVaultingMid.y = player.position.y + directionFaced.y;
			targetPoleVaultingMid.x = player.position.x;
			//attackPosition.position = new Vector2(player.transform.position.x - 0.75f, player.transform.position.y + 0.75f);
		}

		while (time < duration)
        {
            player.transform.position = Vector2.Lerp(startPosition, targetPoleVaultingMid, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
		transform.position = targetPoleVaultingMid;
		time = 0;
        startPosition = transform.position;
        while (time < duration)
        {
            player.transform.position = Vector2.Lerp(startPosition, targetPoleVaulting, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
		Player.GetComponent<PartyMemberManager>().activeCFP.ChangeDurability(-10);
		if (Player.GetComponent<PartyMemberManager>().activeCFP.playerStats.stamina.currValue - 5 >= 0)
		{
			Player.GetComponent<PartyMemberManager>().activeCFP.ChangeStamina(-5);
		}

		transform.position = targetPoleVaulting;
        GetComponent<BoxCollider2D>().size = colliderSize;		
	}
}
