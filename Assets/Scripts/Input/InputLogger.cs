using System.Collections.Generic;
using GameLogic;
using Player;
using UI.Buttons;
using UnityEngine;

namespace Input
{
	[RequireComponent(typeof(IMover))]
	public class InputLogger : MonoBehaviour
	{
		public delegate void InputLoggerEventHandler();
		public static event InputLoggerEventHandler EscClicked;
	
		private readonly Queue<KeyCode> _inputLog = new Queue<KeyCode>();
		private IMover _mover;
		private bool _enabled;

		private void Awake()
		{
			_mover = GetComponent<IMover>();
		}

		private void OnEnable()
		{
			StartGame.Clicked += Enable;
			Track.FallTriggered += Disable;
			Track.FinishTriggered += Disable;
		}

		private void OnDisable()
		{
			StartGame.Clicked -= Enable;
			Track.FallTriggered -= Disable;
			Track.FinishTriggered -= Disable;
		}

		private void Update()
		{
			if (_enabled)
			{
				if(UnityEngine.Input.GetKey(KeyCode.W))
					_inputLog.Enqueue(KeyCode.W);
    
				if(UnityEngine.Input.GetKey(KeyCode.A))
					_inputLog.Enqueue(KeyCode.A);
    
				if(UnityEngine.Input.GetKey(KeyCode.S))
					_inputLog.Enqueue(KeyCode.S);
    
				if(UnityEngine.Input.GetKey(KeyCode.D))
					_inputLog.Enqueue(KeyCode.D);

				if (UnityEngine.Input.GetKey(KeyCode.Escape))
				{
					EscClicked?.Invoke();
					Disable();
				}
			}
		}

		private void FixedUpdate()
		{
			if (_enabled)
			{
				if(_inputLog.Count > 0)
					_mover.DoMove(_inputLog);
		
				_inputLog.Clear();
			}
		}

		private void Enable() =>
			_enabled = true;
  
		private void Disable() =>
			_enabled = false;
	}
}
