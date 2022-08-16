using UnityEngine;

namespace Codebase.CameraLogic
{
    public class DynamicFOV : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float _time;

        [Header("Components")]
        [SerializeField] private Camera _mainCamera;

        public int FOV { get; set; }

        private void Update()
        {
            _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, FOV, Time.deltaTime * _time);
        }
    }
}