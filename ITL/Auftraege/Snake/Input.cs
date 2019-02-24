using Snake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Input : ITickable
    {
        public int PressedKey = -1;
        public bool KeyIsPressed = false;

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int key);

        public void Tick()
        {
            for(int keyId = 1; keyId < 0xFF; keyId++)
            {
                if(GetAsyncKeyState(keyId) != 0)
                {
                    PressedKey = keyId;
                    KeyIsPressed = true;
                    break;
                }
            }
        }
    }
}
