using static Raylib_cs.Raylib;
using Miniscript;
using Raylib_cs;
using System.Numerics;

namespace SmallExample {

    public class SmallFCIntrinsic {

        private SmallFC smallFC;

        public void Init(SmallFC smallFC) {
            this.smallFC = smallFC;
            
            initApiSetPixel();
            initApiCls();
            initApiBorder();
            InitApiDrawFPS();
            initApiDrawText();
        }

# region Graphics API initialization

        private void initApiSetPixel() {
            var function = Intrinsic.Create("setPixel");
            function.AddParam("x", 0);
            function.AddParam("y", 0);
            function.AddParam("colorNameOrIndex", "WHITE");
            function.code = (context, partialResult) => {
                setPixel(   context.GetVar("x").IntValue(), 
                            context.GetVar("y").IntValue(), 
                            getColor(context.GetVar("colorNameOrIndex")));
                return Intrinsic.Result.Null;
            };
        }

        private void initApiCls() {
            var function = Intrinsic.Create("cls");
            function.AddParam("colorNameOrIndex", "BLACK");
            function.code = (context, partialResult) => {
                cls(getColor(context.GetVar("colorNameOrIndex")));
                return Intrinsic.Result.Null;
            };
        }

        private void initApiBorder() {
            var function = Intrinsic.Create("border");
            function.AddParam("colorNameOrIndex", "BLACK");
            function.code = (context, partialResult) => {
                border(getColor(context.GetVar("colorNameOrIndex")));
                return Intrinsic.Result.Null;
            };
        }

        private void InitApiDrawFPS() {
            var function = Intrinsic.Create("drawFPS");
            function.code = (context, partialResult) => {
                drawFPS();
                return Intrinsic.Result.Null;
            };
        }

        private void initApiDrawText() {
            var function = Intrinsic.Create("drawText");
            function.AddParam("text", "");
            function.AddParam("x", 0);
            function.AddParam("y", 0);
            function.AddParam("colorNameOrIndex", "WHITE");
            function.code = (context, partialResult) => {
                drawText(   smallFC.defaultFont, 
                            context.GetVar("text").ToString(), 
                            new Vector2(context.GetVar("x").IntValue(), context.GetVar("y").IntValue()), 
                            SmallFC.DEFAULT_FONT_SIZE, 
                            getColor(context.GetVar("colorNameOrIndex"))
                );
                return Intrinsic.Result.Null;
            };
        }

#endregion

# region Graphics API

        public void setPixel(int x, int y, Color color) {
            DrawPixel(x, y, color);
        }

        public void cls(Color color) {
            ClearBackground(color);
        }

        public void border(Color color) {
            smallFC.ClearRenderTexture(smallFC.borderRenderTexture, color);
            smallFC.StartScreenDrawing();
        }

        public void drawFPS() {
            DrawText(GetFPS() + " FPS", 1, 0, 10, Color.WHITE);
        }

        public void drawText(Font font, string text, Vector2 position, float fontSize, Color tint) {
            DrawTextEx(smallFC.defaultFont, text, position, fontSize, 1, tint);
        }

# endregion

        private Color getColor(Value colorNameOrIndex) {
            return colorNameOrIndex is ValNumber ?
                Palette.GetColor(colorNameOrIndex.IntValue()) :
                Palette.GetColor(colorNameOrIndex.ToString());
        }

        public void OnExit() {
            // TODO implement
        }

    }
}