public class LevelManager {

    private static LevelManager _instance;

    public static LevelManager GetInstance() {
        return _instance ??= new LevelManager();
    }

    public Level Level;
    public readonly Score Score = new Score();

}