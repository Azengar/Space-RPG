using AzEngine2D.Core;
using AzEngine2D.Rendering;
using AzEngine2D.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AzEngine2D.Camera
{
    public interface ICamera
    {
        Vector2 Position { get; set; }
        Dimension ViewPort { get; set; }
        float Scale { get; set; }
        float Rotation { get; set; }
        Vector2 Origin { get; }
        Vector2 ScreenCenter { get; }
        Matrix Transform { get; }

        bool IsInView(Vector2 position, Texture2D texture);
    }
}
