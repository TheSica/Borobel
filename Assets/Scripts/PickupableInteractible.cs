public class PickupableInteractible : Quest, IInteractible
{
	public void Interact()
	{
		switch (questState)
		{
			case QuestState.Unknown:
				break;
			case QuestState.WaitingForStart:
				OnQuestInterracted(this);
				break;
			case QuestState.Started:
			case QuestState.Completed:
				break;
		}
	}
}
