using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class WordTools
{
	public static int[] FindAllIndexof<T>(this IEnumerable<T> values, T val)
	{
		return values.Select((b, i) => object.Equals(b, val) ? i : -1).Where(i => i != -1).ToArray();
	}
}
public class WordGeneration : MonoBehaviour {
	public static bool modified;
	public static bool easy;
	public static bool normal;
	public static bool hard;
	public float pauseTime;

	public List<string> easyWords = new List<string> ();
	public List<string> normalWords = new List<string> ();
	public List<string> hardWords = new List<string> ();
	public List<string> wordList = new List<string>();

	public int chanceOfModdedWord; //In easy mode there is a higher chacne of a word going through the moddification list and not becoming modded, which decrease the number of incorrect words per game, this is to counter-balance that.
	private string wordToDisplay;
	private string finishedWord;

	char[] listOfVowelsOne = {
		'a',
		'e',
		'i',
		'o',
		'c',
		's',
		'c',
		'k',
		'g',
		'j'
	};//This as well as the next array work together to swap eachother's vowels.

	char[] listOfVowelsTwo =
	{
		'e',
		'a',
		'e',
		'u',
		's',
		'c',
		'k',
		'c',
		'j',
		'g'

	}; //The same index from the first list is swapped with the char at the second array's index.
	char[] listOfCommonDoubleConsonants = {
		'c',
		'f',
		'l',
		'm',
		'n',
		'p',
		's',
		'r'
	};
	public int chanceToModify = 1; //This is used in a Random.Range after the word is modified, to determine if it should be further modified by other methods before being shown to the player.
	//UI
	public Button nextWord;
	// Use this for initialization
	void Start() {
		if(easy)
		{
			wordList = easyWords;
			chanceOfModdedWord = 5;
		}
		else if(normal)
		{
			wordList = normalWords;
			chanceOfModdedWord = 2;
		}
		else if(hard)
		{
			wordList = hardWords;
			chanceOfModdedWord = 2;
		}

		wordGeneration();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("k"))
		{
			wordGeneration ();
		}
	}

	public void wordGeneration()
	{
		modified = false;
		int wordOrNot = Random.Range (0, chanceOfModdedWord); //0 is a real word, 1 is not. If it's 0, it'll be handled by the else, and just roll a random word from the list.
		//print(wordOrNot);
		if(wordOrNot >= 1) //1 means it's not a real word, so first it'll still pick a word, then it'll modify it based on several criteria.
		{
			string wordToModify = randomWordFromList ();
			GameStats.correctWord = wordToModify; //Reference incase the player misses the question.
			char[] wordToModifyCharArray = wordToModify.ToLower().ToCharArray ();
			for(int i = 0; i < listOfVowelsOne.Length; i++)
			{
				wordToModify = replaceLetter (wordToModifyCharArray, listOfVowelsOne [i], listOfVowelsTwo [i]);
				if(modified)
				{
					break;
				}
			}
			if(!modified)
			{
				wordToModify = swapTwoLetters (wordToModifyCharArray);
			}
			if (!modified && wordToModify.Length > 4) {
				foreach (char letterToCheck in listOfCommonDoubleConsonants) 
				{
					//print ("Checked: " + letterToCheck.ToString ());
					wordToModify = doubleConsonant (wordToModifyCharArray, letterToCheck);
					if (modified) {
						break;
					}

				}
			}



			GameStats.word = wordToModify;
			//wordDisplayer.text = wordToModify;
			//modified = false;
		}

		else //0, or an actual word was chosen. This will just return a random word from the list.
		{
			GameStats.word = randomWordFromList ();
		}
	}




	private string replaceLetter(char[] word, char letterA, char letterB)
	{
		int[] aLocations = word.FindAllIndexof (letterA); //This generates an int[] of the index locations of all the a's in the word.
		
		if(aLocations.Length > 1)
		{
			int randomAToReplace = Random.Range(1, aLocations.Length);
			int aToReplace = aLocations [randomAToReplace];
			word [aToReplace] = letterB;
			int chanceToFurtherModify = Random.Range (0, chanceToModify);
			if(chanceToFurtherModify > 0)
			{
				return new string (word);

			}
			else 
			{
				modified = true;
				return new string (word);
			}

		}
		else
		{
			return new string (word);
		}
	}
		
	private string doubleConsonant(char[] word, char letter)
	{
		string tempWord = new string (word);
		if(tempWord.Contains(letter))
		{
			int firstLetter = tempWord.IndexOf (letter, 0); //Consider adding randomization of the starting position
			if(firstLetter > 0)
			{
				int wordLength = tempWord.Length;

				if(firstLetter < wordLength - 1)
				{

					if(tempWord[firstLetter + 1]  == letter)
					{
						string newWord = tempWord.Remove(firstLetter, 1);
						modified = true;
						return newWord;
					}
					else
					{
						string letterToAdd =  letter.ToString();
						string newWord = tempWord.Insert (firstLetter, letterToAdd);
						modified = true;
						return newWord;
					}
				}
				else{
					return new string (word);
				}

			}
			else 
			{
				return new string (word);
			}
		
		}
		else 
		{
			return new string (word);
		}
	}

	private string swapTwoLetters(char[] word)
	{
		if(word.Length >= 4)
		{
			int letterCount = word.Length;
			int firstLetterIndex = Random.Range (1, (letterCount -2));
			int secondLetterIndex = Random.Range (firstLetterIndex, letterCount -1);
			char firstLetter = word [firstLetterIndex];
			char secondLetter = word [secondLetterIndex];
			if(firstLetter != secondLetter)
			{
				word [firstLetterIndex] = secondLetter;
				word [secondLetterIndex] = firstLetter;
				string newWord = new string (word);
				modified = true;
				return newWord;
			}
			else{
				return new string (word);
			}
		}
		else 
		{
			return new string  (word);
		}
	}



	private string randomWordFromList()
	{
		int chosenWord = Random.Range (0, wordList.Count);
		return wordList [chosenWord];
	}
	public void pauseBeforeNewWord()
	{
		StartCoroutine ("pause");
	}

	public IEnumerator pause() //This is for multiplayer. Becuase there is no time between the old and new word, a player can hit a word immediately after it changes without knowing what it is.
	{
		if(!GameStats.multiplayerPause)
		{
			GameStats.multiplayerPause = true;
			GameStats.word = "";
			yield return new WaitForSecondsRealtime (pauseTime);
			wordGeneration ();
			GameStats.multiplayerPause = false;}
	}
	public void setWordList(string wordListName)
	{
		if(wordListName == "easy"){
			wordList = easyWords;
			chanceOfModdedWord = 5;
		}
		else if(wordListName == "normal"){
			wordList = normalWords;
			chanceOfModdedWord = 2;
		}
		else if(wordListName == "hard"){
			wordList = hardWords;
			chanceOfModdedWord = 2;
		}
	}
}
