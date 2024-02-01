using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Behaviour;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ManHanging : MonoBehaviour
{
    public TextMeshProUGUI textLetter;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ipucuText;
    public GameObject _panelGameOver;
    public GameObject _panelWon;
    public GameObject HangingMan;
    public GameObject GameOverHangingMan;
    private IDictionary<int, string> letterStore;
    private string Word = "";
    private int failCount = 0;
    private int wordCount = 0;
    private List<string> randomlist;
    private List<string> categoryList;
    public bool isGameOver = false;
    public bool isDoneGameOverAnimation = false;
    void Start()
    {
        var result = Helper.GetRandomWord();
        randomlist = result.randomList;
        categoryList = result.category;
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            isGameOver = failCount == 6;
        }

        if (!isGameOver)
        {
            if (letterStore.Keys.Count == Word.Length)
            {
                int score = int.Parse(scoreText.text);
                score++;
                scoreText.text = score.ToString();
                _panelWon.SetActive(true);
                letterStore.Clear();
            }
        }

        if (isGameOver && !isDoneGameOverAnimation)
        {
            isDoneGameOverAnimation = true;
            HangingMan.SetActive(false);
            GameOverHangingMan.SetActive(true);
        }

        if (isGameOver)
        {
            GameOverHangingMan.GetComponent<Animator>().SetBool("isHangingStart", true);
            _panelGameOver.SetActive(true);
            textLetter.enabled = false;
            gameOverText.text = "Cevap: " + Word;
        }
    }

    void PlayWord()
    {
        textLetter.text = "";
        int len = Word.Length;
        for (int i = 0; i < len; i++)
        {
            textLetter.text += "_";
            if (i != i + 1)
                textLetter.text += " ";
        }
    }

    public void ResetGame()
    {
        if (isGameOver)
        {
            scoreText.text = "0";
        }

        textLetter.enabled = true;
        letterStore = new Dictionary<int, string>();
        isGameOver = false;
        isDoneGameOverAnimation = false;
        HangingMan.SetActive(true);
        GameOverHangingMan.SetActive(false);
        failCount = 0;
        if (wordCount == 5)
        {
            var result = Helper.GetRandomWord();
            randomlist = result.randomList;
            categoryList = result.category;
            wordCount = 0;
        }

        Word = randomlist[wordCount];
        ipucuText.text = categoryList[wordCount].ToUpper();
        PlayWord();
        wordCount++;
        HangingMan.GetComponent<SpriteRenderer>().sprite = Helper.GetFailSprite(failCount+1);

        var words = FindObjectsByType<Selectable>(FindObjectsSortMode.None);
        foreach (var selectable in words)
        {
            selectable.isClick = false;
        }
    }

    public void CheckRightLetter(string letter)
    {
        List<int> rightLets = new();
        for (int i = 0; i < Word.Length; i++)
        {
            if (Word[i].ToString().ToUpper().Equals(letter))
                rightLets.Add(i);
        }

        if (!rightLets.Any())
        {
            failCount++;
            ChangeManHangingSprite();
            return;
        }

        int len = Word.Length;
        for (int i = 0; i < len;i++)
        {
            if (rightLets.Any(x => x == i))
            {
                letterStore.Add(i,letter.ToUpper());
            }
        }

        textLetter.text = "";
        for (int i = 0; i < len; i++)
        {
            if (letterStore.Keys.Any(x => x == i))
            {
                textLetter.text += letterStore[i];
            }else
                textLetter.text += "_";
            
            if (i != i + 1)
                textLetter.text += " ";
        }
    }

    void ChangeManHangingSprite()
    {
        HangingMan.GetComponent<SpriteRenderer>().sprite = Helper.GetFailSprite(failCount + 1);
    }
}