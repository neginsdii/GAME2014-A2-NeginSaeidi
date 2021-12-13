/*
 * Full Name        : Negin Saeidi
 * Student ID       : 101261395
 * Date Modified    : December 12, 2021
 * File             : FallingPlatformController.cs
 * Description      : This is the FallingPlatformController script - Controls the platform rigid body type
 * Version          : V01
 * Revision History : Added functions
 */
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
