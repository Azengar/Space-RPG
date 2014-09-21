using AzEngine2D.Core;
using AzEngine2D.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_RPG.Entities.Ships.States
{
    public abstract class ShipState : State
    {
        public Ship Ship { get; protected set; }
        public ShipState (Ship ship)
        {
            Ship = ship;
        }
    }
}
