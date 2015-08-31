using UnityEngine;
using System.Collections;

public class playbuttonhandler : MonoBehaviour {
	bool allowed;//specifies when the player's touch input will be allowed
	float mytimer=1.52f;//it will be allowed after 1.52 seconds
	bool touchallowed;//this is used to allow only 1 raycast per touch (to increase performance)
	// Use this for initialization
	void Start () {
		//variable intialization
		touchallowed = false;
		allowed = false;
		//end of initialization
	}
	
	// Update is called once per frame
	void Update () {
		//check for input and cast a ray
		if(Input.touchCount==1&&allowed&&touchallowed){
			touchallowed=false;//means that ray is already casted for this input
			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit,Mathf.Infinity)&&hit.collider.gameObject==this.gameObject){
				Application.LoadLevel("scene2");//if casted ray hits this object, load scene 2
			}
		}
		//allow input and raycast when there is no input
		if(Input.touchCount==0){
			touchallowed=true;
		}
		//timer for when the player input will start
		if(mytimer<=0f){
			allowed=true;
		}
		else{
			mytimer-=Time.deltaTime;

		}


	}
}
