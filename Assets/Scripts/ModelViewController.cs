using UnityEngine;

public class ModelViewController : MonoBehaviour
{
	[SerializeField]
	private Transform container;

	private GameObject _currentlyActiveObject;

	public void Setup(GameObject objectToView, Vector3 eulerRotationOffset)
	{
		if(_currentlyActiveObject != null)
		{
			Destroy(_currentlyActiveObject);
		}

		_currentlyActiveObject = Instantiate(objectToView, container);
		var newRotation = _currentlyActiveObject.transform.rotation.eulerAngles + eulerRotationOffset;
		_currentlyActiveObject.transform.rotation = Quaternion.Euler(newRotation);
		_currentlyActiveObject.layer = 9;
	}

	public void Clear()
	{
		Destroy(_currentlyActiveObject);
	}
}
