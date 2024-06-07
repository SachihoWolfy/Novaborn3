using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Currently only useful on the player. Will allow you to attach the hud to other game objects later.
public class StateDebugHud : MonoBehaviour
{
    public static StateDebugHud instance;
    public TextMeshProUGUI infoText;
    // Start is called before the first frame update
    void Start()
    {
        StateDebugHud.instance = this;
    }

    public void UpdateState(string newState)
    {
        infoText.text = "State: " + newState;
    }
}
