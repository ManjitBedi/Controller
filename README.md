# Controller - playground for using controllers with Unity

Note: there are bugs in the code - to be fixed!

I am using the project to try out working with controllers with Unity; so far all of the projects that I have worked on used touches on mobile devices or mouse input & keyboard input on desktops.  

Now it is time to try out using controllers.

Initially, I am developing on MacOs with a Xbox controller connected over BlueTooth - woot.


The simple game is using an Action map already provided with some sample code from Unity.

The code will take the direction values from a gamepad or the WASD keys and trigger an event callback.

```
public void OnMove(InputAction.CallbackContext context)
{
	// read the value for the "move" action each event call
	moveAmount = context.ReadValue<Vector2>();
	movementText.text = $"({moveAmount.x.ToString("F2")}, {moveAmount.y.ToString("F2")})";
}
```

The movement callback is associated with a PlayerInput instance in the game scene under "Events" -> "gamePlay".

## Collision detection

- the simple mechanic of the game level is to register a hit of a falling object with the player game object.
- this requires the falling objects to have the 'is trigger' property set to true; we don't need to use physics with the objects bouncing off of each other
- also for collisions to register the player and dropping game objects need colliders & rigid body components
- the score is updated if the tag of the object collided with is "Spawned"

```
/// <summary>
/// Upon collision with another game object, increase the score.
/// </summary>
/// <param name="other"></param>
private void OnTriggerEnter(Collider other)
{
	// Check for a match with the specific tag on any GameObject that collides with your GameObject
	if (other.gameObject.tag == "Spawned")
	{
		score += 10;
		scoreText.text = $"Score: {score.ToString("D5")}";
		StartConsumeItemSequence(other.gameObject);
	}
}
```

## Assets in use

This project is using:

- for animation [DOTween](http://dotween.demigiant.com)
- Assets from Everything Library © David OReilly [Everything](https://www.davidoreilly.com/library)
- a some backgrounds generated by [Dream Studio](https://beta.dreamstudio.ai/generate)
- font ["Press Start 2P"](https://fonts.google.com/specimen/Press+Start+2P)

