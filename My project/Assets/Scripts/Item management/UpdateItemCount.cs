using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateItemCount : MonoBehaviour
{
    public void UpdateCount(int id_num)
    {
        GameEvents.current.AddingItem(id_num);
    }
}
