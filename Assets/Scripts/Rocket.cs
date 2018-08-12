using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
	public GameObject prefabExplosion;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2f);
	}


	void OnExplode(){
		Quaternion _q = Quaternion.Euler (0f, 0f, Random.Range (0, 359));

		Instantiate (prefabExplosion, transform.position, _q);
	}

	void OnTriggerEnter2D(Collider2D _col){
		if (_col.CompareTag ("Enemy")) {
			Debug.Log (" > Enemy");
			_col.gameObject.GetComponent<Enemy> ().Hurt ();
			OnExplode ();
			Destroy (gameObject);
		} else if (_col.CompareTag ("BombPickup")) {
			Debug.Log (" > BombPickup");
			_col.gameObject.GetComponent<Bomb>().Explode ();
			Destroy (_col.transform.root.gameObject);
			Destroy (gameObject);
		} else if (!_col.CompareTag ("Player")) {
			Debug.Log (" > ETC");
			OnExplode ();
			Destroy (gameObject);
		}
	}
}
