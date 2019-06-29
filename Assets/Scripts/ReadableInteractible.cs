using UnityEngine;

public class ReadableInteractible : Quest, IInteractible
{
	[SerializeField] private ReadeableScriptableObject _readeableScriptableObject;

	public void Interact()
	{
		switch (questState)
		{
			case QuestState.Unknown:
				break;
			case QuestState.WaitingForStart:
				GameManager.Instance.Show3DObject(_readeableScriptableObject.objectToShow, _readeableScriptableObject.eulerRotationOffset, _readeableScriptableObject.textToDisplay);
				OnQuestInterracted();
				break;
			case QuestState.Started:
			case QuestState.Completed:
				GameManager.Instance.Show3DObject(_readeableScriptableObject.objectToShow, _readeableScriptableObject.eulerRotationOffset, _readeableScriptableObject.textToDisplay);
				break;
		}
	}
}