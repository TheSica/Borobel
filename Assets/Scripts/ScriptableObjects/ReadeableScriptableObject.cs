using UnityEngine;

[CreateAssetMenu(fileName = "ReadeableScriptableObject", menuName = "Interactible/Readable", order = 1)]
public class ReadeableScriptableObject : ScriptableObject
{
	public string textToDisplay;
	public GameObject objectToShow;
	public Vector3 eulerRotationOffset;
}
