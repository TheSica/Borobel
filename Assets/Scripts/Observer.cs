using UnityEngine;

public class Observer : MonoBehaviour
{
	private Transform _player;

	private bool _isPlayerInRange;

	private void Start()
	{
		_player = GameManager.Instance.PlayerTransform;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform == _player)
		{
			_isPlayerInRange = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.transform == _player)
		{
			_isPlayerInRange = false;
		}
	}

	private void Update()
	{
		if (_isPlayerInRange)
		{
			Vector3 direction = _player.position - transform.position + Vector3.up; // add Vector up because the player's origin transform is between the feet
			Ray ray = new Ray(transform.position, direction);

			if (Physics.Raycast(ray, out RaycastHit raycastHit))
			{
				if (raycastHit.collider.transform == _player)
				{
					Debug.Log("Seen player");
				}
			}
		}
	}
}