
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obscura
{
    [RequireComponent(typeof(Camera))]

    public class CameraController: MonoBehaviour
    {
        // Position Lock Lerp Camera Controller; 
        [SerializeField] private float LerpDuration;
        [SerializeField] protected GameObject Target;
        private float minX = -26.0f;
        private float maxX = 42.5f;
        private float minY = -5.3f;
        private float maxY = 45.5f;

        private Camera ManagedCamera;

        private void Awake()
        {
            this.ManagedCamera = this.GetComponent<Camera>();
        }

        // Use the LateUpdate message to avoid setting the camera's position before Player location finalized.
        void LateUpdate()
        {
            var StartPosition = this.ManagedCamera.transform.position;
            var EndPosition = new Vector3(this.Target.transform.position.x, this.Target.transform.position.y, StartPosition.z);

            // Clamp Camera Position so that it can not exceed edges of tileset.
            EndPosition.x = Mathf.Clamp(this.Target.transform.position.x, minX, maxX);
            EndPosition.y = Mathf.Clamp(this.Target.transform.position.y, minY, maxY);

            this.ManagedCamera.transform.position = Vector3.Lerp(StartPosition, EndPosition, Time.deltaTime * LerpDuration);

        }
    }
}