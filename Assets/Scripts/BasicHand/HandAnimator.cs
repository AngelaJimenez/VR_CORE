using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimator : MonoBehaviour
{

    public float speed = 5.0f;
    public XRController controller = null;

    private Animator animator = null;

    private readonly List<Finger> fingers = new List<Finger>()
    {
        new Finger(FingerType.Index),
        new Finger(FingerType.Middle),
        new Finger(FingerType.Pinky),
        new Finger(FingerType.Ring),
        new Finger(FingerType.Thumb),
    };


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckSign();

    }



    private void CheckSign()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float pointerValue))
            SetFingerTargets(fingers, pointerValue);

    }

    private void SetFingerTargets(List<Finger> fingers, float value)
    {
        foreach (Finger finger in fingers)
            finger.target = value;
        SmoothFinger(fingers);
    }

    private void SmoothFinger(List<Finger> fingers)
    {
        foreach (Finger finger in fingers)
        {
            float time = speed * Time.unscaledDeltaTime;
            finger.current = Mathf.MoveTowards(finger.current, finger.target, time);
        }
        AnimateFinger(fingers);

    }

    private void AnimateFinger(List<Finger> fingers)
    {
        foreach (Finger finger in fingers)
            AnimateFinger(finger.type.ToString(), finger.current);
    }

    private void AnimateFinger(string finger, float blend)
    {
        animator.SetFloat(finger, blend);
    }
}