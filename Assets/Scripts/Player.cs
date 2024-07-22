using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Player : MonoBehaviour
{

[SerializeField]private float moveSpeed = 7f;
[SerializeField]private GameInputs gameInputs;
[SerializeField] float interactDistance =2f;
private bool isWalking;
[SerializeField] private LayerMask CounterlayerMask;
private Vector3 lastIntractedDirection;

private void Start()
{
gameInputs.OnInteractAction += GameInput_OnInteractAction;


}
  private void GameInput_OnInteractAction(object sender, EventArgs e)
{

Vector2 inputVector = gameInputs.GetMovementVectorNormalized();
Vector3 moveDir = new Vector3 (inputVector.x,0,inputVector.y);

if(moveDir != Vector3.zero)
{
 lastIntractedDirection = moveDir;


}
if(Physics.Raycast(transform.position,lastIntractedDirection, out RaycastHit raycastHit ,interactDistance,CounterlayerMask))
{
     if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
        {
          clearCounter.Intract();
//HasHit
         } 
}
  
}

    private void Update() 
 {
 
 HandelMovement();
 HandelIntraction();
 
 }

public bool IsWalking()
{

return isWalking;

}

private void HandelMovement()
{

//Inputs Code    
//Normalizing the Input Vector for Constant Speed in Fordward and Diagonally
Vector2 inputVector = gameInputs.GetMovementVectorNormalized();
Vector3 moveDir = new Vector3 (inputVector.x,0,inputVector.y);

//Raycast for ObjectDetection
float distance = moveSpeed* Time.deltaTime;
float playerRadius = .7f;
float playerHeight = 2f;
 bool canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight,playerRadius,moveDir,distance);

 if(!canMove)
 {
  //cannot moce toward moveDir
  Vector3 moveDirx = new Vector3(moveDir.x,0,0).normalized;
  canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight,playerRadius,moveDirx,distance);
  if(canMove)
  {
   //can onl move x 
   moveDir = moveDirx;
  }
   else
   {
      //Cannot Move only on the X
      //Attempt to move only in Z
     Vector3 moveDirz = new Vector3(0,0,moveDir.z).normalized;
     canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight,playerRadius,moveDirx,distance);
     if(canMove)
     {
      // can move only in  z 
     moveDir = moveDirz;
     }
     else     
     {
        //Cannot Move

     }
  
  }
  
 }
 if(canMove)
 {
transform.position += moveDir * moveSpeed* Time.deltaTime;

 }

isWalking = moveDir != Vector3.zero;
float rotateSpeed = 10f;
transform.forward = Vector3.Slerp(transform.forward,moveDir,Time.deltaTime * rotateSpeed);

}
private void HandelIntraction()
{
Vector2 inputVector = gameInputs.GetMovementVectorNormalized();
Vector3 moveDir = new Vector3 (inputVector.x,0,inputVector.y);

if(moveDir != Vector3.zero)
{
 lastIntractedDirection = moveDir;


}
if(Physics.Raycast(transform.position,lastIntractedDirection, out RaycastHit raycastHit ,interactDistance,CounterlayerMask))
{

if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
{
//clearCounter.Intract();
//HasHit

}

}
else{



}

}

}

