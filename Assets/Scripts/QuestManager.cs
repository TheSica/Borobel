using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
	public List<Quest> quests;
	private int _currentQuestIndex;

	private void Start()
	{
		foreach (var quest in quests)
		{
			quest.QuestInterracted += OnQuestInterracted;
		}

		_currentQuestIndex = 0;
		quests[_currentQuestIndex].TriggerQuest();
	}

	private void TriggerNextQuestOrFinishGame()
	{
		if(_currentQuestIndex + 1 >= quests.Count)
		{
			GameManager.Instance.FinishGame();
		}
		else
		{
			_currentQuestIndex += 1;
			quests[_currentQuestIndex].TriggerQuest();
		}
	}

	private void OnQuestInterracted()
	{
		quests[_currentQuestIndex].StartQuest();

		switch (quests[_currentQuestIndex].questGoal.goalType)
		{
			case QuestGoal.GoalType.Read:
				quests[_currentQuestIndex].CompleteQuest();
				TriggerNextQuestOrFinishGame();
				break;
			case QuestGoal.GoalType.Pickup:
				quests[_currentQuestIndex].CompleteQuest();
				TriggerNextQuestOrFinishGame();
				break;
			case QuestGoal.GoalType.Use:
				break;
		}
	}
}
