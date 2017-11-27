using UnityEngine; // Here we are specifying that we are using the UnityEngine namespace

[RequireComponent(typeof (Rigidbody))] 
/* RequireComponent is an attribute, that checks for the specified type and attaches it to our GameObject if its not actually attached.
 * typeof is a Keyword that allows you to specify a data type without instantiating(building) the data type.
 */
public class PaddleController : MonoBehaviour // Here our class is inhereting MonoBehaviour which allows us to use all the MonoBehaviour functionality without having to rewrite it ourselves.
{
    private Rigidbody _rigidbody; // Here we are creating a variable of the Rigidbody Component, which allows us to programmatically access all the functions and data in the component
    public float Speed; // Our speed variable, that allows us to control how fast the paddle will go!
    public string InputString;
    /*
     * Start is a function that is run whenever a GameObject that has this script "Starts". 
     * So whenever you instantiate this class or if you have it attached to a gameobject and you press play!
     */
	void Start ()
    {
        _rigidbody = GetComponent<Rigidbody>(); // This is a function that is on every MonoBehaviour, which allows us to programmatically assign Components to Variables
	}
	
    /*
     * FixedUpdate is a function that is called every Physics Frame. So it can run once, zero or multiple times per Frame. 
     * The distinction between a Frame and Physics Frame is that Frame is every rendered Frame while Physics Frame is the physics system running alongside it.
     */
	void FixedUpdate ()
    {
        /*
         * Here we are declaring a variable inside of the Input.GetAxis function. GetAxis takes a string variable, and it is expecting the name of an input axis.
         * We are then multiplying it by our predefined variable Speed to make it go faster, since Input.GetAxis will only return 1, 0 or -1!
         * NB: If you are recieving input from a gamepad controller the Input.GetAxis will probably return values like 0.2, -0.5, 0.7 etc.
         */
        float yVelocity = Input.GetAxis(InputString) * Speed;
        /*
         * Here we are accessing the variable velocity in the Rigidbody Component. If the velocity is not 0, the rigidbody component will move the GameObject based on the velocity variable!
         * So if we have a X velocity of 2, we will move the GameObject to the right, after the Component has made its calculations. 
         * We are basically moving our GameObject along the Y position based on the Input that the player is giving! 
         */
        Move(new Vector3(0, yVelocity, 0));
	}

    public void Move(Vector3 moveAmount)
    {
        _rigidbody.velocity = moveAmount;
    }

}
