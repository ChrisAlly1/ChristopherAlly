using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour {
	public float speed = 6.0f, jumpSpeed = 8.0f, 
				 rotateSpeed = 5.0f, gravity = 9.81f;
	Vector3 moveDirection = Vector3.zero;
	public int type = 0;

	CharacterController cc;

	public Rigidbody projectilePrefab;
	public Transform projectileSpawnPoint;
	public float fireSpeed = 20.0f;
    public GUIText scoreText;
    public int score;

	void Start () {
        score = 0;
        scoreText.text = "score: " + score;
		//Grab a component and keep a reference to it
		cc = GetComponent<CharacterController> ();
		if (cc == null) {
			Debug.Log ("No CharacterController found.");
		}
	}

	void Update () {
		//Move()
		if (type == 0) {
			if (cc.isGrounded) {
				//moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection);
				transform.Rotate (0, Input.GetAxis("Horizontal"), 0);
				moveDirection *= speed;

				if(Input.GetButtonDown ("Jump")) {
					moveDirection.y = jumpSpeed;
				}
			}
			moveDirection.y -= gravity * Time.deltaTime;
			cc.Move (moveDirection * Time.deltaTime);
		//SimpleMove()
		} else if (type == 1) {
			transform.Rotate (0, Input.GetAxis ("Horizontal") * rotateSpeed, 0);
			Vector3 forward = transform.TransformDirection(Vector3.forward);

			float currentSpeed = speed * Input.GetAxis("Vertical");

			cc.SimpleMove(forward * currentSpeed);
		}

		//Key Press Stuff
		if(Input.GetButtonDown ("Fire1")) {
			Debug.Log ("Pew Pew");

			if (projectilePrefab) {
				Rigidbody temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation) as Rigidbody;
				temp.AddForce (transform.forward * fireSpeed, ForceMode.Impulse);
			} else {
				Debug.Log ("No prefab found.");
			}
		}
		if(Input.GetButtonUp ("Fire1")) {
		}

		if (Input.GetKeyDown (KeyCode.LeftControl)) {
		}
        if (cc.collisionFlags == CollisionFlags.None)
        {
          
            Debug.Log("character hit");
        }
	}
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Collectible(Clone)")
        {
            Destroy(c.gameObject);
            score = score + 50;
            scoreText.text = "score: " + score;
        }
        Debug.Log("Trigger happend");
        Debug.Log(score);


    }
    void OnTriggerExit(Collider c)
    {

    }
    void OnCollisionEnter(Collision c)
    {
        Debug.Log("Character hit " + c.gameObject.name);
    }
    void OnControllerEnterHit(ControllerColliderHit c)
    {
        Debug.Log("controller hit " + gameObject.name);
    }
}