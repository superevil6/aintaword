using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManipulation : MonoBehaviour {
	public Text wordToManipulate;
	public GameObject wordBoxToManipulate;

	public Color[] colors;
	public float rotationSpeed;
	private int direction;
	private float lerpTimeColor = 0;
	private float lerpTimeClear = 0;
	private float lerpDuration = 1.5f;
	private float lerpTimeSize = 0;
	private Color colorOne;
	private Color colorTwo;
	private Color clearText;
	private Vector2 fontSizeOne;
	private Vector2 fontSizeTwo;
	private Vector2 startLocation;
	private Vector2 endLocation;
	private float lerpTimeMove = 0;

	bool doOnce;
	bool doOnceDetermineLoaction;

	// Use this for initialization
	void Start () {
		doOnce = true;
		doOnceDetermineLoaction = true;
		int colorIndex = Random.Range (0, colors.Length);
		colorOne = colors [colorIndex];
		colorIndex = Random.Range (0, colors.Length);
		colorTwo = colors [colorIndex];
		clearText = Color.clear;
		fontSizeOne = new Vector2 (Random.Range (0.5f, 3f), Random.Range (0.5f, 3f));
		fontSizeTwo = new Vector2 (Random.Range (0.5f, 3f), Random.Range (0.5f, 3f));

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void colorChange(Text _text)
	{
		_text.color = Color.Lerp (colorOne, colorTwo, lerpTimeColor);
		if(lerpTimeColor < 1)
		{
			lerpTimeColor += Time.deltaTime / lerpDuration;
		}
		else{
			colorOne = colorTwo;
			int colorIndex = Random.Range (0, colors.Length);
			colorTwo = colors [colorIndex];
			lerpTimeColor = 0;
		}
	}

	public void sizeChange(Text _text)
	{
		_text.transform.localScale = Vector2.Lerp (fontSizeOne, fontSizeTwo, lerpTimeSize);
		if(lerpTimeSize < 1)
		{
			lerpTimeSize += Time.deltaTime / lerpDuration;
		}
		else{
			fontSizeOne = fontSizeTwo;
			fontSizeTwo = new Vector2 (Random.Range (0.5f, 3f), Random.Range(0.5f, 3f));
			lerpTimeSize = 0;
		}
	}

	public void spinText(GameObject _text)
	{
			if(doOnce)
			{
				direction = Random.Range (0, 4);
				doOnce = false;
			}

			switch (direction){
			case 0:
				_text.transform.Rotate (Vector3.forward * rotationSpeed);
				break;
			case 1:
				_text.transform.Rotate (Vector3.up * rotationSpeed);
				break;
			case 2:
				_text.transform.Rotate (Vector3.down * rotationSpeed);
				break;
			case 3:
				_text.transform.Rotate (Vector3.back * rotationSpeed);
				break;
			case 4:
				_text.transform.Rotate (Vector3.left * rotationSpeed);
				break;

			}
	}

	public void reverseText(Text _text)
	{
		_text.transform.rotation = new Quaternion (_text.transform.rotation.x, 180f, _text.transform.rotation.z, _text.transform.rotation.w);
	}

	public void moveText(GameObject _text)
	{
		if(doOnceDetermineLoaction){
		startLocation = _text.transform.localPosition;
		float xCoord = Random.Range(_text.transform.localPosition.x - 10, _text.transform.localPosition.x + 10);
		float yCoord = Random.Range(_text.transform.localPosition.y - 10, _text.transform.localPosition.y + 10);
		endLocation = new Vector2(xCoord, yCoord);
		}
		_text.transform.localPosition =  Vector2.Lerp(startLocation, endLocation, lerpTimeMove);
		if(lerpTimeMove < 1)
		{
			lerpTimeMove += Time.deltaTime / lerpDuration;
		}
		else{
			lerpTimeMove = 0;
			doOnceDetermineLoaction = true;
		}
		
	}

	public void blinkText(Text _text)
	{
		_text.color = Color.Lerp(colorOne, clearText, lerpTimeClear);
		
		if(lerpTimeClear < 1){
			lerpTimeClear += Time.deltaTime / 0.5f;
		}
		else{
			lerpTimeClear = 0;
			colorOne = Color.white;
		}
	}
}
