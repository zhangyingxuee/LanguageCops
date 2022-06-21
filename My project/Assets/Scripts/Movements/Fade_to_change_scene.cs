using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_to_change_scene : MonoBehaviour
{
    public GameObject this_scene;
    public GameObject next_scene;
    public GameObject player;
    public Vector3 initial_position;

    public void During_fading()
    {
        this_scene.SetActive(false);
        next_scene.SetActive(true);
        player.transform.position = initial_position;
    }


}
