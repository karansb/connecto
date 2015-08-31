using UnityEngine;
using System.Collections;

public class resizeelementsforgamescreen : MonoBehaviour {
	GameObject temp;//use this gameobject to reference the ones to be resized
	float calculateratio;//variable used to calculate the screen ratio
	public float scalefactor;//variable used to fix object size based on screenratio
	// Use this for initialization
	void Start () {
		//resizing the stone board
		temp=GameObject.Find ("gameboard");
		calculateratio = (float)Screen.width / (float)Screen.height;
		temp.transform.localScale = new Vector3 (calculateratio*scalefactor,calculateratio*scalefactor,temp.transform.localScale.z);
		//end of resizing the stone board
	}

}
