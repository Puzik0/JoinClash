using GameStates.Base;
using GameStates.States;
using StaticContext;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]

    public class ExitButton : MonoBehaviour
    {
        private void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(Instance<IGameStateMachine>.Value.Enter<BootstrapState>);
        }

    }
}