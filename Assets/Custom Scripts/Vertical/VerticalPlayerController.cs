using UnityEngine;
using System.Collections;

public class VerticalPlayerController : MonoBehaviour 
{
	public GameObject projectile;
	public GameObject projectile2;
	public Transform firePoint1, firePoint2;
	public float maxSpeed;
	public float moveForce;
	public float fireRate;
	public float speed;
	public int bulletAmount;

    private const float radius = 1f;

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

    private void SpawnProjectile(int magazine, Vector2 ports)
    {
        float angleStep = 360f / magazine;
        float angle = 0f;

        for (int i = 0; i <= magazine -1; i++)
        {
            float projectileDirXPosition = ports.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosiiton = ports.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosiiton);
            Vector2 projectileMoveDirection = (projectileVector - ports).normalized* speed;

			GameObject bullet = Instantiate(projectile, ports, Quaternion.identity);
			bullet.GetComponent<Rigidbody2D>().velocity = projectileMoveDirection;

            angle += angleStep;
        }
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
			//Instantiate (projectile, firePoint1.position, transform.rotation);
			//Instantiate (projectile, firePoint2.position, transform.rotation);
			SpawnProjectile(bulletAmount, firePoint1.position);

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
