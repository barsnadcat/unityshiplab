using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
	public GameObject projectile;
	public float projectileVelocity;
	public float fireRate;
	public float damage;
	private float nextFire;

	void Update () 
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			GameObject proj = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			proj.rigidbody.velocity = transform.forward * projectileVelocity;
			proj.GetComponent<Projectile>().damage = damage;
			Destroy (proj, 3.0f);
		}
	}
}
