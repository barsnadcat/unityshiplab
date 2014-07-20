using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{


	private float nextFire;

	private float velocity;
	private float rate;
	private float damage;
	private float offset;

	public void Setup(float aVelocity, float aRate, float aDamage, float aOffset)
	{
		velocity = aVelocity;
		rate = aRate;
		damage = aDamage;
		offset = aOffset;
	}

	void Update () 
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + rate;
			GameObject proj = Instantiate(Resources.Load("Projectile"), transform.position + transform.forward * offset, transform.rotation) as GameObject;
			proj.rigidbody.velocity = transform.forward * velocity;
			proj.GetComponent<Projectile>().damage = damage;
			Destroy (proj, 3.0f);
		}
	}
}
