﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider colObject) {
        Application.Quit();
    }
}
