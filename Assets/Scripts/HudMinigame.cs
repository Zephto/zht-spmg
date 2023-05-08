using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using ZHTgames.Tools;


///<summary>
///
///</summary>
public class HudMinigame : MonoBehaviour {

	#region Public references
	[Header("Game References")]
	///<summary>
	///
	///</summary>
	[SerializeField] private CanvasGroup gameScreen;

	///<summary>
	///
	///</summary>
	[SerializeField] private TextMeshProUGUI scoreDisplayer;

	///<summary>
	///
	///</summary>
	[SerializeField] private Image[] lifeReferences;

	[Header("Pause References")]
	///<summary>
	///
	///</summary>
	[SerializeField] private CanvasGroup pauseScreen;
	#endregion

	#region Internal references
	#endregion

	void Awake() {
	}

	void Start() {
		//Add listeners
		var gameTaggers		= gameScreen.GetComponentsInChildren<Tagger>();
		var pauseTaggers	= pauseScreen.GetComponentsInChildren<Tagger>();
		gameTaggers.Where(x => x.CheckId("PAUSE_BUTTON")).FirstOrDefault().GetComponent<Button>()
		.onClick.AddListener(()=>PauseGame());
		pauseTaggers.Where(x => x.CheckId("CONTINUE_BUTTON")).FirstOrDefault().GetComponent<Button>()
		.onClick.AddListener(()=>ContinueGame());
		pauseTaggers.Where(x => x.CheckId("EXIT_BUTTON")).FirstOrDefault().GetComponent<Button>()
		.onClick.AddListener(()=>ExitGame());


		//FIXME - ALGO ESTA FALLANDO AQUI, QUE DEMONIOS!! El tool de transicion
		//no esta funcionando cuando se le pide un tiempo 0.. revisar que esta pasando
		//Display default canvas
		TransitionCanvasGroups.SpecificAlphaCanvas(new CanvasGroup[]{gameScreen, pauseScreen}, gameScreen);
		// TransitionCanvasGroups.AlphaCanvas(gameScreen, 1f, 0f, null);
		// TransitionCanvasGroups.AlphaCanvas(pauseScreen, 0f, 0f, null);
	}

	#region Private Methods
	private void PauseGame(){

	}

	private void ContinueGame(){

	}

	private void ExitGame(){

	}
	#endregion



}
