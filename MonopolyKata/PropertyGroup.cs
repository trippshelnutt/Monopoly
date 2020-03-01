namespace MonopolyKata
{
    public readonly struct PropertyGroup
    {
        public PropertyGroup(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return $"PropertyGroup: {Value}";
        }

        public static readonly PropertyGroup Purple = new PropertyGroup("Purple");
        public static readonly PropertyGroup LightBlue = new PropertyGroup("LightBlue");
        public static readonly PropertyGroup Violet = new PropertyGroup("Violet");
        public static readonly PropertyGroup Orange = new PropertyGroup("Orange");
        public static readonly PropertyGroup Red = new PropertyGroup("Red");
        public static readonly PropertyGroup Yellow = new PropertyGroup("Yellow");
        public static readonly PropertyGroup DarkGreen = new PropertyGroup("DarkGreen");
        public static readonly PropertyGroup DarkBlue = new PropertyGroup("DarkBlue");
        public static readonly PropertyGroup Railroad = new PropertyGroup("Railroad");
        public static readonly PropertyGroup Utility = new PropertyGroup("Utility");
    }
}
