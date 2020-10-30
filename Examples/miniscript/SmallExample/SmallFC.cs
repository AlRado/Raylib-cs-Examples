using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;
using System;
using System.IO;

namespace SmallExample {

    public class SmallFC {
        // Screen resolution: 96x64
        // Border width: 12, height: 8
        // Pixel scale: 8
        // Palette: 16 colors (SWEETIE 16 PALETTE by grafxkid)

        public const string NAME = "Small Fantasy Console v.0.0.1";
        public const int FPS = 30;
        public const int WINDOW_WIDTH = 960;
        public const int WINDOW_HEIGHT = 640;

        public const int WIDTH = 96;
        public const int HEIGHT = 64;
        public const int BORDER_WIDTH = 12;
        public const int BORDER_HEIGHT = 8;
        public const int SCALE = 8;
       
        public const string DEFAULT_FONT_PATH = @"..\Examples\miniscript\SmallExample\Resources\nano5.png";
        public const int DEFAULT_FONT_SIZE = 7;

        public const string SOURCE_PATH = @"..\Examples\miniscript\SmallExample\Scripts\source.ms";

        public static string source;

        // a texture into which all layers are rendered in the correct order and which is then displayed on a larger scale
        private RenderTexture2D canvasRenderTexture;

        public RenderTexture2D screenRenderTexture;
        public RenderTexture2D borderRenderTexture;

        public Rectangle screenRect;

        public Font defaultFont;

        private SmallFCIntrinsic smallFCIntrinsic;

        public void Init() {
            defaultFont = LoadFont(DEFAULT_FONT_PATH);

            smallFCIntrinsic = new SmallFCIntrinsic();
            smallFCIntrinsic.Init(this);

            // Create a RenderTexture2D to use as a canvas
            screenRenderTexture = LoadRenderTexture(WIDTH, HEIGHT);
            ClearRenderTexture(screenRenderTexture, Palette.BLACK);
            canvasRenderTexture = LoadRenderTexture(WIDTH  + BORDER_WIDTH * 2, HEIGHT + BORDER_HEIGHT * 2);
            ClearRenderTexture(canvasRenderTexture, Palette.BLACK);
            screenRect = new Rectangle(0, 0, WIDTH, HEIGHT);

            // Create a RenderTexture2D to use as a border
            borderRenderTexture = LoadRenderTexture(WIDTH + BORDER_WIDTH * 2, HEIGHT + BORDER_HEIGHT * 2);
            ClearRenderTexture(borderRenderTexture, Palette.BLACK);

            source = File.ReadAllText(SOURCE_PATH);
        }

        public string GetSource() {
            return source;
        }

        // used as a callback for the MiniScript interpreter, corresponds to print "message"
        public void StandardOutput(string s) {
            Console.WriteLine(s);
        }

        // used as a callback for the MiniScript interpreter
        public void ImplicitOutput(string s) {
            DrawText(s, 0, 0, 10, Palette.BLUE); 
            Console.WriteLine(s);
        }

        // used as a callback for the MiniScript interpreter
        public void ErrorOutput(string s) {
            DrawText(s, 0, 0, 10, Palette.RED);
            Console.WriteLine(s);
        }

        public void ClearRenderTexture(RenderTexture2D renderTexture, Color color) {
            BeginTextureMode(renderTexture);
            ClearBackground(color);
            EndTextureMode();
        }

        public void StartScreenDrawing() {
            BeginTextureMode(screenRenderTexture);
        }

        public void EndScreenDrawing() {
            EndTextureMode();
        }

        public void OnExit() {
            UnloadRenderTexture(borderRenderTexture);
            UnloadRenderTexture(screenRenderTexture);
            UnloadRenderTexture(canvasRenderTexture);
            smallFCIntrinsic.OnExit();
        }

        public void Render() {
            // draw everything to the screen texture
            BeginTextureMode(canvasRenderTexture);
            DrawTexture(borderRenderTexture.texture, 0, 0, Color.WHITE);
            DrawTexture(screenRenderTexture.texture, BORDER_WIDTH, BORDER_HEIGHT, Color.WHITE);
            EndTextureMode();

            // draw the texture of the screen in an enlarged scale
            DrawTextureEx(canvasRenderTexture.texture, Vector2.Zero, 0, SCALE, Color.WHITE);
        }

    }
}