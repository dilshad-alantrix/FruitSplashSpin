using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private List<Iobserver> _observers = new List<Iobserver>();

    public void AddObserver(Iobserver iobserver)
    {
        _observers.Add(iobserver);
    }

    public void RemoveObserver(Iobserver iobserver)
    {
        _observers.Remove(iobserver);
    }

    public void NotifyObserver(GameState state)
    {
       foreach(var obs in _observers)
        {
            obs.onNotify(state); 
        }
    }


}
