﻿using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;

	void Start ()
	{
            GetComponent<Rigidbody>().velocity = -transform.right * speed;
	}
}
