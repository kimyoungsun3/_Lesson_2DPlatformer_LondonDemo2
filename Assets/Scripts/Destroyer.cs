using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
	public enum DestroyType { 
		None,
		MyDestoryDelay, 
		ChildDestroyDelay,
		MyDestoryImmeidate, 
		ChildDestroyImmeidate
	};

	public DestroyType type = DestroyType.MyDestoryDelay;
	public float delayTime;
	public string strChildName;

	void Awake () {
		switch(type) 
		{
		case DestroyType.None:
			break;
		case DestroyType.MyDestoryDelay:
			Destroy (gameObject, delayTime);
			break;
		case DestroyType.ChildDestroyDelay:
			Destroy(transform.Find(strChildName).gameObject, delayTime);
			break;
		case DestroyType.MyDestoryImmeidate:
			DestroyImmediate (gameObject);
			break;
		case DestroyType.ChildDestroyImmeidate:
			DestroyImmediate(transform.Find(strChildName).gameObject);
			break;
		}
	}

	void DestroyGameObject()
	{
		Destroy (gameObject);
	}

	void DestroyChildGameObject()
	{
		if(transform.Find(strChildName).gameObject != null){
			Destroy(transform.Find(strChildName).gameObject);
		}
	}


	void DisableChildGameObject()
	{
		if(transform.Find(strChildName).gameObject.activeSelf == true ){
			transform.Find(strChildName).gameObject.SetActive(false);
		}
	}
}
