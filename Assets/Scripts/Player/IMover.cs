using System.Collections.Generic;
using UnityEngine;

namespace Player
{
	public interface IMover
	{
		public void DoMove(Queue<KeyCode> inputLog);
	}
}