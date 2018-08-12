using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickup : MonoBehaviour {
	public AudioClip pickupClip;

	private Animator animator;
	private bool bLanded = false;

	void Start () {
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D _col){
		//Debug.Log (_col.tag);
		if (_col.CompareTag ("Player")) {
			AudioSource.PlayClipAtPoint (pickupClip, transform.position);

			LayBombs _scp = _col.GetComponent<LayBombs> ();
			if (_scp != null) {
				_scp.bombCount++;
			}

			Destroy (gameObject);
		} else if (_col.CompareTag ("ground") && !bLanded) {
			bLanded = true;
			animator.SetTrigger ("Land");
		}
	}
}
