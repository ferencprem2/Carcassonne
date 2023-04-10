using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.Burst;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private Color _playerInfoColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    public Color Init(bool isOffset)
    {
        _renderer.color = isOffset ? _baseColor : _offsetColor;

        return _renderer.color;
    }

    public void PlayerInfo(bool isInfoScreen, bool isOffset)
    {
        _renderer.color = isInfoScreen ? _playerInfoColor : Init(isOffset);

    }
    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);    
    }
}
