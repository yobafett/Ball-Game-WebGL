using Input;
using UI;
using UI.Buttons;
using UnityEngine;

namespace Player
{
	public class Respawner : MonoBehaviour
	{
		[SerializeField] private Transform SpawnPosition;

		private void OnEnable()
		{
			StartGame.Clicked += Respawn;
		}

		private void OnDisable()
		{
			StartGame.Clicked -= Respawn;
		}

		private void Respawn() =>
			transform.position = SpawnPosition.position;
	}
}
