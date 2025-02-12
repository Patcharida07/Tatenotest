using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreManager scoreManager; // ลิงก์ไปที่ ScoreManager
    private int currentScore = 0;
    public void AddScore(int value)
    {
        currentScore += value; // เพิ่มคะแนน
    }
    public void GameOver()
    {
        scoreManager.SaveScore(currentScore); // บันทึกคะแนนเมื่อเกมจบ
        Debug.Log("Game Over! High Score: " + scoreManager.scoreData.highScore);
    }
}