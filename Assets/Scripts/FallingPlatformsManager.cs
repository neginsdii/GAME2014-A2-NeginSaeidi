/*
 * Full Name        : Negin Saeidi
 * Student ID       : 101261395
 * Date Modified    : December 12, 2021
 * File             : FallingPlatformsManager.cs
 * Description      : This is the FallingPlatformsManager script - Is used to respawn the platforms that has fallen
 * Version          : V01
 * Revision History : Added functions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformsManager : MonoBehaviour
{
    public List<Transform> SpawnPositions;
    public List<GameObject> platforms;
    public GameObject platformRef;
	public float screenBounds;
	private void Start()
	{
		for (int i = 0; i < SpawnPositions.Count; i++)
		{
			platforms.Add(Instantiate(platformRef, SpawnPositions[i].position, Quaternion.identity));
		}
	}

	private void Update()
	{
		for (int i = 0; i < SpawnPositions.Count; i++)
		{
			if (!platforms[i])
			{
				platforms[i] = Instantiate(platformRef, SpawnPositions[i].position, Quaternion.identity);

			}
		}

	}

}
