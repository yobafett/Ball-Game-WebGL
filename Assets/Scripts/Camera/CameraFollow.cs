using GameLogic;
using Input;
using UI;
using UI.Buttons;
using UnityEngine;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform DefaultPosition;
        [SerializeField] private Transform PlayerTransform;
        [SerializeField] private Vector3 Offset;
        [SerializeField] private float SmoothTime;

        private Transform _currentTarget;
        private Transform _transform;
        private Vector3 _velocity;
    
        private void Awake()
        {
            _transform = gameObject.transform;
            BackToDefault();
        }

        private void OnEnable()
        {
            StartGame.Clicked += TrackPlayer;
            InputLogger.EscClicked += BackToDefault;
            Track.FallTriggered += BackToDefault;
            Track.FinishTriggered += BackToDefault;
        }

        private void OnDisable()
        {
            StartGame.Clicked -= TrackPlayer;
            InputLogger.EscClicked -= BackToDefault;
            Track.FallTriggered -= BackToDefault;
            Track.FinishTriggered -= BackToDefault;
        }

        private void Update()
        {
            UpdateCameraPosition();
        }

        private void UpdateCameraPosition()
        {
            Vector3 targetPosition = _currentTarget.localPosition + Offset;
            _transform.localPosition = Vector3.
                SmoothDamp(transform.localPosition, targetPosition, ref _velocity, SmoothTime);
        }

        private void TrackPlayer() => 
            _currentTarget = PlayerTransform;

        private void BackToDefault() =>
            _currentTarget = DefaultPosition;
    }
}