using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   public float xForce;
   public float yForce;
   public float xDirection;
   public float yDirection;
   private Rigidbody2D enemyRigidBody;
   public float speed;

   void Start ()
   {
      enemyRigidBody = GetComponent<Rigidbody2D>();
   }

   private void FixedUpdate( )
   {
      if (transform.position.x <= -8)
      {
         xDirection = 1;
         enemyRigidBody.AddForce(Vector2.right * xForce);
      }
       if (transform.position.x >= 8)
       {
         xDirection = -1;
         enemyRigidBody.AddForce(Vector2.left * xForce);
       }
         if (transform.position.y >= 7)
       {
         yDirection = -1;
         enemyRigidBody.AddForce(Vector2.down * yForce);
       }      
      float newXPosition = transform.position.x + speed * Time.deltaTime;
      float newYPosition = transform.position.y;
      Vector2 newPosition = new Vector2(newXPosition, newYPosition);
      transform.position = newPosition;
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.tag == "Ground")
      {
         Vector2 jumpForce = new Vector2(xForce * xDirection, yForce);
         enemyRigidBody.AddForce(jumpForce);
      }
      if (collision.gameObject.tag == "Enemy")
      {
         Vector2 jumpForce = new Vector2(xForce * -xDirection, yForce);
         enemyRigidBody.AddForce(jumpForce);
      }
      if (collision.gameObject.tag == "Player")
      {
         Vector2 jumpForce = new Vector2(xForce * xDirection, yForce);
         enemyRigidBody.AddForce(jumpForce);
      }
   }
}