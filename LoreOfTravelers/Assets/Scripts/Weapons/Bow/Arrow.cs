using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
	public Vector2 flightDirection;
	public LayerMask tallObjects;
	public float speed = 3.6f;
	public Sprite leftArrow;
	public Sprite leftUpArrow;
	public Sprite leftDownArrow;
	public Sprite rightArrow;
	public Sprite rightUpArrow;
	public Sprite rightDownArrow;
	public Sprite downArrow;
	public Sprite upArrow;
	public Sprite brokenArrow;
	public Sprite upBow;
	public Sprite downBow;
	public Sprite rightBow;
	public Sprite leftBow;

	public SpriteRenderer sr;

	public Rigidbody2D rb;

	GameObject Player;

	public float distanceAdjuster = 0.1f;
	bool isBroken = false;


	// Start is called before the first frame update
	void Start()
	{
		Player = GameObject.FindWithTag("Player");
		Player.GetComponent<PartyMemberManager>().activeCFP.ChangeAmount(-1);
		if (Player.GetComponent<PartyMemberManager>().activeCFP.playerStats.stamina.currValue - 2 >= 0)
		{
			Player.GetComponent<PartyMemberManager>().activeCFP.ChangeStamina(-2);
		}

		StartCoroutine("ArrowExpiration");
	}

	// Update is called once per frame
	void Update()
	{
		rb.MovePosition(rb.position + flightDirection.normalized * speed * Time.fixedDeltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{	
		if (((1 << collision.gameObject.layer) & tallObjects) != 0)
		{
			sr.sprite = brokenArrow;
			speed = 0;
			rb.simulated = false;
			StartCoroutine("DestroyObject");
		}
	}

	IEnumerator DestroyObject()
	{
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}


	public void SetDirection(Vector2 direction)
	{
		flightDirection = direction;
		SetArrowRotation(direction);
	}

	void SetArrowRotation(Vector2 directionFaced)
	{
		if (directionFaced.x == 0 && directionFaced.y == -1)
		{
			sr.sprite = downArrow;
		}
		if (directionFaced.x == 0 && directionFaced.y == 1)
		{
			sr.sprite = upArrow;
		}
		if (directionFaced.x == -1 && directionFaced.y == 0)
		{
			sr.sprite = leftArrow;
		}
		if (directionFaced.x == 1 && directionFaced.y == 0)
		{
			sr.sprite = rightArrow;
		}
		if (directionFaced.x > 0 && directionFaced.y > 0)
		{
			sr.sprite = rightUpArrow;
		}
		if (directionFaced.x > 0 && directionFaced.y < 0)
		{
			sr.sprite = rightDownArrow;
		}
		if (directionFaced.x < 0 && directionFaced.y < 0)
		{
			sr.sprite = leftDownArrow;
		}
		if (directionFaced.x < 0 && directionFaced.y > 0)
		{
			sr.sprite = leftUpArrow;
		}
	}

	IEnumerator ArrowExpiration()
	{
		yield return new WaitForSeconds(10f);
		Destroy(this.gameObject);
	}
}
