using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRubyShared
{
    public class DemoScriptDPad : MonoBehaviour
    {
        [Tooltip("Fingers DPad Script")]
        public FingersDPadScript DPadScript;

        [Tooltip("Object to move with the dpad")]
        public GameObject Mover;

        [Tooltip("Units per second to move the square with dpad")]
        public float Speed = 250.0f;

        [Tooltip("Whether dpad moves to touch start location")]
        public bool MoveDPadToGestureStartLocation;

        private Vector3 startPos;

        private void Awake()
        {
            DPadScript.DPadItemTapped = DPadTapped;
            DPadScript.DPadItemPanned = DPadPanned;
            startPos = Mover.transform.position;
            DPadScript.MoveDPadToGestureStartLocation = MoveDPadToGestureStartLocation;
        }

        private void DPadTapped(FingersDPadScript script, FingersDPadItem item, TapGestureRecognizer gesture)
        {
            if (item == FingersDPadItem.Center)
            {
                Mover.transform.position = startPos;
            }
        }

        private void DPadPanned(FingersDPadScript script, FingersDPadItem item, PanGestureRecognizer gesture)
        {
            Vector3 pos = Mover.transform.position;
            switch (item)
            {
                case FingersDPadItem.Up:
                    pos.y += Speed * Time.deltaTime;
                    break;

                case FingersDPadItem.Right:
                    pos.x += Speed * Time.deltaTime;
                    break;

                case FingersDPadItem.Down:
                    pos.y -= Speed * Time.deltaTime;
                    break;

                case FingersDPadItem.Left:
                    pos.x -= Speed * Time.deltaTime;
                    break;
            }
            Mover.transform.position = pos;
        }
    }
}
