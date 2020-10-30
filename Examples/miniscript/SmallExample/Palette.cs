using System;
using System.Collections.Generic;
using Raylib_cs;

namespace SmallExample {

    public class Palette {

        public const int COLOR_COUNT = 16;

        public static Dictionary<string, Color> colors_by_name = new Dictionary<string, Color>();
        public static Dictionary<int, Color> colors_by_index = new Dictionary<int, Color>();

        private static int colorsCounter = 0; 

        // Palette: 16 colors (SWEETIE 16 PALETTE by grafxkid)
        public static Color BLACK = addColor("BLACK", "#1a1c2c");
        public static Color PURPLE = addColor("PURPLE", "#5d275d");
        public static Color RED = addColor("RED", "#b13e53");
        public static Color ORANGE = addColor("ORANGE", "#ef7d57");
        public static Color YELLOW = addColor("YELLOW", "#ffcd75");
        public static Color LIGHT_GREEN = addColor("LIGHT_GREEN", "#a7f070");
        public static Color GREEN = addColor("GREEN", "#38b764");
        public static Color SEA_GREEN = addColor("SEA_GREEN", "#257179");
        public static Color DEEP_BLUE = addColor("DEEP_BLUE", "#29366f");
        public static Color BLUE = addColor("BLUE", "#3b5dc9");
        public static Color PALE_BLUE = addColor("PALE_BLUE", "#41a6f6");
        public static Color CYAN = addColor("CYAN", "#73eff7");
        public static Color WHITE = addColor("WHITE", "#f4f4f4");
        public static Color LIGHT_GREY = addColor("LIGHT_GREY", "#94b0c2");
        public static Color GREY = addColor("GREY", "#566c86");
        public static Color DARK_GREY = addColor("DARK_GREY", "#333c57");

        private static Color addColor(string name, string value) {
            var color = HexToColor(value.Substring(1));
            if (colors_by_name.ContainsKey(name)) {
                colors_by_name[name] = color;
            } else {
                colors_by_name.Add(name, color);
            }

            if (colors_by_index.ContainsKey(colorsCounter)) {
                colors_by_index[colorsCounter] = color;
            } else {
                colors_by_index.Add(colorsCounter, color);
                colorsCounter++;
            }

            return color;
        }

        public static Color HexToColor(string hex) {
            var r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            var g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            var b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            return new Color(r, g, b, (byte)255);
        }

        public static Color GetColor(int colorIx) {
			var newColorIx = Math.Abs(colorIx) % COLOR_COUNT;

			return colors_by_index[newColorIx];
		}

		public static Color GetColor(string colorName) {
			var color = BLACK;
            if (colors_by_name.ContainsKey(colorName)) {
                color = colors_by_name[colorName];
            }
			return color;
		}
    }
}