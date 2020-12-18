using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public enum FACEDIRECTION {FACELEFT = -1, FACERIGHT = 1};
	public FACEDIRECTION facing = FACEDIRECTION.FACERIGHT;
    public LayerMask groundLayer;
    public CircleCollider2D feetCollider = null;
    public string horzAxis = "Horizontal";
	public string jumpButton = "Jump";
    public bool isGrounded = false;
    public bool canControl = true;

    public float maxSpeed = 50f;
    public float jumpPower = 600f;
    public float jumpTimeOut = 1f;

    private Rigidbody2D thisBody = null;
    private bool canJump = true;

    public static float Health
	{
		get
		{
			return health;
		}

		set
		{
			health = value;

			if(health <= 0)
			{
				//Die();
			}
		}
	}

	[SerializeField] private static float health = 100f;

    private bool GetGrounded()
    {
        Vector2 circleCenter = new Vector2(transform.position.x, transform.position.y) + feetCollider.offset;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(circleCenter, feetCollider.radius, groundLayer);
        return hitColliders.Length > 0;
    }

    private void Jump()
    {
        if (!isGrounded || !canJump) return;
        
        thisBody.AddForce(Vector2.up * jumpPower);
        canJump = false;
        Invoke("ActivateJump", jumpTimeOut);
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (!canControl || health <= 0f) return;

        isGrounded = GetGrounded();
        float horz = CrossPlatformInputManager.GetAxis(horzAxis);
        thisBody.AddForce(Vector2.right * horz * maxSpeed);

        if (CrossPlatformInputManager.GetButton(jumpButton))
        {
            Jump();
        }

        thisBody.velocity = new Vector2(Mathf.Clamp(thisBody.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(thisBody.velocity.y, -Mathf.Infinity, jumpPower));
        
        if ((horz < 0f && facing != FACEDIRECTION.FACELEFT) || (horz > 0f && facing != FACEDIRECTION.FACERIGHT))
		{
			//FlipDirection();
		}
    }


}
