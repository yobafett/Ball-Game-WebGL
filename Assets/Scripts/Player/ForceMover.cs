using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(Rigidbody))]
	public class ForceMover : MonoBehaviour, IMover
	{
		[SerializeField] private float ForcePower;

		private Rigidbody _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		public void DoMove(Queue<KeyCode> inputLog)
		{
			while (inputLog.Count > 0)
			{
				switch (inputLog.Dequeue())
				{
					case KeyCode.W:
						_rigidbody.AddForce(Vector3.forward * ForcePower);
						break;
					case KeyCode.A:
						_rigidbody.AddForce(Vector3.left * ForcePower);
						break;
					case KeyCode.S:
						_rigidbody.AddForce(Vector3.back * ForcePower);
						break;
					case KeyCode.D:
						_rigidbody.AddForce(Vector3.right * ForcePower);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}
	}
}