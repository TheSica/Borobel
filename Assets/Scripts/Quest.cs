
using System;
using UnityEngine;
using UnityEngine.Assertions;

[Serializable]
public class Quest : MonoBehaviour
{
	public event Action QuestInterracted = delegate { };

	public QuestGoal questGoal;

	public enum QuestState
	{
		Unknown,
		WaitingForStart,
		Started,
		Completed
	}

	public QuestState questState { get; private set; }

	public void TriggerQuest()
	{
		questState = QuestState.WaitingForStart;
	}

	public void StartQuest()
	{
		Assert.IsTrue(questState == QuestState.WaitingForStart, "Cannot start a quest that is not waiting to be started");
		questState = QuestState.Started;
	}

	public void CompleteQuest()
	{
		Assert.IsTrue(questState == QuestState.Started, "Cannot complete a quest that has not started");

		questState = QuestState.Completed;
	}

	protected virtual void OnQuestInterracted()
	{
		// Make a temporary copy of the event to avoid possibility of
		// a race condition if the last subscriber unsubscribes
		// immediately after the null check and before the event is raised.
		QuestInterracted?.Invoke();
	}
}
