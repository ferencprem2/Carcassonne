using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Texts : MonoBehaviour
{
    public TMP_Text infoText;

    public void GetUserPoints(int points)
    {
        infoText.text = $"Points: {points}";
    }
}
