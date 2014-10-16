using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {
	
	public int MaxHealth = 100;

	public int Health { get; private set; }
	public AudioClip PlayerHitSound;

	public PlayerController playerScript;

	void Start () {
		Health = MaxHealth;
	}


	
	
	
	IEnumerator  TakeDamage (int damage)
	{
		Health -= damage;
		playerScript.isTakingDamage = true;
		AudioSource.PlayClipAtPoint(PlayerHitSound, transform.position);

		if (Health <= 0) {
			Destroy(transform.parent.gameObject);
		}
		
		yield return new WaitForSeconds(0.3f);
		playerScript.isTakingDamage = false;
		
		
		

	}
	
	
	

	
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "monsterbullet" || other.gameObject.tag == "Enemy") 
		{	playerScript.rigidbody2D.velocity = new Vector2(playerScript.rigidbody2D.velocity.x * 4, 6);
			StartCoroutine(TakeDamage (3));
			Debug.Log ("bullet hit");
		}
	}


	void Update () {

	}
}
