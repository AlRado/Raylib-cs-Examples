using static Raylib_cs.Raylib;
using Miniscript;
using SmallExample;

namespace Examples {

    public class miniscript_example {

        private static Interpreter interpreter;
        private static SmallFC smallFC;

        public static int Main() {
            // Window initialization must be first
            InitWindow(SmallFC.WINDOW_WIDTH, SmallFC.WINDOW_HEIGHT, SmallFC.NAME);
            SetTargetFPS(SmallFC.FPS);

            smallFC = new SmallFC();
            smallFC.Init();

            interpreter = new Interpreter();
            interpreter.standardOutput = smallFC.StandardOutput;
            interpreter.implicitOutput = smallFC.ImplicitOutput;
            interpreter.errorOutput = (string s) => {
                smallFC.ErrorOutput(s);
                interpreter.Stop();
            };

            interpreter.Reset(smallFC.GetSource());
            interpreter.Compile();

            // Main loop
            while (!WindowShouldClose()) {
                try {
                    smallFC.StartScreenDrawing();
                    interpreter.RunUntilDone(GetFrameTime());
                    smallFC.EndScreenDrawing();

                    BeginDrawing();
                    smallFC.Render();
                    EndDrawing();

                } catch (MiniscriptException err) {
                    smallFC.ErrorOutput("Script error: " + err.Description());
                }
            }

            // De-Initialization
            smallFC.OnExit();
            CloseWindow();

            return 0;
        }

    }
}