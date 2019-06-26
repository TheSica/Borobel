using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class Quest : MonoBehaviour
{
	public event System.Action QuestFinished = delegate { };
	public QuestGoal questGoal;

	public enum QuestState
	{
		Unknown,
		WaitingForStart,
		Started,
		Completed
	}

	public QuestState questState { get; private set; }



	public void StartQuest()
	{
		Assert.IsTrue(questState == QuestState.WaitingForStart, "Cannot start a quest that is not waiting to be started");
		questState = QuestState.Started;
	}

	private void CompleteQuest()
	{
		Assert.IsTrue(questState == QuestState.Started, "Cannot complete a quest that has not started");

		questState = QuestState.Completed;
	}
}
