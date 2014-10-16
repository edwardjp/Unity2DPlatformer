using UnityEngine;
using System.Collections;

public class bloodscript : MonoBehaviour {
	public PlayerController playerScript;

	
	Animator anim;

	public HealthScript healthScript;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}


	


	// Update is called once per frame
	void Update () {
	

		if (healthScript.isBeingAttacked == true )
		 {

			anim.SetInteger ("animationstate", 1);
				}
		
		if (healthScript.isBeingAttacked == false )
		{
			
			anim.SetInteger ("animationstate", 0);
		}




	}
}
