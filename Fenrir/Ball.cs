//-----------------------------------------------------------------------
// <copyright file = "Ball.cs" company = "Me!">
//     Copyright (c) Me!  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Fenrir
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// The game's ball
    /// </summary>
    public class Ball : FenrirObject
    {
        /// <summary>
        /// Creates a new Paddle
        /// </summary>
        /// <param name="texture"></param>
        public Ball(Texture2D texture)
           : base(texture)
        {
        }

        /// <summary>
        /// The direction in which the ball is traveling
        /// </summary>
        public Vector2 Direction { get; set; }

        /// <summary>
        /// The speed of the ball
        /// </summary>
        public float Speed { get; set; }
    }
}
