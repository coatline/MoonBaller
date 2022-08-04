using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {

	void Start () {
        transform.position = new Vector2(Random.Range(-6, 6), Random.Range(-1, 0));
	}
	
}
