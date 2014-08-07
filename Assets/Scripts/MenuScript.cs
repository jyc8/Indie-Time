using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
	private GUISkin skin;
	public int buttonWidth = 128;
	public int buttonHeight = 50;
	public string buttonMessage = "START";
	public bool loadSceneOnClick = true;
	public string sceneName = "Level 1";

	void OnGUI()
	{		
		// Set the skin to use
		GUI.skin = Resources.Load("GUISkin") as GUISkin;
		
		// Draw a button to start the game
		if (GUI.Button(
				// Center in X, 2/3 of the height in Y
				new Rect(Screen.width / 2 - (buttonWidth / 1.5f),
		        	(2 * Screen.height / 3) - (buttonHeight / 2) + 100,
		        	buttonWidth, buttonHeight), buttonMessage) 
		    && loadSceneOnClick){
			// On Click, load the first level.
			Application.LoadLevel(sceneName); // "game" is the scene name
		}
	}
}
