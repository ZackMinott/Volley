using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBall : MonoBehaviour {

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 50 * Time.deltaTime));
    }
}
