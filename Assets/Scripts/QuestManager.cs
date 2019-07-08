using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
	public List<Quest> quests;
	private int _currentQuestIndex;

	private bool _hasKey; // Because it's a linear quest, I assume that if the player owns an usable item, he can proceede to the next quest step

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

	private void OnQuestInterracted(IInteractible interactible)
	{
		quests[_currentQuestIndex].StartQuest();

		switch (quests[_currentQuestIndex].questGoal.goalType)
		{
			case QuestGoal.GoalType.Read:
				Debug.Log("Read item" + _currentQuestIndex);
				quests[_currentQuestIndex].CompleteQuest();
				TriggerNextQuestOrFinishGame();
				break;
			case QuestGoal.GoalType.Pickup:
				Debug.Log("Pickedup item" + _currentQuestIndex);
				quests[_currentQuestIndex].CompleteQuest();
				TriggerNextQuestOrFinishGame();
				_hasKey = true;
				break;
			case QuestGoal.GoalType.Use:
				if(_hasKey)
				{
					Debug.Log("Used item" + _currentQuestIndex);
					quests[_currentQuestIndex].CompleteQuest();
					TriggerNextQuestOrFinishGame();
					_hasKey = false;
				}
				else
				{
					Debug.LogWarning("Tried to open door without quest item" + _currentQuestIndex);
				}
				break;
		}
	}
}
