using UnityEngine;
using System.Collections;

public class camrefscript : MonoBehaviour {
	//this script is used for the gyro input including the returning effect of the camera
	// Use this for initialization
	//declarations of gameobjects required for this script
	GameObject cam;
	GameObject boardref;
	//end of gameobject declaration
	//declaration of variables required for the script
	Quaternion temprotation;//this is used to store the initial rotation of the camera
	float gyrocountdown=1.52f;//the gyro input should be enabled after 1.52 seconds
	//end of variable declaration
	void Start () {
		//initialization of variables
		Input.gyro.enabled = true;
		cam = GameObject.Find ("Main Camera");
		boardref = GameObject.Find ("boardref");
		temprotation = transform.rotation;
	//end of variable initialization
		//specific intitialization for when scene2 is loaded
		if(Application.loadedLevelName=="scene2"){
			gyrocountdown=0f;
			boardref=GameObject.Find("gameboard");
		}
		//end of specific intitialization for when scene2 is loaded
	}
	
	// Update is called once per frame
	void Update () {
		//check if it has already been 1.52 seconds
		//if yes
		if (gyrocountdown <= 0f) {
			//check if there is an input and whether the camera is supposed to return to its initial rotation
			//if no...			
			if (Mathf.Abs (Input.gyro.rotationRateUnbiased.y) < 0.5f || Vector3.Dot (boardref.transform.forward, -(cam.transform.position - transform.position).normalized) <= 0.8f) {
								transform.rotation = Quaternion.Lerp (transform.rotation, temprotation, Time.deltaTime * 2f);//code to rotate camera back to initial rotation
						} 
			//if yes...
			else {
				//check if the camera has already rotated enough when there is an input
				//if no...
								if (Vector3.Dot (boardref.transform.forward, -(cam.transform.position - transform.position).normalized) > 0.8f) {
										transform.Rotate (0f, -Input.gyro.rotationRateUnbiased.y, 0f);//code to rotate camera according to input
								}
						}
			//end of input check

				} 
		//if no
		else {
			gyrocountdown-=Time.deltaTime;//code to change timer value according to real time (seconds)		
		}
		//end of check

		}
}
