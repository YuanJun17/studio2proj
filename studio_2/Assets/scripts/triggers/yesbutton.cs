using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yesbutton : MonoBehaviour
{
    public delegate void ButtonPressed(bool isYes);
    public static event ButtonPressed OnButtonPressed;

    void OnMouseDown()
    {
        OnButtonPressed?.Invoke(true); // ´«µÝtrue
    }
}
