using UnityEngine;
using System.Collections;

public class Listener : MonoBehaviour {

    //Reference to blobal Notifications Manager
    public NotificationsManager Notifications = null;

    // Use this for initialization
    void Start () {
	
        //Register this object as a listener for Keyboard Notifications
        if (Notifications != null)
        {
            Notifications.AddListener(this, "OnKeyboardInput");
        }
	}

    //This function will be called by the NotifcationsManager when keyboard events occur
    public void OnKeyboardInput(Component Sender)
    {
        //Print to console
        Debug.Log("Keyboard Event Occurred");
    }
}
