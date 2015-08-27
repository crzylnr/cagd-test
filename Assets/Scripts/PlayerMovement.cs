using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 2.5f;
    public float negMoveSpeed = -2.5f;
	public float gravity = 4.0f;
	public float jumpSpeed = 5.0f;

	private Vector3 playerMovement = Vector3.zero;


	void start (){
  
	}
  //supposed to destroy the player object ... not working 
    void OnCollisionEnter(Collision col) {
     //outputs col's name into console
        Debug.Log("collision name = " + col.gameObject.name);
     //destroys playerobject when col's name is "Enemy"
        if(col.gameObject.name == "Enemy")
            Destroy(gameObject);
    }

	void Update (){
        
		CharacterController control = GetComponent<CharacterController> ();


      //checks if player is grounded and will allow player to jump
        if(control.isGrounded) {
            if(Input.GetKey(KeyCode.Space)) {
                playerMovement.y = jumpSpeed;
            } 
        } 

     //move left NOT WORKING *** Fixed 
    //movement left and right
        if(Input.GetKey(KeyCode.A)) {
            Debug.Log("AAAAAAAAAA");
            playerMovement.x = negMoveSpeed;
        } else if(Input.GetKey(KeyCode.D)) {
            playerMovement.x = moveSpeed;
        } else { playerMovement.x = 0; }

     //Applies gravity to player 
		playerMovement.y -= gravity * Time.deltaTime;
        control.Move(playerMovement * Time.deltaTime);





	}
    /*
     * TO DO:
     * 
     * 
     * Moving Platform
     *      When standing on the platform, the character should stay on it/move relative to the moving platform
     *      When not standing on the platform, revert to normal behavior
     *      
     * Enemy
     *      If the character touches the enemy, he should "die"
     *      
     * 
     * 
     * 
     * Variables you might want:
     *      References to the CharacterController and Keyboard input classes
     *      Speed values for moving, falling, and jumping
     *      A value to keep track of the player's movement speed and direction
     *      You will probably need to use the Update function as well as create functions for moving platforms and enemies
     */

}