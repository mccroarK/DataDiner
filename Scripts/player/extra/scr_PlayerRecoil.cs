using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    #region Properties
    [SerializeField] Transform _plaRecoilCamera;    // Player Recoil/Headbob Camera
    #endregion

    IEnumerator Recoil(AnimationCurve curve, Vector3 recoilMultiplier, float recoilTime)
    {
        // Recoil technique modified from Gilbert (https://youtu.be/geieixA4Mqc?si=ObSRxS4_4-BW8XKl)

        // Set current step time to 0
        float currentRecoilTime = 0;

        // While current step time is less than step time
        while (currentRecoilTime < recoilTime)
        {
            // Add to step time
            currentRecoilTime += Time.deltaTime;

            // Set rotation to bob rotation
            _plaRecoilCamera.localRotation = Quaternion.Euler(
                _plaBobCurve.Evaluate(currentRecoilTime / recoilTime) * recoilMultiplier.x,
                _plaBobCurve.Evaluate(currentRecoilTime / recoilTime) * recoilMultiplier.y,
                _plaBobCurve.Evaluate(currentRecoilTime / recoilTime) * recoilMultiplier.z);

            // Return
            yield return null;
        }
    }
}
