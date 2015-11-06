using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public float deathtime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, deathtime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter (Collision c)
    {
        Debug.Log(c.gameObject.name);
        Debug.Log(c.gameObject.tag);


        if (c.gameObject.tag == "Enemy")
        {
            Destroy(c.gameObject);
        }

        Destroy(gameObject);


    }
    void OnCollisionStay(Collision c)
    {

    }

        void OnCollisionExit(Collision c)
    {

    }
}
