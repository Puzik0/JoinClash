using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelProgress : MonoBehaviour
    {
        [Header("Position point")]
        [SerializeField] private Transform _start;
        [SerializeField] private Transform _end;

        [Header("Horde target Groupe")]
        [SerializeField] private Transform _horde;

        [Header("Progress Slider")]
        [SerializeField] private Slider _slider;

        private float _roadDistance;
        private void Start()
        {
            _roadDistance = (_end.position.z - _start.position.z);
        }

        private void Update()
        {
            float value = _horde.position.z / _roadDistance;
            _slider.value = value;
        }


    }
}