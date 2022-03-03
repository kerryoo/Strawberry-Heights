using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AutoHand Pose", menuName = "Auto Hand/Custom Settings", order = 1)]
public class AutoHandSettings : ScriptableObject{
    [Tooltip("Whether the popup should be ignored on launch or not")]
    public bool ignoreSetup = false;
    [Tooltip("-1 is custom, 0 is low, 1 is medium, 2 is high")]
    public float quality = -1;

    public static void ClearSettings(){
        var _handSettings = Resources.Load<AutoHandSettings>("AutoHandSettings");
        _handSettings.ignoreSetup = false;
        _handSettings.quality = -1;
    }
}
