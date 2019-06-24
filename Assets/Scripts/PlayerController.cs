using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private const float TurnSpeed = 20f;

	[SerializeField] private Animator _animator;
	[SerializeField] private Rigidbody _rigidbody;

	private float _verticalAxis;
	private float _horizontalAxis;
	private Vector3 _movement;
	private Quaternion _rotation;

	private void FixedUpdate()
	{
		float _horizontalAxis = Input.GetAxis("Horizontal");
		float _verticalAxis = Input.GetAxis("Vertical");

		_movement.Set(_horizontalAxis, 0f, _verticalAxis);
		_movement.Normalize();

		var cameraForward = Camera.main.transform.forward;
		cameraForward.y = 0;
		cameraForward = cameraForward.normalized;

		var cameraRight = Camera.main.transform.right;
		cameraRight.y = 0;
		cameraRight = cameraRight.normalized;

		_movement = (cameraForward * _movement.z + cameraRight * _movement.x);

		if(Input.GetKey(KeyCode.LeftShift))
		{
			_movement *= 1.5f;
		}
		
		bool hasHorizontalInput = !Mathf.Approximately(_horizontalAxis, 0f);
		bool hasVerticalInput = !Mathf.Approximately(_verticalAxis, 0f);
		bool isWalking = hasHorizontalInput || hasVerticalInput;
		_animator.SetBool("IsWalking", isWalking);

		Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _movement, TurnSpeed * Time.deltaTime, 0f);
		_rotation = Quaternion.LookRotation(desiredForward);
	}

	private void OnAnimatorMove()
	{
		_rigidbody.MovePosition(_rigidbody.position + _movement * _animator.deltaPosition.magnitude);
		_rigidbody.MoveRotation(_rotation);
	}
}
