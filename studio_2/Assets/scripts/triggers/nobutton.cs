using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nobutton : MonoBehaviour
{
    public delegate void ButtonPressed(bool isYes);
    public static event ButtonPressed OnButtonPressed;

    void OnMouseDown()
    {
        OnButtonPressed?.Invoke(false); // ´«µÝfalse
    }
}
