using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateItemCount : MonoBehaviour
{
    public void UpdateCount(int count)
    {
        GameEvents.current.AddingItem(count);
    }
}
