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
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DigitalRubyShared
{
    public enum FingersDPadItem
    {
        Up,
        Right,
        Down,
        Left,
        Center
    }

    public class FingersDPadScript : MonoBehaviour
    {
        [Tooltip("The background image to use for the DPad. This should contain up, right, down, left and center in unselected state.")]
        public UnityEngine.UI.Image DPadBackgroundImage;

        [Tooltip("The up image to use for the DPad for selected state. Alpha pixel of less than MinAlphaForTouch will not be selectable.")]
        public UnityEngine.UI.Image DPadUpImageSelected;

        [Tooltip("The right image to use for the DPad for selected state. Alpha pixel of less than MinAlphaForTouch will not be selectable.")]
        public UnityEngine.UI.Image DPadRightImageSelected;

        [Tooltip("The down image to use for the DPad for selected state. Alpha pixel of less than MinAlphaForTouch will not be selectable.")]
        public UnityEngine.UI.Image DPadDownImageSelected;

        [Tooltip("The left image to use for the DPad for selected state. Alpha pixel of less than MinAlphaForTouch will not be selectable.")]
        public UnityEngine.UI.Image DPadLeftImageSelected;

        [Tooltip("The center image to use for the DPad for selected state. Alpha pixel of less than MinAlphaForTouch will not be selectable.")]
        public UnityEngine.UI.Image DPadCenterImageSelected;

        [Tooltip("Touch radius in units (usually inches). Set to lowest for single pixel accuracy, or larger if you want more than one dpad button interactable at once. " +
            "You'll need to test this to make sure the DPad works how you expect for an average finger size and your screen size.")]
        [Range(0.01f, 1.0f)]
        public float TouchRadiusInUnits = 0.125f;

        private readonly Collider2D[] overlap = new Collider2D[32];

#if UNITY_EDITOR

        private void ValidateImages(params UnityEngine.UI.Image[] images)
        {
            foreach (UnityEngine.UI.Image image in images)
            {
                if (image == null || image.canvas.renderMode == RenderMode.WorldSpace)
                {
                    Debug.LogError("Fingers dpad script requires that all images be set and that the Canvas be in ScreenSpace* mode.");
                }
            }
        }

#endif

        private void CheckForOverlap<T>(Vector2 point, T gesture, System.Action<FingersDPadScript, FingersDPadItem, T> action) where T : GestureRecognizer
        {
            if (action == null)
            {
                return;
            }

            int count = Physics2D.OverlapCircleNonAlloc(point, DeviceInfo.UnitsToPixels(TouchRadiusInUnits), overlap);
            for (int i = 0; i < count; i++)
            {
                if (overlap[i].gameObject == DPadCenterImageSelected.gameObject)
                {
                    DPadCenterImageSelected.enabled = true;
                    action(this, FingersDPadItem.Center, gesture);
                }
                else if (overlap[i].gameObject == DPadRightImageSelected.gameObject)
                {
                    DPadRightImageSelected.enabled = true;
                    action(this, FingersDPadItem.Right, gesture);
                }
                else if (overlap[i].gameObject == DPadDownImageSelected.gameObject)
                {
                    DPadDownImageSelected.enabled = true;
                    action(this, FingersDPadItem.Down, gesture);
                }
                else if (overlap[i].gameObject == DPadLeftImageSelected.gameObject)
                {
                    DPadLeftImageSelected.enabled = true;
                    action(this, FingersDPadItem.Left, gesture);
                }
                else if (overlap[i].gameObject == DPadUpImageSelected.gameObject)
                {
                    DPadUpImageSelected.enabled = true;
                    action(this, FingersDPadItem.Up, gesture);
                }
            }
        }

        private void DisableButtons()
        {
            DPadUpImageSelected.enabled = false;
            DPadRightImageSelected.enabled = false;
            DPadDownImageSelected.enabled = false;
            DPadLeftImageSelected.enabled = false;
            DPadCenterImageSelected.enabled = false;
        }

        private void PanGestureUpdated(GestureRecognizer gesture)
        {
            if (gesture.State == GestureRecognizerState.Began || gesture.State == GestureRecognizerState.Executing)
            {
                if (gesture.State == GestureRecognizerState.Began && MoveDPadToGestureStartLocation)
                {
                    transform.position = new Vector3(gesture.FocusX, gesture.FocusY, transform.position.z);
                }
                DisableButtons();
                CheckForOverlap(new Vector2(gesture.FocusX, gesture.FocusY), PanGesture, DPadItemPanned);
            }
            else if (gesture.State == GestureRecognizerState.Ended || gesture.State == GestureRecognizerState.Failed)
            {
                DisableButtons();
            }
        }

        private void TapGestureUpdated(GestureRecognizer gesture)
        {
            if (gesture.State == GestureRecognizerState.Ended)
            {
                CheckForOverlap(new Vector2(gesture.FocusX, gesture.FocusY), TapGesture, DPadItemTapped);
                DisableButtons();
            }
        }

        private void Start()
        {

#if UNITY_EDITOR

            ValidateImages(DPadBackgroundImage, DPadUpImageSelected, DPadRightImageSelected, DPadDownImageSelected, DPadLeftImageSelected, DPadCenterImageSelected);

#endif

            PanGesture = new PanGestureRecognizer
            {
                PlatformSpecificView = (MoveDPadToGestureStartLocation ? null : DPadBackgroundImage.canvas.gameObject),
                ThresholdUnits = 0.0f
            };
            PanGesture.AllowSimultaneousExecutionWithAllGestures();
            PanGesture.StateUpdated += PanGestureUpdated;
            FingersScript.Instance.AddGesture(PanGesture);

            TapGesture = new TapGestureRecognizer
            {
                PlatformSpecificView = DPadBackgroundImage.gameObject
            };
            TapGesture.AllowSimultaneousExecutionWithAllGestures();
            TapGesture.StateUpdated += TapGestureUpdated;
            FingersScript.Instance.AddGesture(TapGesture);
        }

        public System.Action<FingersDPadScript, FingersDPadItem, TapGestureRecognizer> DPadItemTapped;
        public System.Action<FingersDPadScript, FingersDPadItem, PanGestureRecognizer> DPadItemPanned;
        public PanGestureRecognizer PanGesture { get; private set; }
        public TapGestureRecognizer TapGesture { get; private set; }

        /// <summary>
        /// Whether to move the DPad when the pan gesture starts. Set this in Awake.
        /// </summary>
        public bool MoveDPadToGestureStartLocation { get; set; }
    }
}
