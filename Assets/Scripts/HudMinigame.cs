using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;


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
	[SerializeField] private Image[] lifeReferences;

	///<summary>
	///
	///</summary>
	private TextMeshProUGUI scoreDisplayer;

	[Header("Pause References")]
	///<summary>
	///
	///</summary>
	[SerializeField] private CanvasGroup pauseScreen;
	#endregion

	#region Internal references
	#endregion

	void Awake() {
		var gameTaggers		= gameScreen.GetComponentsInChildren<Tagger>();
		scoreDisplayer		= gameTaggers.Where(x => x.CheckId("SCORE_DISPLAYER")).FirstOrDefault().GetComponent<TextMeshProUGUI>();
		gameTaggers.Where(x => x.CheckId("PAUSE_BUTTON")).FirstOrDefault().GetComponent<Button>();
	}

	void Start() {
		var pauseTaggers	= pauseScreen.GetComponentsInChildren<Tagger>();
		pauseTaggers.Where(x => x.CheckId("CONTINUE_BUTTON")).FirstOrDefault().GetComponent<Button>()
		.onClick.AddListener(()=>{});
		pauseTaggers.Where(x => x.CheckId("EXIT_BUTTON")).FirstOrDefault().GetComponent<Button>()
		.onClick.AddListener(()=>{});
	}

}
