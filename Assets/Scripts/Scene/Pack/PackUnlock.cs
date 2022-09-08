using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackUnlock : MonoBehaviour
{
    public bool UnlockPack(QuizPack quiz)
    {
        return QuizDatabase.Instance.UnlockQuiz(quiz);
    } 
}
