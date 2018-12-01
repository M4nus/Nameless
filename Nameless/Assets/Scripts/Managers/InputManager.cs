using UnityEngine;       
                                                                                     

public class InputManager : MonoBehaviour
{                  
    private void Update()
    {
        ReadingJoystick1();
        ReadingJoystick2();
    }
    private void ReadingJoystick1()
    {
        //LT is the positive values of the 3rd axis (Left Trigger)
        float LT = Input.GetAxis("LT1");
        LT = (LT > 0) ? LT : 0;

        //RT is the negative values of the 3rd axis (RightTrigger)
        float RT = Input.GetAxis("RT1");
        RT = (RT < 0) ? RT : 0;                                        
    }
    private void ReadingJoystick2()
    {
        //LT is the positive values of the 3rd axis (Left Trigger)
        float LT = Input.GetAxis("LT2");
        LT = (LT > 0) ? LT : 0;

        //RT is the negative values of the 3rd axis (RightTrigger)
        float RT = Input.GetAxis("RT2");
        RT = (RT < 0) ? RT : 0;    
    }
}
