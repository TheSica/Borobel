using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensingComponent : MonoBehaviour
{
	private const float SensingRadius = 1f;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			var colliders = Physics.OverlapSphere(transform.position, SensingRadius);
			foreach (var obj in colliders)
			{
				GetInterfaces(out List<IInteractible> interactibles, obj.gameObject);
				foreach (var interactible in interactibles)
				{
					interactible.Interact();
				}
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(1, 0, 0, .3f);
		Gizmos.DrawSphere(transform.position, 1);
	}

	private static bool ImplementsInteractible(GameObject obj)
	{
		MonoBehaviour[] list = obj.GetComponents<MonoBehaviour>();
		foreach (var mb in list)
		{
			if (mb is IInteractible)
			{
				return true;
			}
		}

		return false;
	}

	public static void GetInterfaces<T>(out List<T> resultList, GameObject objectToSearch) where T : class
	{
		MonoBehaviour[] list = objectToSearch.GetComponents<MonoBehaviour>();
		resultList = new List<T>();
		foreach (MonoBehaviour mb in list)
		{
			if (mb is T)
			{
				//found one
				resultList.Add((T)((System.Object)mb));
			}
		}
	}
}
