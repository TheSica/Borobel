using UnityEngine;

public class DoorInteractible : Quest, IInteractible
{
	private const string DoorAnimatorParameter = "OpenDoor";
	[SerializeField] private Animator _animator;

	private bool _isDoorOpen;

	public void Interact()
	{
		switch (questState)
		{
			case QuestState.Unknown:
				break;
			case QuestState.WaitingForStart:
				OnQuestInterracted(this);
				_isDoorOpen = !_isDoorOpen;
				_animator.SetBool(DoorAnimatorParameter, _isDoorOpen);
				break;
			case QuestState.Started:
			case QuestState.Completed:
				_isDoorOpen = !_isDoorOpen;
				_animator.SetBool(DoorAnimatorParameter, _isDoorOpen);
				break;
		}
	}
}
