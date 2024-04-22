using System;
using UnityEngine;

public class ClickReader : MonoBehaviour
{
    public event Action MousePressed;

    private void OnMouseUpAsButton() => MousePressed?.Invoke();
}