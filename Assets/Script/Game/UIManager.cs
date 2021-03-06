﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private string prefixText = "Level ";

    [SerializeField]
    internal TMPro.TextMeshProUGUI text = null;


    private void Awake()
    {
        
        text.SetText(prefixText + 1);
    }

    public void SetLevelText(int level)
    {
        text.SetText(prefixText + level);
    }


}
