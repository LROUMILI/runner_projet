using UnityEngine;
using WiimoteApi;
public class Movement : MonoBehaviour {

	private CharacterController controller;
	public float jumpForce = 6.0f;
	private float gravity = 10.0f;	
	private float verticalVelocity;
	public float speed = 8.0f;
	private int desiredLane = 1;
	private Wiimote wiimote;

	private const float LANE_DISTANSE = 4.0f;

	private void Start() 
	{
		controller = GetComponent<CharacterController> ();
	}

	private void Update() 
	{
		WiimoteManager.FindWiimotes ();
		if (!WiimoteManager.HasWiimote ()) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				MoveLane(false);
			}

			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				MoveLane(true);
			}


			Vector3 targetPosition = transform.position.z * Vector3.forward;
			if (desiredLane == 0) {
				targetPosition += Vector3.left * LANE_DISTANSE;
			}
			else 
			{
				if (desiredLane == 2) 
				{
					targetPosition += Vector3.right * LANE_DISTANSE;
				}
			}

			Vector3 moveVector = Vector2.zero;
			moveVector.x = (targetPosition - transform.position).normalized.x * speed;
			moveVector.y = verticalVelocity;
			moveVector.z = speed;

			controller.Move(moveVector * Time.deltaTime);

			//Jump

			if (IsGrounded()) 
			{

				if (Input.GetKeyDown (KeyCode.UpArrow)) 
				{
					verticalVelocity = jumpForce;
				}

			} 
			else 
			{
				verticalVelocity -= (gravity * Time.deltaTime);

				if (Input.GetKeyDown(KeyCode.UpArrow)) 
					verticalVelocity = -jumpForce;
			}
		} else {

			wiimote = WiimoteManager.Wiimotes[0];
			if(wiimote != null) {
				wiimote.SendPlayerLED(true, false, true, false);
				wiimote.SendDataReportMode(InputDataType.REPORT_EXT21);
			}

			int ret;
			do{
				ret = wiimote.ReadWiimoteData();
			}while(ret > 0);
			if (wiimote.Button.d_left) {
				Debug.Log ("Left");
				MoveLane(false);
			}

			if (wiimote.Button.d_right) {
				Debug.Log ("ight");
				MoveLane(true);
			}


			Vector3 targetPosition = transform.position.z * Vector3.forward;
			if (desiredLane == 0) {
				targetPosition += Vector3.left * LANE_DISTANSE;
			}
			else 
			{
				if (desiredLane == 2) 
				{
					targetPosition += Vector3.right * LANE_DISTANSE;
				}
			}

			Vector3 moveVector = Vector2.zero;
			moveVector.x = (targetPosition - transform.position).normalized.x * speed;
			moveVector.y = verticalVelocity;
			moveVector.z = speed;

			controller.Move(moveVector * Time.deltaTime);

			//Jump

			if (IsGrounded()) 
			{

				if (wiimote.Button.b) 
				{
					verticalVelocity = jumpForce;
				}

			} 
			else 
			{
				verticalVelocity -= (gravity * Time.deltaTime);

				if (Input.GetKeyDown(KeyCode.UpArrow)) 
					verticalVelocity = -jumpForce;
			}
		}
	}


	private void MoveLane(bool goingRight){

		desiredLane += (goingRight) ? 1 : -1;
		desiredLane = Mathf.Clamp (desiredLane, 0, 2);
	}


	private bool IsGrounded(){
		Ray groundRay = new Ray (new Vector3 (controller.bounds.center.x, (controller.bounds.center.y - controller.bounds.extents.y) + 0.2f, controller.bounds.center.z), Vector3.down);
		Debug.DrawRay (groundRay.origin, groundRay.direction, Color.cyan, 1.0f);

		return (Physics.Raycast (groundRay, 0.2f + 0.1f));

	}

}
