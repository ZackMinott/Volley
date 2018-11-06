using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRubyShared
{
    public class DemoScriptPlatformSpecificView : MonoBehaviour
    {
        public GameObject LeftPanel;
        public GameObject Cube;

        private void Start()
        {
            // create a tap gesture that only executes on the left panel
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.StateUpdated += Tap_Updated_Panel;
            tap.PlatformSpecificView = LeftPanel;
            FingersScript.Instance.AddGesture(tap);

            TapGestureRecognizer tap2 = new TapGestureRecognizer();
            tap2.StateUpdated += Tap_Updated_Cube;
            tap2.PlatformSpecificView = Cube;
            FingersScript.Instance.AddGesture(tap2);
        }

        private void Tap_Updated_Cube(GestureRecognizer gesture)
        {
            if (gesture.State == GestureRecognizerState.Ended)
            {
                Debug.LogFormat("Tap gesture executed on cube at {0},{1}", gesture.FocusX, gesture.FocusY);
            }
        }

        private void Tap_Updated_Panel(GestureRecognizer gesture)
        {
            if (gesture.State == GestureRecognizerState.Ended)
            {
                Debug.LogFormat("Tap gesture executed on panel at {0},{1}", gesture.FocusX, gesture.FocusY);
            }
        }

        private void Update()
        {

        }
    }
}
