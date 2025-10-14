using System;
using UnityEngine;

public static class EventManager
{
    //Called when a player start spin.
    public static Action OnSpinStart;


    //Called when the spin stoped.
    public static Action<int> OnSpinStop;


    //Trigger when a UI button press.
    public static Action OnUIButtonPress;

    //Trigger when slot spin.
    public static Action OnPlaySlotSfx;
}
