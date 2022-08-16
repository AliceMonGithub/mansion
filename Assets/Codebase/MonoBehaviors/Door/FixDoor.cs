using Lean.Transition.Method;
using UnityEngine;

namespace Codebase.DoorLogic
{
    public class FixDoor : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private LeanTransformLocalRotation _openRotationAnimation;
        [SerializeField] private LeanTransformLocalRotation _exitRotationAnimation;

        private void OnValidate()
        {
            _openRotationAnimation.Data.Rotation = Quaternion.Euler(_transform.eulerAngles + new Vector3(0, 90, 0));
            _exitRotationAnimation.Data.Rotation = _transform.rotation;
        }
    }
}