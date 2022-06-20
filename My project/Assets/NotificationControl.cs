using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationControl : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onAddingItem += OnAddingItem;
    }

    private int currCount = 0;
    private int display = 0;
    private bool state = false;
    public TextMeshProUGUI Outside;
    public TextMeshProUGUI Inside;
    public GameObject PopOutside;
    public GameObject PopInside;
    private void OnAddingItem(int count)
    {
        display += count - currCount;
        currCount = count;
        state = true;
        PopOutside.SetActive(true);
        PopInside.SetActive(true);
        Outside.text = display.ToString();
        Inside.text = display.ToString();
    }

    public void OnOpeningPhone()
    {
        if (display > 0)
        {
            PopOutside.SetActive(state);
            PopInside.SetActive(!state);
            Inside.text = display.ToString();
            state = !state;
        }
    }

    public void CheckedItem ()
    {
        display = 0;
        PopOutside.SetActive(false);
        PopInside.SetActive(false);
    }
}
