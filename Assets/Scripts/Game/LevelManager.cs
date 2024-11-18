public class LevelManager {

    private static LevelManager instance;

    public static LevelManager GetInstance() {
        return instance ??= new LevelManager();
    }

    public Level Level;
    public Pj Pj;
    public readonly Score Score = new();

}