using UnityEngine;
using System.Collections;

public class Projectiling : MonoBehaviour {
	public PlayerController playerScript;
	public float rateOfFire;
	public float speed;

	public Transform shootOutOf;
	public bool shooting;
	public GameObject shootObj;

	public AudioClip FireSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.L) && playerScript.isGrounded == true) {
						StartCoroutine (Fire ());
	
				}

	}

	IEnumerator Fire()
	{
		if(!shooting)
		{
			shooting = true;

			playerScript.CanMove = false;
			playerScript.isCasting = true;
			AudioSource.PlayClipAtPoint(FireSound, transform.position);
			GameObject projectile = Instantiate(shootObj, shootOutOf.position, shootOutOf.rotation) as GameObject;
			if (playerScript.isFacingRight == true)
			{
			projectile.rigidbody2D.velocity = new Vector2(speed, 0);
			}
			if (playerScript.isFacingRight == false)
			{
				projectile.rigidbody2D.velocity = new Vector2(-speed, 0);
			}
			Destroy(projectile.gameObject, 1.0f);
			yield return new WaitForSeconds (rateOfFire);
			shooting = false;
			playerScript.isCasting = false;
			playerScript.CanMove = true;
		}
}
}
