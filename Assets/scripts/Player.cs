using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private static float MOVE_POWER;
	private static float ROTATE_POWER;
	private static float JUMP_POWER;


	// attributes
	private float movePower;
	private float rotPower;
	private float jumpPower;
	private int jumpCount;

	private bool gameOver;

	// Start is called before the first frame update
	void Start()
    {
		MOVE_POWER		= 5f;
		ROTATE_POWER	= 10f;
		JUMP_POWER		= 7f;

		movePower	= MOVE_POWER;
		rotPower	= ROTATE_POWER;
		jumpPower	= JUMP_POWER;

		gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (gameOver == false)
		{
			Move();
			Jump();
		}
    }

    private void Move()
    {
        Vector3 movePos = Vector3.zero;
        Vector3 forward = new Vector3(0f, 0f, 1f);
        Vector3 backward = -forward;
        Vector3 right = new Vector3(1f, 0f, 0f);
        Vector3 left = -right;

		if (Input.GetAxisRaw("Vertical") > 0)
		{
			movePos = forward;
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 0, 0), rotPower * Time.deltaTime);
		}
		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			movePos = right;
			gameObject.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 90, 0), rotPower * Time.deltaTime);
		}
		if (Input.GetAxisRaw("Vertical") < 0)
		{
			movePos = backward;
			gameObject.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 180, 0), rotPower * Time.deltaTime);
		}
		if (Input.GetAxisRaw("Horizontal") < 0)
		{
			movePos = left;
			gameObject.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 270, 0), rotPower * Time.deltaTime);
		}
		if (Input.GetAxisRaw("Vertical") > 0 && Input.GetAxisRaw("Horizontal") > 0)
		{
			movePos = forward + right;
			gameObject.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 45, 0), rotPower * Time.deltaTime);
		}
		if (Input.GetAxisRaw("Vertical") < 0 && Input.GetAxisRaw("Horizontal") > 0)
		{
			movePos = backward + right;
			gameObject.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 135, 0), rotPower * Time.deltaTime);
		}
		if (Input.GetAxisRaw("Vertical") < 0 && Input.GetAxisRaw("Horizontal") < 0)
		{
			movePos = backward + left;
			gameObject.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 225, 0), rotPower * Time.deltaTime);
		}
		if (Input.GetAxisRaw("Vertical") > 0 && Input.GetAxisRaw("Horizontal") < 0)
		{
			movePos = forward + left;
			gameObject.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 315, 0), rotPower * Time.deltaTime);
		}
		movePos.y = 0f;
		movePos = movePos.normalized;
		this.transform.position += movePos * movePower * Time.deltaTime;
	}

	private void Jump()
	{
		if(this.GetComponent<Rigidbody>().velocity == new Vector3(0f, 0f, 0f)) { jumpCount = 1; }
		if (jumpCount <= 0) return;
		if (Input.GetButtonDown("Jump"))
		{
			this.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
			jumpCount -= 1;
		}
	}

	public void SetGameOver(bool _bool)
	{
		gameOver = _bool;
	}

	public void OnTriggerEnter(Collider obj)
	{
		
	}
}
