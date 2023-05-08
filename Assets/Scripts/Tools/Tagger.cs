using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Component used to set a key id on inspector and find the current object by code
///</summary>
public class Tagger : MonoBehaviour {
	#region Public variables
		///<summary>
		///String value Id of the current object [Only can change on inspector]
		///</summary>
		[Tooltip("This is the string id that you need to find the object by code.")]
		[SerializeField] protected string tagId = null;
		#endregion

		#region Public Methods
		///<summary>
		///Check if the idValue is the same that the current tagger object
		///</summary>
		///<param name="idValue">Id string value that want to compare</param>
		public GameObject CheckId(string idValue){
			if(idValue == tagId) return this.gameObject;
			return null;
		}
		#endregion
}
