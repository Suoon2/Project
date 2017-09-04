using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;
public class GestureManager : MonoBehaviour
{
    GestureRecognizer gesture;
    void Start()
    {
        gesture = new GestureRecognizer();
        gesture.TappedEvent += Gesture_TappedEvent;
        gesture.StartCapturingGestures();
    }

    private void Gesture_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        FindObjectOfType<Sphere>().OnTapped();
    }

    void Update()
    {

    }
}
