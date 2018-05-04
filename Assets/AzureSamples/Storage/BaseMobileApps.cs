using System.Net;
using System.Net.Http;
using Microsoft.WindowsAzure.MobileServices;
using UnityEngine;
using UnityEngine.UI;

public class BaseMobileApps : MonoBehaviour
{
	public string MobileAppUri = string.Empty;

	protected MobileServiceClient Client;
	private Text _myText;

	// Use this for initialization
	void Start ()
	{
		_myText = GameObject.Find("DebugText").GetComponent<Text>();

#if UNITY_ANDROID
		// Android builds fail at runtime due to missing GZip support, so build a handler that uses Deflate for Android
		var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate };
		Client = new MobileServiceClient(MobileAppUri, handler);
#else
		Client = new MobileServiceClient(MobileAppUri);
#endif

	}

	public void ClearOutput()
	{
		_myText.text = string.Empty;
	}

	public void WriteLine(string s)
	{
		if(_myText.text.Length > 20000)
			_myText.text = string.Empty + "-- TEXT OVERFLOW --";

		_myText.text += s + "\r\n";
	}
}
