using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    //EXPERIMENT WITH THOSE VALUES 
    [SerializeField]
    float speed = 0; //the speed of the camera's movement
    [SerializeField]
    float distance = 0; //the distance from the borders at which the camera is starting to move

	void Start () {
		
	}

    void Update()
    {
        PlayerPrefs.SetInt("MouseMovement", 1); //for testing purposes
        if (PlayerPrefs.GetInt("MouseMovement") == 1) //checking the player's desired camera movement method
        {
            MouseMovement();
        }

    }
    void MouseMovement(){
            //getting the X and Y position of the mouse
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            //if the mouse is close to the right edge of the screen we move it to the right
            if (mouseX >= (Screen.width - distance))
            {
                transform.Translate(Vector3.right*speed*Time.deltaTime);
            }
            //if the mouse is close to the left edge of the screen we move it to the left
            else if (mouseX <= distance)
            {
                transform.Translate(Vector3.left * speed* Time.deltaTime); 
            }
            //if the mouse is close to the top edge of the screen we move it up
            if (mouseY >= (Screen.height - distance))
            {
                transform.Translate(Vector3.forward * speed* Time.deltaTime);
                transform.Translate(Vector3.up * speed * Time.deltaTime); //the camera is at a 45 degree angle so moving it forward will cause it to go to the ground 
                                                                          //so we move it up at the same time to balance it and make it go straight
            }
            //if the mouse is close to the bottom edge of the screen we move it down
            else if (mouseY <= distance)
            {
                transform.Translate(Vector3.back * speed* Time.deltaTime); 
                transform.Translate(Vector3.down * speed * Time.deltaTime); //same here but this time we pull it down
            }
    }
}
