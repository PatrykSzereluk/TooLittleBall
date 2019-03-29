using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private string prefixText = "Level ";

    [SerializeField]
    private TMPro.TextMeshProUGUI text;


    private void Awake()
    {
        
        text.SetText(prefixText + 1);
    }

    public void SetLevelText(int level)
    {
        text.SetText(prefixText + level);
    }


}
