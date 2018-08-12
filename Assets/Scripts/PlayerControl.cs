using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	[HideInInspector] public bool bJump = false;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public AudioClip[] jumpClips;
	public float jumpForce = 1000f;
	public AudioClip[] taunts;
	public float tauntProbability = 50f;
	public float tauntDelay = 1f;

	private bool facingRight = true;
	private int tauntIndex;
	private Animator animator;
	public Transform transGroundCheck;
	public LayerMask groundMask;
	private bool bGrounded = false;
	private Transform trans;
	private Rigidbody2D rb2d;
	private PlayerShoot playerShoot;

	void Start () 
	{
		trans 		= transform;
		animator 	= GetComponent<Animator> ();
		rb2d 		= GetComponent<Rigidbody2D> ();
		playerShoot	= GetComponent<PlayerShoot> ();
		playerShoot.SetInit (animator);
		//Debug.Log (bJump);
	}
	
	// Update is called once per frame
	void Update () 
	{
		bGrounded = Physics2D.Linecast (trans.position, transGroundCheck.position, groundMask);
		if ( bGrounded && Input.GetButtonDown ("Jump") ) 
		{
			bJump = true;
		}

		if (Input.GetButtonDown ("Fire1")) {
			playerShoot.Shoot (facingRight);
		}
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		animator.SetFloat ("Speed", Mathf.Abs (h));

		//move
		if (h * rb2d.velocity.x < maxSpeed) {
			rb2d.AddForce (Vector2.right * h * moveForce);
		}

		Vector2 _v = rb2d.velocity;
		if (Mathf.Abs (_v.x) > maxSpeed) {			
			rb2d.velocity = new Vector2 (Mathf.Sign (_v.x) * maxSpeed, _v.y);
		}

		//faceing
		if (h > 0 && !facingRight) {
			Flip ();
		} else if (h < 0 && facingRight) {
			Flip ();
		}

		//jump
		if (bJump) {
			animator.SetTrigger ("Jump");
			int _r = Random.Range(0, jumpClips.Length);
			AudioSource.PlayClipAtPoint (jumpClips [_r], trans.position);

			rb2d.AddForce (Vector2.up * jumpForce);

			bJump = false;
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 _scale = trans.localScale;
		_scale.x *= -1;
		trans.localScale = _scale;
	}
}
