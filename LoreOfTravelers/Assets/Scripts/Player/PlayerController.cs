using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D body;

	public Rigidbody2D BODY
	{
		get { return body; }
		set { body = value; }
	}

	[SerializeField]
	private float moveSpeed;

	public float MOVE_SPEED
	{
		get { return moveSpeed; }
		set { moveSpeed = value; }
	}


	// Update is called once per frame
	void Update()
    {
		body.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
	}
}
