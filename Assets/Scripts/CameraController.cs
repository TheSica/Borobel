using UnityEngine;

public class CameraController : MonoBehaviour
{
	private const float AxisSpeed = 3f;

	private float _yaw = 0f;
	private float _pitch = 0f;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			var currentAngle = transform.rotation.eulerAngles;
			currentAngle.y += 45f;
			transform.rotation = Quaternion.Euler(currentAngle); // todo find a way to make it smoother (lerp)
		}

		if(Input.GetKeyDown(KeyCode.E))
		{
			var currentAngle = transform.rotation.eulerAngles;
			currentAngle.y -= 45f;
			transform.rotation = Quaternion.Euler(currentAngle); // todo find a way to make it smoother (lerp)

		}
	}



}
