using UnityEngine;

namespace Core.State
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private GameObject _stateSwitcherGameObject;

        protected IStateSwitcher _stateSwitcher => _stateSwitcherGameObject.GetComponent<IStateSwitcher>();

        private void OnValidate()
        {
            if (_stateSwitcherGameObject != null && !_stateSwitcherGameObject.TryGetComponent(out IStateSwitcher stateSwitcher))
            {
                _stateSwitcherGameObject = null;
            }
        }

        public void Enter()
        {
            enabled = true;
        }

        public void Exit()
        {
            enabled = false;
        }
    }
}