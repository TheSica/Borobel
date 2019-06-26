using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
	public event System.Action QuestGoalCompleted = delegate { };

	public enum GoalType
	{
		Read,
		Pickup,
		Use
	}

	public GoalType goalType;

	public QuestGoal(GoalType type)
	{
		goalType = type;
	}

	public void CompleteGoal()
	{

	}
}
