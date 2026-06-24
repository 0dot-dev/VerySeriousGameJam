using UnityEngine;

public enum Difficult
{
    easy,
    serious,
    verySerious
}

public class DifficultManager : MonoBehaviour
{
    public static DifficultManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

    }

    public Difficult difficult;

    public bool canUseCheckpoints = true;
    public bool canResetLevels = true;

    public void ChooseDifficult(int difficultInt)
    {
        if(difficultInt == 0)
            difficult = Difficult.easy;
        else if(difficultInt == 1)
            difficult = Difficult.serious;
        else 
            difficult = Difficult.verySerious;

        ChangeDifficultSettings();
    }

    public void ChangeDifficultSettings()
    {
        switch (difficult)
        {
            case Difficult.easy:
                canUseCheckpoints = true;
                canResetLevels = true;
                break;
            case Difficult.serious:
                canUseCheckpoints = false;
                canResetLevels = true;
                break;
            case Difficult.verySerious:
                canUseCheckpoints = false;
                canResetLevels = false;
                break;
        }
    }
}