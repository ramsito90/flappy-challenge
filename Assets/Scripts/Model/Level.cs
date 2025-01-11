using System;

[Serializable]
public class Level {

    public string name;
    public string sprite;
    public string boardName;
    public string achievement;
    public float speed;
    public float gravity;

    public Pipe pipe;

    [Serializable]
    public class Pipe {

        public string prefab;
        public string spriteUp;
        public string spriteDown;
        public string spriteFinishLine;
        public float distance;
        public float[] heights;
        public float[] stars;

    }

}