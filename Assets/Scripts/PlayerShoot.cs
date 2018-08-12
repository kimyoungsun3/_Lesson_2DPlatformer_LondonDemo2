using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public Rigidbody2D rocket;
	public float speed = 20f;
	public AudioSource audio;
	public Transform point;

	private Animator animator;


	public void SetInit(Animator _ani){
		animator = _ani;
	}

	public void Shoot(bool _face){
		animator.SetTrigger ("Shoot");
		audio.Play ();
		Rigidbody2D _bullet = Instantiate (rocket, point.position, point.rotation) as Rigidbody2D;

		if (_face) {
			_bullet.velocity = new Vector2 (speed, 0);
		} else {
			_bullet.velocity = new Vector2 (-speed, 0);
		}
	}

}
