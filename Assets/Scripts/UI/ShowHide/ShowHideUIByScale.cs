using System.Collections;
using UnityEngine;

namespace UI.ShowHide
{
	public class ShowHideUIByScale : ShowHideUI
	{
		private Coroutine _scaleCoroutine;
		private Vector3 _defaultScale;
		private float _lerpProgress;

		protected override void Awake()
		{
			base.Awake();
			_defaultScale = transform.localScale;
		}

		private void Start()
		{
			if (HideOnStart) 
				HideImmediately();
		}

		private void OnDestroy()
		{
			if(_scaleCoroutine != null)
				StopCoroutine(_scaleCoroutine);
		}

		public override void Show()
		{
			if(!OnDisplay)
				_scaleCoroutine = StartCoroutine(ScaleCoroutine());
		}

		public override void Hide()
		{
			if(OnDisplay)
				_scaleCoroutine = StartCoroutine(ScaleCoroutine());
		}

		private IEnumerator ScaleCoroutine()
		{
			while (_lerpProgress <= 1f)
			{
				_lerpProgress += 0.1f;
			
				if(OnDisplay)
					DecreaseScale();
				else
					IncreaseScale();
			
				yield return new WaitForSeconds(0.01f);
			}
		
			_lerpProgress = 0;
			OnDisplay = transform.localScale.magnitude > 0;
		}

		private void DecreaseScale() => 
			transform.localScale = Vector3.Lerp(_defaultScale, Vector3.zero, _lerpProgress);

		private void IncreaseScale() => 
			transform.localScale = Vector3.Lerp(Vector3.zero, _defaultScale, _lerpProgress);
	
		private void HideImmediately()
		{
			transform.localScale = Vector3.zero;
			OnDisplay = false;
		}
	}
}