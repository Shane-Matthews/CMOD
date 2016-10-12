using UnityEngine;
using System.Collections;
[RequireComponent(typeof(NotificationsManager))] //Component for sending and receiving

public class GameManager : MonoBehaviour {

    //C# property to retrieve currently active instance of object, if any
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameObject("GameManager").AddComponent<GameManager>(); //create game manager onject if required
            return instance;
        }
    }

    //C# property to retrieve notifications manager
    public static NotificationsManager Notifications
    {
        get
        {
            if (notifications == null) notifications = instance.GetComponent<NotificationsManager>(); //create game manager object if required
            return notifications;
        }
    }

    //Internal reference to single active instance of onject - for singleton behavior
    private static GameManager instance = null;

    //Internal reference to notifications onject
    private static NotificationsManager notifications = null;

    //Called before Start on object creation
    void Awake()
    {
        //Check if there is an existing instance of this object
        if ((instance) && (instance.GetInstanceID() != GetInstanceID()))
        {
            DestroyImmediate(gameObject); //Delete duplicate
        }
        else
        {
            instance = this; //Make ths object the only instance
            DontDestroyOnLoad(gameObject); //set as do not destroy
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


