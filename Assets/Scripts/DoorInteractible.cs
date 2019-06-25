using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractible : MonoBehaviour, IInteractible
{
	private const string DoorAnimatorParameter = "OpenDoor";
	[SerializeField] private Animator _animator;

	private bool _isDoorOpen;

	public void Interact()
	{
		Debug.Log("Interacted with a door");
		_isDoorOpen = !_isDoorOpen;
		_animator.SetBool(DoorAnimatorParameter, _isDoorOpen);
	}
}
