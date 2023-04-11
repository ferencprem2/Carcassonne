using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastImage : MonoBehaviour
{
    public Image currentTile;

    public void GetTile(Sprite currentImage)
    {
        currentTile.sprite = currentImage;
    }
}
