using UnityEngine;
using System.Collections;

public class dampscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other){
		other.gameObject.rigidbody.drag = 1.5f;
	}
}
