using UnityEngine;
using System.Collections;


public class VerticalPlayerController : MonoBehaviour 
{
	public GameObject projectile;
	public Transform firePoint1, firePoint2;
	public float maxSpeed;
	public float moveForce;
	public float fireRate;
	public float speed;
	public int bulletAmount;

    private const float radius = 5f;

    protected float horizVelocity;
	protected float vertVelocity;
	protected Rigidbody2D myRigidbody;
	
	protected bool firing;
	protected float fireTimer;	
	
	protected VerticalPushCamera cam;
	
	void Awake()
	{
		cam = Camera.main.GetComponent<VerticalPushCamera>();
		myRigidbody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update () 
	{
		transform.position = new Vector2(transform.position.x, transform.position.y + (cam.speed * Time.deltaTime));
		
		if (firing == true)
		{
			fireTimer += Time.deltaTime;
			
			if (fireTimer >= fireRate)
			{
				firing = false;
				fireTimer = 0;	
			}	
		}
		
		if (Input.GetButton("Fire1") && firing == false)
		{
			GameObject tmpbul1 = Instantiate (projectile, firePoint1.position, transform.rotation);
			GameObject tmpbul2 = Instantiate (projectile, firePoint2.position, transform.rotation);
			Vector2 bulletVelocity = new Vector2(0, 1);
			tmpbul1.GetComponent<Rigidbody2D>().velocity = bulletVelocity.normalized * ((speed) + (cam.speed * Time.deltaTime));
			tmpbul2.GetComponent<Rigidbody2D>().velocity = bulletVelocity.normalized * ((speed) + (cam.speed * Time.deltaTime));
			firing = true;
		}
		
		horizVelocity = Input.GetAxis("Horizontal");
		vertVelocity = Input.GetAxis("Vertical");
	}
	
	void FixedUpdate()
	{
		myRigidbody.AddForce(horizVelocity * Vector2.right * moveForce);

		myRigidbody.AddForce(vertVelocity * Vector2.up * moveForce);

		if (Mathf.Abs(myRigidbody.velocity.sqrMagnitude) > maxSpeed * maxSpeed)
		{
			myRigidbody.velocity = Vector2.ClampMagnitude(myRigidbody.velocity, maxSpeed);
		}
	}
}
