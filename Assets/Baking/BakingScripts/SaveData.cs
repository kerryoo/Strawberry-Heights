using System;
public struct SaveData
{
    public string username;
    public int day;
    public float cash;
    public int level;

    public SaveData(string username, int day, float cash, int level)
    {
        this.username = username;
        this.day = day;
        this.cash = cash;
        this.level = level;
    }
}