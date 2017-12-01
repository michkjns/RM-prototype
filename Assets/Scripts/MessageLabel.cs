using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageLabel : MonoBehaviour 
{
	[System.Serializable]
	public class MessageList
	{
		public string BeginMessage;
		public string DeathMessage;
		public string HintMessage;
	};

	[SerializeField]
	MessageList messages;
	public MessageList Messages { get { return messages; } }

	Text messageText = null;

	void Awake()
	{
		messageText = GetComponent<Text>();
	}

	public void ShowMessage(string message)
	{
		messageText.text = message;
		gameObject.SetActive(true);
	}

	public void HideMessage()
	{
		gameObject.SetActive(false);
	}
}
