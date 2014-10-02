using UnityEngine;
using System.Collections;

public class GiveAllObjectsToManagers : MonoBehaviour {
	
	public GameObject player;
	
	// Used in ManagerPlatform, The array of buttons that need to be hided in Windows / PC.
	public GameObject[] phoneButtonsToHide;
	
	// Used in SetActive, The array of orbs in the beggining of the game to active.
	public GameObject arrayOrbsStart;

	// Used ManagerPool to instantiate the orbs.
	public GameObject poolOrbs;

	// Used in ManagerMenu, the menu that are show when the game is paused / lost / win.
	public GameObject menuGame;
	public GameObject menuLoose;
	public GameObject menuWin;

	// Used in Detect Bouddaries, to place the wall correctly in the beggining of the game
	public GameObject walls;

	// Used in DispalyAmmo, display the ammount of arrow that the player has, and 
	public GameObject UIArrayArrowHook;
	public GameObject UIArrayArrowTriple;
	public GameObject powerUpContainer;

	// Used in SetPositionBorderArrowType, to make the object move to show the current arrow the players uses.
	public GameObject showCurrentAmmo;

}
