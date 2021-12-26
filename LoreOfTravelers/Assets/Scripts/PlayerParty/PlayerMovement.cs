using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public bool isMoving = false;
	public Rigidbody2D playerRB;
	public float currentSpeed = 5f;
	public float speed = 5f;

	public Vector2 moveDir;
	public Vector2 directionFaced;

	public bool onDifficultTerrain = false;
	public bool isRunning = false;
	public bool isExhausted = false;


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public Vector2 HandleMovementInput(Vector2 moveDirX, Transform attackPosition)
	{
		moveDir = moveDirX;
		SpriteRenderer sr = GetComponent<SpriteRenderer>();

		float yAdjuster = sr.sprite.bounds.size.y * 0.5f;

		if (moveDir.x != 0 || moveDir.y != 0)
		{
			isMoving = true;
			directionFaced = moveDir;
			if (moveDir.x == 0 && moveDir.y == -1)
			{
                attackPosition.position = new Vector2(gameObject.transform.position.x, (gameObject.transform.position.y - 1) +.75f);
            }
			if (moveDir.x == 0 && moveDir.y == 1)
			{
                attackPosition.position = new Vector2(gameObject.transform.position.x, (gameObject.transform.position.y + 0.75f) + .75f);
            }
			if (moveDir.x == -1 && moveDir.y == 0)
			{
                attackPosition.position = new Vector2((gameObject.transform.position.x - 1), gameObject.transform.position.y + .75f);
            }
			if (moveDir.x == 1 && moveDir.y == 0)
			{
                attackPosition.position = new Vector2((gameObject.transform.position.x + 1), gameObject.transform.position.y + .75f);

            }
			if (moveDir.x > 0 && moveDir.y > 0)
			{
                attackPosition.position = new Vector2((gameObject.transform.position.x + 0.75f), (gameObject.transform.position.y + 0.75f) + yAdjuster);
            }
			if (moveDir.x > 0 && moveDir.y < 0)
			{
                attackPosition.position = new Vector2((gameObject.transform.position.x + 0.75f), (gameObject.transform.position.y - 0.75f) + yAdjuster);
            }
			if (moveDir.x < 0 && moveDir.y < 0)
			{
                attackPosition.position = new Vector2((gameObject.transform.position.x - 0.75f), (gameObject.transform.position.y - 0.75f) + yAdjuster);
            }
			if (moveDir.x < 0 && moveDir.y > 0)
			{
                attackPosition.position = new Vector2((gameObject.transform.position.x - 0.75f), (gameObject.transform.position.y + 0.75f) + yAdjuster);
            }
		}
		else
		{
			isMoving = false;
		}
		return directionFaced;
	}

	void FixedUpdate()
	{
		HandleMovementPhysics();
	}

	void HandleMovementPhysics()
	{
		if (GetComponent<PlayerInputManager>().canMove)
		{
			playerRB.MovePosition(playerRB.position + moveDir.normalized * currentSpeed * Time.fixedDeltaTime);
		}
	}

	public void HandleSpeed()
    {
        if (onDifficultTerrain)
        {
			currentSpeed = speed * 0.25f;
			if (isRunning)
			{
				currentSpeed = speed * .5f;
				if (isExhausted)
				{
					currentSpeed = speed * .125f/2;
				}
			}
            if (isExhausted)
            {
				currentSpeed = speed * .125f;
            }
		}
        else
		{
			currentSpeed = speed;
			if (isRunning)
			{
				currentSpeed = speed * 2;
				if (isExhausted)
				{
					currentSpeed = speed * .25f;
				}
			}
			if (isExhausted)
			{
				currentSpeed = speed * .5f;
			}
		}
    }
}
