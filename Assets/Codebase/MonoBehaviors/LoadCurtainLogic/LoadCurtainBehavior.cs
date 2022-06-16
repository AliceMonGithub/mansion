using Lean.Transition;
using UltEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Codebase.LoadCurtainLogic
{
    public class LoadCurtain : MonoBehaviour
    {
        [SerializeField] private UltEvent _onShowEvent;

        [SerializeField] private GameObject _curtain;

        [SerializeField] private LeanManualAnimation _show;
        [SerializeField] private LeanManualAnimation _hide;
        
        private string _sceneName;
        private int _progress;

        public int Progress => _progress;

        public void Load(string sceneName)
        {
            _sceneName = sceneName;

            _curtain.SetActive(true);

            _show.BeginTransitions();
        }

        //public async void LoadScene()
        //{
        //    var progress = SceneManager.LoadSceneAsync(_sceneName);

        //    while (progress.isDone != true)
        //    {
        //    }
        //}
    }
}