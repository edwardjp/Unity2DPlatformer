using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
	public playerHealth PlayerHealth;
	public Transform ForegroundSprite;
	public SpriteRenderer ForegroundRenderer;


	
	public void Update()
	{var healthPercent = PlayerHealth.Health / (float)PlayerHealth.MaxHealth;
		ForegroundSprite.localScale = new Vector3 (healthPercent, 1, 1);


	}
}