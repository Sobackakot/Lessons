using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class SaveLoadRebind : MonoBehaviour
{
    public InputActionAsset ActionsAsset;
    private void OnEnable()
    {
        string bindKey = PlayerPrefs.GetString("Rebinds");
        if (!string.IsNullOrEmpty(bindKey))
            ActionsAsset.LoadBindingOverridesFromJson(bindKey);
    }
    private void OnDisable()
    {
        string rebindKey = ActionsAsset.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("Rebinds",rebindKey);
    }
}
