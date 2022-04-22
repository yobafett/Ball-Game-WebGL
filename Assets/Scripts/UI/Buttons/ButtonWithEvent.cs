using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
	[RequireComponent(typeof(Button))]
	public abstract class ButtonWithEvent : MonoBehaviour
	{
		public delegate void ButtonEventHandler();
	
		private Button _button;

		private void Awake()
		{
			_button = GetComponent<Button>();
			_button.onClick
				.AddListener((ClickHandler));
		}

		protected abstract void ClickHandler();
	}
}