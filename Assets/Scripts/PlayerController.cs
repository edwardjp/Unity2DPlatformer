using UnityEngine;
using System.Collections;

//need levelmanager for player instantiation

public class PlayerController : MonoBehaviour {

	public float speedForce = 3f;
	public float jumpForce = 20;
	public float radiuss;
	public float swordradius;

	public bool isGrounded;
	public bool isAttacking;
	public bool CanMove = true;
	public bool isCasting;
	public bool isTakingDamage = false;
	public bool isFacingRight = true;


	public Transform swordhitbox;
	public Transform grounder;

	public LayerMask ground;
	public LayerMask monster;


	public Vector2 PlayerPosition;

	Animator anim;
	public AudioClip SwordHitSound;
	public AudioClip JumpSwordHitSound;
	







	public void Awake()

	{
				
		}
	// Use this for initialization
	void Start () {

	
		isCasting = false;
		anim = GetComponent<Animator> ();
	
	}





	IEnumerator Attack()
		{
			if (!isAttacking) {
			isAttacking = true;
			anim.SetInteger ("animationstate", 2);
			AudioSource.PlayClipAtPoint (SwordHitSound, transform.position);
		
			yield return new WaitForSeconds (1);
			isAttacking = false;

				}
		}
		
	// Update is called once per frame
	void Update () {




		PlayerPosition = transform.position;

		if (CanMove == false) {
			rigidbody2D.velocity = new Vector2 (0, 0);
		}

		//spellcast

		if (isCasting == true) {

						anim.SetInteger ("animationstate", 6);
				}

		//move left right

		else if (Input.GetKey (KeyCode.A) && CanMove == true) {
						rigidbody2D.velocity = new Vector2 (-speedForce, rigidbody2D.velocity.y);
						transform.localScale = new Vector3 (1, 1, 1);
			isFacingRight = false;
						anim.SetInteger ("animationstate", 1);

		} else if (Input.GetKey (KeyCode.D) && CanMove == true) {
						rigidbody2D.velocity = new Vector2 (speedForce, rigidbody2D.velocity.y);
						transform.localScale = new Vector3 (-1, 1, 1);
			isFacingRight = true;
						anim.SetInteger ("animationstate", 1);

				} else {
						rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
						anim.SetInteger ("animationstate", 0);
				}

		isGrounded = Physics2D.OverlapCircle (grounder.transform.position, radiuss, ground);



		//jump

		if (Input.GetKey (KeyCode.Space) && isGrounded == true && CanMove == true) {
			
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);

	

		}


		//cheat jump for testing
		if (Input.GetKey (KeyCode.H)) {
						rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, jumpForce);
				}


		//attack

		if (Input.GetKeyDown(KeyCode.K) && CanMove == true) {
		
		
			StartCoroutine(Attack());
						
			}

						

		//jump attack		 

		if (Input.GetKeyDown(KeyCode.K) && isGrounded == false) {
						anim.SetInteger ("animationstate", 3);
			AudioSource.PlayClipAtPoint(JumpSwordHitSound, transform.position);
			isAttacking = true;
				} 


		if (isTakingDamage == true) {
			anim.SetInteger ("animationstate", 4);
		}
		
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("Attack"))
		{isAttacking = true;}
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("JumpAttack"))
		{isAttacking = true;}

		
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("IdleCloud"))
		{isAttacking = false;}
		if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("WalkCloud"))
		{isAttacking = false;}




	}

		







	void OnDrawGizmos()
	{
				Gizmos.color = Color.white;
				Gizmos.DrawWireSphere (grounder.transform.position, radiuss);
				Gizmos.DrawWireSphere (swordhitbox.transform.position, swordradius);

		}





}
