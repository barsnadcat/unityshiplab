using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour 
{
	public float health;
	public float shield;
	public float shieldRegen;

	private float nextRegen;
	private float shieldMax;

	void Start()
	{
		shieldMax = shield;
	}

	void Update()
	{
		if (Time.time > nextRegen)
		{
			nextRegen = Time.time + 1;
			shield += shieldRegen;
			if (shield > shieldMax)
			{
				shield = shieldMax;
			}
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		Projectile proj = other.GetComponent<Projectile> ();
		if (proj != null)
		{
			shield -= proj.damage;
			float healthDamage = 0;
			if(shield < 0)
			{
				healthDamage = -shield;
				shield = 0;
			}
		
			health -= healthDamage;
			if(health < 0)
			{
				Destroy(gameObject);
			}
			Destroy(other.gameObject);
		}
	}
}
