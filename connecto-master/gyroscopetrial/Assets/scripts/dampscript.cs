using UnityEngine;
using System.Collections;

public class dampscript : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		//changes the drag off everything that collides so that the swing will stop faster
		other.gameObject.rigidbody.drag = 1.5f;
	}
}
