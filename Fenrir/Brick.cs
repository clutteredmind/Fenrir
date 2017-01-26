//-----------------------------------------------------------------------
// <copyright file = "Brick.cs" company = "Me!">
//     Copyright (c) Me!  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Fenrir
{
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Represents a single brick in the game
    /// </summary>
    public class Brick : FenrirObject
    {
        /// <summary>
        /// Creates a new Brick
        /// </summary>
        /// <param name="texture"></param>
        public Brick(Texture2D texture)
           : base(texture)
        {
        }

        /// <summary>
        /// Indicates whether or not this brick is still in play
        /// </summary>
        public bool InPlay { get; set; }
    }
}
