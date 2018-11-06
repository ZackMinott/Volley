using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRubyShared
{
    public class DemoScriptZoomPanCamera : MonoBehaviour
    {
        public void OrthographicCameraOptionChanged(bool orthographic)
        {
            Camera.main.orthographic = orthographic;
        }
    }
}
