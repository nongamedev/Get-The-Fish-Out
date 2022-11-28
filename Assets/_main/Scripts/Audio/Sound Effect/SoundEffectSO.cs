using UnityEditor;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SFX_", menuName = "Audio/New Sound Effect")]

    public class SoundEffectSO : ScriptableObject
    {
        #region Config

        public AudioClip[] clips;
        public Vector2 volume = new Vector2(0.5f, 0.5f);
        public Vector2 pitch = new Vector2(1, 1);

        #endregion

        //#region Preview

//#if UNITY_EDITOR
//        private AudioSource previewer;

//        private void OnEnable()
//        {
//            previewer = EditorUtility
//                .CreateGameObjectWithHideFlags("AudioPreview", HideFlags.HideAndDontSave,
//                    typeof(AudioSource))
//                .GetComponent<AudioSource>();
//        }

//        private void OnDisable()
//        {
//            DestroyImmediate(previewer.gameObject);
//        }
//        private void PlayPreview()
//        {
//            Play(previewer);
//        }
//        private void StopPreview()
//        {
//            previewer.Stop();
//        }

//#endif
//        #endregion

        public AudioSource Play(AudioSource audioSourceParam = null)
        {
            if (clips.Length == 0)
            {
                Debug.LogWarning("Missing sound clips for {name}");
                return null;
            }

            var source = audioSourceParam;

            if (source == null)
            {
                var _obj = new GameObject("Sound", typeof(AudioSource));
                source = _obj.GetComponent<AudioSource>();
            }

            //Set source config:
            source.clip = clips[Random.Range(0, clips.Length)];
            source.volume = Random.Range(volume.x, volume.y);
            source.pitch = Random.Range(pitch.x, pitch.y);

            source.Play();

            Destroy(source, source.clip.length);

            return source;
        }
    }
}
