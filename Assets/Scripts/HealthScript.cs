using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	public PlayerController playerScript;

	public int hp = 100;
	public bool isEnemy = true;
	public bool isInFire;
	public bool isInRange;
	public bool isBeingAttacked;
	public bool isBeingFired;

	public Transform monsterhitbox;
	public float monsterradius;
	public LayerMask sword;
	public LayerMask fire;


	public AudioClip EnemyHitSound;
	public AudioClip EnemyDeath;
	
			

	// Use this for initialization
	void Start () {
	
	}



	
	
	
	IEnumerator  TakeDamage (int damage)
	{
		hp -= damage;
		isBeingAttacked = true;
		AudioSource.PlayClipAtPoint(EnemyHitSound, transform.position);
		
		if (hp <= 0) {
			Destroy(gameObject);
		}
		
		yield return new WaitForSeconds(1f);
	
		isBeingAttacked = false;
		
		

	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "fire" || (other.gameObject.tag == "sword" && playerScript.isAttacking == true))
		{	
			StartCoroutine(TakeDamage (5));
	
		}
	}


	// Update is called once per frame
	void Update () {

		//isInRange = Physics2D.OverlapCircle (monsterhitbox.transform.position, monsterradius, sword);
		//isInFire = Physics2D.OverlapCircle (monsterhitbox.transform.position, monsterradius, fire);


		//if (isInFire == true) {
		//				hp -= 1;
		//	AudioSource.PlayClipAtPoint(EnemyHitSound, transform.position);
		//	isBeingFired = true;
		//	Debug.Log ("on fire");
		//		}

		//if (playerScript.isAttacking == true && isInRange == true) {
		//	isBeingAttacked = true;
		//	AudioSource.PlayClipAtPoint(EnemyHitSound, transform.position);
		//	hp -=1;
		//}
		
		//if (playerScript.isAttacking == false) {
		//	isBeingAttacked = false;
			
	//	}
		
		
		
		
		//if (hp <= 0) {
		//	AudioSource.PlayClipAtPoint(EnemyDeath, transform.position);
		//	Destroy (gameObject);
			
		//}



	}

	
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;

		Gizmos.DrawWireSphere (monsterhitbox.transform.position, monsterradius);
		
		
	}
	



}
