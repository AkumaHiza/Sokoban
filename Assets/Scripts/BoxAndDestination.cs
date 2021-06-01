using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAndDestination : MonoBehaviour
{
    private GameObject[] boxes;
    private GameObject[] destinations;

    //change color of box to green if box is on destination place
    private void ColorBox(GameObject box)
    {  
      box.GetComponent<Renderer> ().material.color = new Color32(45,255,0,255);
    }
    private void UncolorBox(GameObject box)
    {
      box.GetComponent<Renderer> ().material.color = new Color32(255,255,255,255);   
    }

    // show "You win" caption
    private void Finish()
    {
     GameObject win = GameObject.FindGameObjectWithTag("Win");
     if(win.transform.localScale.x == 0) win.transform.localScale = new Vector3(6,6,0); 
    }
    void Start()
    {
     boxes        = GameObject.FindGameObjectsWithTag("Box");
     destinations = GameObject.FindGameObjectsWithTag("Destination");
    }

    //check if boxes are on destination place
    void Update()
    {
      int all = 0;
      foreach(GameObject box in boxes)
      {
       int correct_place = 0;
       foreach(GameObject dest in destinations)
        {
          if(box.transform.position == dest.transform.position)
          {
            correct_place = 1;
            ColorBox(box);
          }
        }
        if(correct_place == 0) UncolorBox(box);
        else all++;
      }
      if(all == 6) Finish();
    }
}
