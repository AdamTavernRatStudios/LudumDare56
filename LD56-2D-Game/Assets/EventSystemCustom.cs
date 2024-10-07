using Rewired.Integration.UnityUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystemCustom : MonoBehaviour
{
    public static EventSystemCustom Instance { get; private set; }
    RewiredEventSystem eventSystem;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GetComponent<RewiredEventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(eventSystem.currentSelectedGameObject == null || 
            eventSystem.currentSelectedGameObject.activeInHierarchy == false || 
            (eventSystem.currentSelectedGameObject.GetComponent<Selectable>()?.interactable ?? false) == false) 
        {
            var firstSelectables = FindObjectsOfType<Selectable>();
            foreach(var s in firstSelectables)
            {
                if (s.gameObject.activeInHierarchy && s.interactable)
                {
                    eventSystem.SetSelectedGameObject(s.gameObject);
                }
            }
        }
    }
}
