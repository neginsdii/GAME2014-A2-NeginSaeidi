using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody;
	private Vector3 startPosition;
	[SerializeField]
	private GameObject fallingPlatformRef;
	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		startPosition = transform.position;

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			Invoke("DropPlatform", 0.5f);
		}
	}

	void DropPlatform()
	{
		rigidbody.isKinematic = false;
		Invoke("DestoryPlatform", 4.5f);

	}

	void DestoryPlatform()
	{
		Destroy(this.gameObject);
	}	
}
