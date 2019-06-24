using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensingComponent : MonoBehaviour
{
	private const float SensingRadius = 20f;


	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			RaycastHit hit;

			Physics.SphereCast(transform.position, SensingRadius, transform.forward, out hit, 10);
			{
				Debug.Log(hit);
			}

			Physics.OverlapSphere(transform.position, SensingRadius);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(1, 0, 0, .3f);
		Gizmos.DrawSphere(transform.position, 1);
	}

}
