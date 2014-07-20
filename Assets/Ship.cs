using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour 
{
	public float health;
	public float shield;
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
