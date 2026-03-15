using UnityEngine;
using System.Linq;
using TMPro;

public class RiggedGambling : MonoBehaviour
{
    [Header("Results")]
    public TMP_Text letterOne;
    public TMP_Text letterTwo;
    public TMP_Text letterThree;
    public TMP_Text letterFour;
    public TMP_Text commonCounter;
    public TMP_Text rareCounter;
    public TMP_Text epicCounter;
    public TMP_Text jackpotCounter;
    public TMP_Text rollsCounter;
    public TMP_Text SNAPCounter;
    public TMP_Text logsText;

    // Public variables
    public int common = 0;
    public int rare = 0;
    public int epic = 0;
    public int jackpot = 0;
    public int rolls = 0;
    public int SNAP = 0;

    // Private variables
    private char letter1;
    private char letter2;
    private char letter3;
    private char letter4;
    private string logs;
    private string allLogs;

    private char GenerateLetter()
    {
        System.Random rand = new System.Random();
        char letter = (char)('A' + rand.Next(26));
        return letter;
    }

    public void CallGamble()
    {
        letter1 = GenerateLetter();
        letter2 = GenerateLetter();
        letter3 = GenerateLetter();
        letter4 = GenerateLetter();
    }

    public void GambleOdds()
    {
        System.Random rand = new System.Random();
        float percentValue = rand.Next(1, 1001);
        char[] letters = { letter1, letter2, letter3, letter4 };
        var counts = letters.GroupBy(c => c).Select(g => g.Count()).ToList();
        counts.Clear();
        
        if (percentValue <= 700)
        {
            while (!counts.Contains(1))
            {
                CallGamble();
                letters = new[] { letter1, letter2, letter3, letter4 };
                counts = letters.GroupBy(c => c).Select(g => g.Count()).ToList();
            }
            common++;
            commonCounter.text = "Commons: " + common.ToString();
            logs = "COMMON";
            Debug.Log(logs);
        }
        else if (percentValue >= 701 && percentValue <= 900)
        {
            while (!counts.Contains(2))
            {
                CallGamble();
                letters = new[] { letter1, letter2, letter3, letter4 };
                counts = letters.GroupBy(c => c).Select(g => g.Count()).ToList();
            }
            rare++;
            rareCounter.text = "Rares: " + rare.ToString();
            logs = "RARE";
            Debug.Log(logs);
        }
        else if (percentValue >= 901 && percentValue <= 990)
        {
            while (!counts.Contains(3))
            {
                CallGamble();
                letters = new[] { letter1, letter2, letter3, letter4 };
                counts = letters.GroupBy(c => c).Select(g => g.Count()).ToList();
            }
            epic++;
            epicCounter.text = "Epics: " + epic.ToString();
            logs = "EPIC";
            Debug.Log(logs);
        }
        else if(percentValue >= 991 && percentValue <= 999)
        {
            while (!counts.Contains(4))
            {
                CallGamble();
                letters = new[] { letter1, letter2, letter3, letter4 };
                counts = letters.GroupBy(c => c).Select(g => g.Count()).ToList();
            }
            jackpot++;
            jackpotCounter.text = "Jackpots: " + jackpot.ToString();
            logs = "JACKPOT";
            Debug.Log(logs);
        }
        else if(percentValue <= 1000)
        {
            letter1 = 'S';
            letter2 = 'N';
            letter3 = 'A';
            letter4 = 'P';

            letters = new[] { letter1, letter2, letter3, letter4 };
            counts = letters.GroupBy(c => c).Select(g => g.Count()).ToList();
            SNAP++;
            SNAPCounter.text = "SNAPS: " + SNAP.ToString();
            logs = "SNAP";
            Debug.Log(logs);
        }
    }

    public void PressGambleButton()
    {
        rolls++;
        GambleOdds();
        Debug.Log(letter1 + " - " + letter2 + " - " + letter3 + " - " + letter4);
        letterOne.text = letter1.ToString();
        letterTwo.text = letter2.ToString();
        letterThree.text = letter3.ToString();
        letterFour.text = letter4.ToString();
        rollsCounter.text = "Total Rolls " + rolls.ToString();
        allLogs = logs + "\n" + letter1 + " - " + letter2 + " - " + letter3 + " - " + letter4 + "\n";
        logsText.text = allLogs + "\n" + logsText.text;
    }

    public void PressExitButton()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }
}