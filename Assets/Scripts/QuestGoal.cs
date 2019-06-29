using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
	public enum GoalType
	{
		Read,
		Pickup,
		Use
	}

	public GoalType goalType;
}
