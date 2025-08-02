using UnityEngine;
using System;

public class S_CanOpenerLogic : MonoBehaviour
{

    public int score = 0;
    public float canTurnSpeed = 0.05f;
    public Transform can;
    public AudioSource canNoise;

    private Transform canOpener;

    private Vector3 inputPos;
    private float angle;            //Angle between object and mouse position
    private float currentAngle;     //Of object
    private float newAngle;         //Of object
    private float changeInAngle;    //Change for scoring
    private float totalAngle;       //Checks currently rotated degrees

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canOpener = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCanOpener();
        RotateCan();
        Score();
    }


    public void RotateCanOpener()
	{
        Vector3 rotationPoint = Input.mousePosition;
        rotationPoint.z = canOpener.position.z - Camera.main.transform.position.z;
        inputPos = Camera.main.ScreenToWorldPoint(rotationPoint);
        angle = (float)Math.Atan2(canOpener.position.y - inputPos.y, canOpener.position.x - inputPos.x) * Mathf.Rad2Deg;
        
        currentAngle = canOpener.transform.eulerAngles.z;
        canOpener.rotation = Quaternion.Euler(0, 0, angle - 90);
        newAngle = canOpener.transform.eulerAngles.z;

        changeInAngle = newAngle - currentAngle;

        canNoise.pitch = Mathf.Abs(Mathf.Clamp(changeInAngle*0.2f, -2, 2));

        if (currentAngle != newAngle)
		{
        if (changeInAngle < 300 && changeInAngle > -300)
			{
                totalAngle += changeInAngle;
            }

        }
    }

    public void RotateCan()
	{
        can.localRotation = Quaternion.Euler(0, totalAngle * canTurnSpeed, 0);
    }

	public void Score()
	{
        score = -(int)(totalAngle * canTurnSpeed / 360);
        print("Score: " + score);
    }
}
