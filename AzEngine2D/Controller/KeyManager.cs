using AzEngine2D.Core;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzEngine2D.Controller
{
    public class KeyManager : AzGameComponent
    {
        public List<Keys> ListenedKeys { get; set; }
        private KeyboardState oldState;

        public KeyManager ()
        {
            ListenedKeys = new List<Keys>();
        }

        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            base.Initialize();
        }

        public void updateInput ()
        {
            KeyboardState newState = Keyboard.GetState();

            foreach (Keys key in ListenedKeys)
            {
                if (newState.IsKeyDown(key))
                    AzGame.Instance.HandleInput(key, true);

                if (newState.IsKeyUp(key))
                    AzGame.Instance.HandleInput(key, false);
            }

            oldState = newState;
        }
    }
}
