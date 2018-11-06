//
// Fingers Gestures
// (c) 2015 Digital Ruby, LLC
// http://www.digitalruby.com
// Source code may be used for personal or commercial projects.
// Source code may NOT be redistributed or sold.
// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRubyShared
{
    /// <summary>
    /// Allows rotating around a target using a two finger rotation gesture
    /// </summary>
    [AddComponentMenu("Fingers Gestures/Component/Rotate Orbit", 3)]
    public class FingersRotateOrbitComponentScript : MonoBehaviour
    {
        [Tooltip("The object to orbit")]
        public Transform OrbitTarget;

        [Tooltip("The object that will orbit around OrbitTarget")]
        public Transform Orbiter;

        [Tooltip("The axis to orbit around")]
        public Vector3 Axis = Vector3.up;

        [Tooltip("The rotation speed in degrees per second")]
        [Range(0.01f, 1000.0f)]
        public float RotationSpeed = 500.0f;

        /// <summary>
        /// Rotation gesture
        /// </summary>
        public RotateGestureRecognizer RotationGesture { get; private set; }

        private void Start()
        {
            RotationGesture = new RotateGestureRecognizer();
            RotationGesture.StateUpdated += RotationGesture_Updated;
            FingersScript.Instance.AddGesture(RotationGesture);
        }

        private void RotationGesture_Updated(GestureRecognizer gesture)
        {
            Orbiter.transform.RotateAround(OrbitTarget.transform.position, Axis, RotationGesture.RotationDegreesDelta * Time.deltaTime * RotationSpeed);
        }
    }
}
