using UnityEngine;
using System.Collections;


public class MonsterControl : MonoBehaviour {
	public PlayerController playerScript;
	Animator anim;
	public float MonsterScaleX;
	public float MonsterScaleY;

	public Vector2 speed = new Vector2(10, 10);

	public Vector2 direction = new Vector2(-1,0);


	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {


		if (playerScript.PlayerPosition.x < transform.position.x)
		{direction.x = -1;}
		if (playerScript.PlayerPosition.x > transform.position.x)
		{direction.x = 1;}


		if (direction == new Vector2(-1,0))
		{transform.localScale = new Vector3 (-MonsterScaleX, MonsterScaleY, 1);}

		if (direction == new Vector2(1,0))
		{transform.localScale = new Vector3 (MonsterScaleX, MonsterScaleY, 1);}


		Vector3 movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0);
		movement *= Time.deltaTime;
		transform.Translate (movement);

		if (Mathf.Abs (movement.x) >= 0) {
						anim.SetInteger ("animationstate", 1);
				}
		if (Mathf.Abs (movement.x) == 0) 
		{
			anim.SetInteger ("animationstate", 0);
		}




	
	}


}
