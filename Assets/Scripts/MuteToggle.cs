using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MuteToggle : MonoBehaviour
{
    // Variables
    public UnityEngine.UI.Toggle toggle;
    public bool isToggleOn;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<UnityEngine.UI.Toggle>();

        isToggleOn = toggle.isOn;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateToggleOnBool();
    }

    // Functions
    private void UpdateToggleOnBool()
    {
        isToggleOn = toggle.isOn;
    }
}
