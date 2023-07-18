using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]

    public class ContinueButton : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        private void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(() => _pausePanel.SetActive(false));
        }

    }

}