using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : MonoBehaviour
{
    public GameObject[] lightObjects;
    public GameObject[] shadowObjects;

    public void SwitchWorld(World world){
        if (world == World.Light){
            foreach (GameObject obj in lightObjects){
                obj.SetActive(true);
            }
            foreach (GameObject obj in shadowObjects){
                obj.SetActive(false);
            }
        } else {
            foreach (GameObject obj in lightObjects){
                obj.SetActive(false);
            }
            foreach (GameObject obj in shadowObjects){
                obj.SetActive(true);
            }
        }
    }
}
