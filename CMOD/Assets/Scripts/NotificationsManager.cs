using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NotificationsManager : MonoBehaviour {

    //Internal reference to all listeners for notifications
    private Dictionary<string, List<Component>> Listeners = new Dictionary<string, List<Component>>();

    //Fuction to add listener for a notification to the listeners list
    public void AddListener(Component Listener, string NotificationName)
    {
        //Add listener to dictionary
        if (!Listeners.ContainsKey(NotificationName))
        {
            Listeners.Add(NotificationName, new List<Component>());
        }
        //Add onject to listener list for this notification
        Listeners[NotificationName].Add(Listener);
    }

    //Function to remove a listener for a notification
    public void RemoveListener(Component Sender, string NotificationName)
    {
        //if no key in dictionary exists, then exit
        if (!Listeners.ContainsKey(NotificationName))
        {
            return;
        }

        //Cycle through listeners and identify component, and then remove it
        for (int i = Listeners[NotificationName].Count - 1; i >= 0; i--)
        {
            //Check instance ID
            if (Listeners[NotificationName][i].GetInstanceID() == Sender.GetInstanceID())
            {
                Listeners[NotificationName].RemoveAt(i); //Matched, remove from list
            }
        }
    }

    //Fuction to clear all listeners
    public void ClearListeners()
    {
        //Removes all listeners
        Listeners.Clear();
    }

    //Function to remove redundant listeners - deleted and removed listeners
    public void RemoveRedundancies()
    {
        //create new dictionary
        Dictionary<string, List<Component>> TmpListeners = new Dictionary<string, List<Component>>();

        //Cycle through all dictionary entries
        foreach (KeyValuePair<string, List<Component>> Item in Listeners)
        {
            //Cycle through all listener objects in list, remove null objects
            for (int i = Item.Value.Count - 1; i >= 0; i--)
            {
                //if null, then remove them
                if (Item.Value[i] == null)
                {
                    Item.Value.RemoveAt(i);
                }
            }

            //If items remain in list for this notification, then add this to tmp dictionary
            if (Item.Value.Count > 0)
            {
                TmpListeners.Add(Item.Key, Item.Value);
            }
        }

        //Replace listeners object with new, optimized dictionary
        Listeners = TmpListeners;
    }

    //Fuction to post a notification to a listener
    public void PostNotification(Component Sender, string NotificationName)
    {
        //If no key in dictionary exists, then exit
        if (!Listeners.ContainsKey(NotificationName))
        {
            return;
        }

        //Else post notifcation to all matching listeners
        foreach (Component Listener in Listeners[NotificationName])
        {
            Listener.SendMessage(NotificationName, Sender, SendMessageOptions.DontRequireReceiver);
        }
    }
}


