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
        public static readonly PropertyGroup None = new PropertyGroup("None");
    }

    public static class PropertyGroupServices
    {
        public static PropertyGroup GetPropertyGroup(LocationIndex locationIndex)
        {
            if (IsPurple(locationIndex))
            {
                return PropertyGroup.Purple;
            }
            else if (IsLightBlue(locationIndex))
            {
                return PropertyGroup.LightBlue;
            }
            else if (IsViolet(locationIndex))
            {
                return PropertyGroup.Violet;
            }
            else if (IsOrange(locationIndex))
            {
                return PropertyGroup.Orange;
            }
            else if (IsRed(locationIndex))
            {
                return PropertyGroup.Red;
            }
            else if (IsYellow(locationIndex))
            {
                return PropertyGroup.Yellow;
            }
            else if (IsDarkGreen(locationIndex))
            {
                return PropertyGroup.DarkGreen;
            }
            else if (IsDarkBlue(locationIndex))
            {
                return PropertyGroup.DarkBlue;
            }
            else if (IsRailroad(locationIndex))
            {
                return PropertyGroup.Railroad;
            }
            else if (IsUtility(locationIndex))
            {
                return PropertyGroup.Utility;
            }

            return PropertyGroup.None;
        }

        private static bool IsPurple(LocationIndex locationIndex)
        {
            return locationIndex.Equals(LocationIndex.MediterraneanAve)
                || locationIndex.Equals(LocationIndex.BalticAve);
        }

        private static bool IsLightBlue(LocationIndex locationIndex)
        {
            return locationIndex.Equals(LocationIndex.OrientalAve)
                || locationIndex.Equals(LocationIndex.VermontAve)
                || locationIndex.Equals(LocationIndex.ConnecticutAve);
        }

        private static bool IsViolet(LocationIndex locationIndex)
        {
            return locationIndex.Equals(LocationIndex.StCharlesPlace)
                || locationIndex.Equals(LocationIndex.StatesAve)
                || locationIndex.Equals(LocationIndex.VirginiaAve);
        }

        private static bool IsOrange(LocationIndex locationIndex)
        {
            return locationIndex.Equals(LocationIndex.StJamesPlace)
                || locationIndex.Equals(LocationIndex.TennesseeAve)
                || locationIndex.Equals(LocationIndex.NewYorkAve);
        }

        private static bool IsRed(LocationIndex locationIndex)
        {
            return locationIndex.Equals(LocationIndex.KentuckyAve)
                || locationIndex.Equals(LocationIndex.IndianaAve)
                || locationIndex.Equals(LocationIndex.IllinoisAve);
        }

        private static bool IsYellow(LocationIndex locationIndex)
        {
            return locationIndex.Equals(LocationIndex.AtlanticAve)
                || locationIndex.Equals(LocationIndex.VentnorAve)
                || locationIndex.Equals(LocationIndex.MarvinGardens);
        }

        private static bool IsDarkGreen(LocationIndex locationIndex)
        {
            return locationIndex.Equals(LocationIndex.PacificAve)
                || locationIndex.Equals(LocationIndex.NorthCarolinaAve)
                || locationIndex.Equals(LocationIndex.PennsylvaniaAve);
        }

        private static bool IsDarkBlue(LocationIndex locationIndex)
        {
            return locationIndex.Equals(LocationIndex.ParkPlace)
                || locationIndex.Equals(LocationIndex.Boardwalk);
        }

        private static bool IsRailroad(LocationIndex locationIndex)
        {
            return locationIndex.Equals(LocationIndex.ReadingRailroad)
                || locationIndex.Equals(LocationIndex.ShortLineRailroad)
                || locationIndex.Equals(LocationIndex.BAndORailroad)
                || locationIndex.Equals(LocationIndex.PennsylvaniaRailroad);
        }

        private static bool IsUtility(LocationIndex locationIndex)
        {
            return locationIndex.Equals(LocationIndex.ElectricCompany)
                || locationIndex.Equals(LocationIndex.WaterWorks);
        }
    }
}
