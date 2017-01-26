//-----------------------------------------------------------------------
// <copyright file = "Paddle.cs" company = "Me!">
//     Copyright (c) Me!  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Fenrir
{
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// The game's paddle
    /// </summary>
    public class Paddle : GameObject
    {
        /// <summary>
        /// Creates a new Paddle
        /// </summary>
        /// <param name="texture"></param>
        public Paddle(Texture2D texture)
           : base(texture)
        {
        }
    }
}
