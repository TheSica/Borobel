using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableInteractible : Quest, IInteractible
{
	public void Interact()
	{
		switch (questState)
		{
			case QuestState.Unknown:
				break;
			case QuestState.WaitingForStart:
				OnQuestInterracted();
				break;
			case QuestState.Started:
			case QuestState.Completed:
				break;
		}
	}
}
