[System.Serializable]

public class StructMonsterGet
{
    public IsMonster Monster;
    public int number;
    public Level level;
}

public enum IsMonster{ skeleton, pumpkin, witch, wolf, ghost, dracular, }
public enum Level { easy, normal, hard, }