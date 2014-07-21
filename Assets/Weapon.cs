using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{

	public float velocity;
	public float rate;
	public float damage;
	public GameObject projectile;

	private float nextFire;


	void Update () 
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + rate;
			GameObject proj = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			proj.rigidbody.velocity = transform.forward * velocity;
			proj.GetComponent<Projectile>().damage = damage;
			Destroy (proj, 3.0f);
		}
	}
}
