using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  public GameObject player;
  public GameObject[] walls;
  public GameObject[] boxes;
  public Vector3 move;

//Check if place is taken by wall or box
public bool Taken(Vector3 place)
{
  foreach(GameObject wall in walls)
    {
      if(wall.transform.position == place) return true;
    }
  foreach(GameObject box in boxes)
    {
      if(box.transform.position == place) return true;
    }
  return false;
}

//Check if place is taken by box
public bool IsBox(Vector3 place)
{
  foreach(GameObject box in boxes)
    {
      if(box.transform.position == place) return true;
    }
    return false;
}
public void MoveBox(Vector3 place, Vector3 vec)
{
  foreach(GameObject box in boxes)
    {
      if(box.transform.position == place) box.transform.position = box.transform.position + vec;
    }
}

// If player can be move 'vec' and that place are empty - do it.
// If position where player want to go is a box, and box can be moved - do it.
// Box can be moved 'vec' if next place is empty.
  public void CanMove(Vector3 vec)
  {
   if(Taken(player.transform.position + vec) == false)
   {
    player.transform.position = player.transform.position + vec;
   }
   else if(IsBox(player.transform.position + vec) == true)
   {
     if(Taken(player.transform.position + (2 * vec)) == false)
     {
       MoveBox(player.transform.position + vec, vec);
       player.transform.position = player.transform.position + vec;
     }
   }
  }

    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
       walls  = GameObject.FindGameObjectsWithTag("Wall");
       boxes  = GameObject.FindGameObjectsWithTag("Box");
       foreach(GameObject box in boxes) //Detaches the transform from its parent
       {
       box.transform.parent = null;
       }
    }
   // If arrow key was pressed - move the character to the next field.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
          {
            move.Set(0.75f,0f,0f);
          }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
          {
            move.Set(-0.75f,0f,0f);  
          }
        if (Input.GetKeyDown(KeyCode.UpArrow))
          {
           move.Set(0f,0.75f,0f);
          }
        if (Input.GetKeyDown(KeyCode.DownArrow))
          {
           move.Set(0f,-0.75f,0f);
          }
          CanMove(move);
          move.Set(0f,0f,0f);
    }
}
