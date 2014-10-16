using UnityEngine;
using System.Collections;

public class ProjectilingMonsterHoming : MonoBehaviour {
	public PlayerController playerScript;
	public MonsterControl monsterScript;
	public float rateOfFire;
	public Transform shootOutOf;
	public bool shooting;
	public GameObject shootObj;
	public float speed;
	public AudioClip LaserShootSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		StartCoroutine (Fire ());
			
		}
		




	IEnumerator Fire()
	{
		if(!shooting)
		{
			shooting = true;
			GameObject projectile = Instantiate(shootObj, shootOutOf.position, shootOutOf.rotation) as GameObject;

			projectile.rigidbody2D.velocity = (playerScript.transform.position - transform.position).normalized * speed;
			AudioSource.PlayClipAtPoint(LaserShootSound, transform.position);
			

		
			Destroy(projectile.gameObject, 1.0f);

			yield return new WaitForSeconds (rateOfFire);
			shooting = false;

		}
	}
}
