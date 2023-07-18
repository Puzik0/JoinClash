using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Menu
{
    [RequireComponent(typeof(Button))]
    [RequireComponent (typeof(Image))]
    public class SfxVolumeButton : MonoBehaviour
    {
        [Header("Volume Mixer")]
        [SerializeField] private string _SfXVolumeParameter;
        [SerializeField] private AudioMixer _mixer;

        [SerializeField] private Graphic image;

        [Header("States Color")]
        [SerializeField] private Colors _colors;

        private void Start()
        {
            Button button = GetComponent<Button>();
            Image image = GetComponent<Image>();
            IEnumerator<Action> statesEnumerator = new States(_mixer, image, _colors, _SfXVolumeParameter).GetEnumerator();

            button.onClick.AddListener(() =>
            {
                statesEnumerator.MoveNext();
                statesEnumerator.Current.Invoke();
            });

        }

        [Serializable]
        private struct Colors
        {
            public Color Enabled;
            public Color Disabled;
        }
        private class States : IEnumerable<Action>
        {
            private const float Enabled = 0.0f;
            private const float Disabled = -80.0f;

            private readonly AudioMixer _mixer;
            private readonly Graphic _image;
            private readonly Colors _colors;
            private readonly string _volumeParameter;

            public States(AudioMixer mixer, Graphic image, Colors colors, string volumeParameter)
            {
                _mixer = mixer;
                _image = image;
                _colors = colors;
                _volumeParameter = volumeParameter;
            }

            public IEnumerator<Action> GetEnumerator()
            {
                Action[] actions = Values().ToArray();
                for (int i = 0; i < actions.Length; i= (i+1) % actions.Length)
                {
                    yield return actions[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();

            }
            private IEnumerable<Action> Values()
            {
                yield return () =>
                {
                    _mixer.SetFloat(_volumeParameter, Disabled);
                    _image.color = _colors.Disabled;
                };
                yield return() => 
                {
                    _mixer.SetFloat(_volumeParameter, Enabled);
                    _image.color = _colors.Enabled; 
                };
            }
        }
    }
}