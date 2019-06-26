using UnityEngine;

public class ReadableInteractible : Quest, IInteractible
{
	[SerializeField] private ReadeableScriptableObject _readeableScriptableObject;

	public void Interact()
	{
		if (questState == QuestState.WaitingForStart)
		{
			GameManager.Instance.Show3DObject(_readeableScriptableObject.objectToShow, _readeableScriptableObject.eulerRotationOffset, _readeableScriptableObject.textToDisplay);

			StartQuest();
		}
	}
}
