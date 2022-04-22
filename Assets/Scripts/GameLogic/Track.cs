using Input;
using UI.Buttons;
using UnityEngine;

namespace GameLogic
{
    public class Track : MonoBehaviour
    {
        [SerializeField] private TriggerObserver FallTrigger;
        [SerializeField] private TriggerObserver FinishTrigger;
        
        public delegate void TrackEventHandler();
        public static event TrackEventHandler FallTriggered;
        public static event TrackEventHandler FinishTriggered;

        private void Start()
        {
            DisableTriggers();
        }

        private void OnEnable()
        {
            FallTrigger.TriggerEnter += OnFall;
            FinishTrigger.TriggerEnter += OnFinish;
            StartGame.Clicked += EnableTriggers;
            InputLogger.EscClicked += DisableTriggers;
        }

        private void OnDisable()
        {
            FallTrigger.TriggerEnter -= OnFall;
            FinishTrigger.TriggerEnter -= OnFinish;
            StartGame.Clicked -= EnableTriggers;
            InputLogger.EscClicked -= DisableTriggers;
        }

        private void OnFinish(Collider collider)
        {
            DisableTriggers();
            FinishTriggered?.Invoke();
        }

        private void OnFall(Collider collider)
        {
            DisableTriggers();
            FallTriggered?.Invoke();
        }

        private void EnableTriggers()
        {
            FallTrigger.gameObject.SetActive(true);
            FinishTrigger.gameObject.SetActive(true);
        }
        
        private void DisableTriggers()
        {
            FallTrigger.gameObject.SetActive(false);
            FinishTrigger.gameObject.SetActive(false);
        }
    }
}
