using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Theme{
	public string name;
	public Sprite oButtonGraphic;
	public Sprite xButtonGraphic;
	public Font _font;
	public Color fontColor;
	public Sprite background;
	public Sprite wordBackground;
	public RuntimeAnimatorController oButtonAnimator;
	public RuntimeAnimatorController xButtonAnimator;
	public RuntimeAnimatorController backgroundAnimator;
}

public class ThemeManager : MonoBehaviour {
	public List<Theme> themes = new List<Theme>(); 
	public SpriteRenderer background;
	public Animator backgroundAnimation;
	public Button[] oButtons;
	public Button[] xButtons;
	public Text[] textItems;
	public Image[] wordBackgrounds;

	// Use this for initialization
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setTheme(Theme selectedTheme)
	{
		background.sprite = selectedTheme.background;
		backgroundAnimation.runtimeAnimatorController = selectedTheme.backgroundAnimator;
		foreach(Button _button in oButtons)
		{
			_button.GetComponent<SpriteRenderer>().sprite = selectedTheme.oButtonGraphic;
			_button.GetComponent<Animator>().runtimeAnimatorController = selectedTheme.oButtonAnimator;
		}
		foreach(Button _button in xButtons)
		{
			_button.GetComponent<SpriteRenderer>().sprite = selectedTheme.xButtonGraphic;
			_button.GetComponent<Animator>().runtimeAnimatorController = selectedTheme.xButtonAnimator;
		}
		foreach(Text _text in textItems)
		{
			_text.font = selectedTheme._font;
			_text.color = selectedTheme.fontColor;
		}
		foreach(Image _image in wordBackgrounds){
			_image.sprite = selectedTheme.wordBackground;
		}

	}
}
