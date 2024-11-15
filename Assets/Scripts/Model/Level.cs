using System;

[Serializable]
public class Level {

    public Pipe pipe;
    public float speed;
    public float gravity;
    public string boardName;

    [Serializable]
    public class Pipe {

        public float distance;
        public float[] heights;

    }

}