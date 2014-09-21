using Microsoft.Xna.Framework.Input;

namespace AzEngine2D.Controller
{
    public interface IKeyHandler
    {
        void HandleInput(Keys key, bool pressed);
    }
}
