using System;

namespace SpriteExtractor.Serializables
{
    [Serializable]
    public struct SubTexture
    {
        public string name;
        public int x;
        public int y;
        public int width;
        public int height;
    }
}