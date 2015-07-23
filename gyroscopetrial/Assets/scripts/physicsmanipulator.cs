using UnityEngine;
using System.Collections;

public class physicsmanipulator : MonoBehaviour {
	/*this script is used to manipulate the physics of the boards during swing*/ 
	//
	//
	//declarations for all the required gameobjects for this script
	public GameObject firstboard;//"connecto" board object
	public GameObject secondboard;//"play" board object
	public GameObject thirdboard;//"collection" board object
	//end of gameobject declarations
	//
	//declaration of variables needed in this script
	float timer;//variable used to time the physics manipulations
	bool manipulateonce;//boolean for first manipulation
	bool manipulateoncesecondboard;//boolean for second manipulation
	//end of variable declaration
	//
	// Use this for initialization
	void Start () {
		//variable initialization
		manipulateoncesecondboard = false;
		manipulateonce = false;
		timer = 0f;
		//end variable initialization
	}
	
	// Update is called once per frame
	void Update () {
		//syncronize time with real world (seconds)
		timer += Time.deltaTime;
		//end syncroniztion
		//
		//block for first physics manipulation
		//check when to manipulate physics for the first time
		if(timer>3.3f&&!manipulateonce){
			manipulateonce=true;
			//manipulate physics now
			firstboard.rigidbody.constraints=RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
			firstboard.rigidbody.freezeRotation=true;
			secondboard.rigidbody.freezeRotation=true;
			thirdboard.rigidbody.freezeRotation=true;
		}
		//end of block for first physics manipulation
		//
		//
		//block for second physics manipulation
		//check when to manipulate physics for the second time
		if(timer>9.03f&&!manipulateoncesecondboard){
			//manipulate physics now
			manipulateoncesecondboard=true;
			secondboard.rigidbody.constraints=RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
				secondboard.rigidbody.freezeRotation=true;
			thirdboard.rigidbody.constraints=RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
			thirdboard.rigidbody.freezeRotation=true;
		}
		//end of second physics manipulation block
	}
}
