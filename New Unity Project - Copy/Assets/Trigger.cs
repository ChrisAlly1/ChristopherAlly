using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
      
    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(gameObject.name + "has collided with " + col.gameObject.name);
        if (col.gameObject.name == "Sphere(Clone)")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + "was triggred by " + other.gameObject.name);

       if (gameObject.name == "orchitbox")
       {
           iTween.RotateBy(transform.parent.gameObject, iTween.Hash("y", -.20, "easeType", "easeInOutBack", "delay", .2));
          // Destroy(transform.parent.gameObject);

         //  Debug.Log("destoryed" + gameObject);
       }
        
    }


}
