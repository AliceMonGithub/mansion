using Lean.Transition.Method;
using UnityEngine;

namespace Codebase.DoorLogic
{
    public class FixDoor : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private MeshFilter _meshRender;
        [SerializeField] private LeanTransformLocalRotation _openRotationAnimation;
        [SerializeField] private LeanTransformLocalRotation _exitRotationAnimation;

        [SerializeField] private bool _reverse;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawMesh(_meshRender.mesh, 0, _transform.position, Quaternion.Euler(_transform.eulerAngles + new Vector3(0, _reverse ? -90 : 90, 0)));
        }

        private void OnValidate()
        {
            _openRotationAnimation.Data.Rotation = Quaternion.Euler(_transform.eulerAngles + new Vector3(0, _reverse ? -90 : 90, 0));
            _exitRotationAnimation.Data.Rotation = _transform.rotation;
        }
    }
}