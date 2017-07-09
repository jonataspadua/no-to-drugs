using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	public Material globo;

	void Update () {
		transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
		if (globo.color == Color.blue) {
			globo.color = Color.red;
		} else if (globo.color == Color.red) {
			globo.color = Color.black;
		} else if (globo.color == Color.blue) {
			globo.color = Color.blue;
		}
	}
}
