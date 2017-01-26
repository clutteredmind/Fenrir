//-----------------------------------------------------------------------
// <copyright file = "Fenrir.cs" company = "Me!">
//     Copyright (c) Me!  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Fenrir
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Fenrir : Game
    {
        /// <summary>
        /// The game's ball, of which there will only be one
        /// </summary>
        private Ball ball;
        /// <summary>
        /// The game's paddle. Again, there will only be one of these
        /// </summary>
        private Paddle paddle;
        /// <summary>
        /// An array of bricks
        /// </summary>
        private Brick[,] bricks;
        /// <summary>
        /// The number of columns of bricks
        /// </summary>
        private const int BrickColumnCount = 16;
        /// <summary>
        /// The height of each brick
        /// </summary>
        private const int BrickHeight = 20;
        /// <summary>
        /// The width of each brick
        /// </summary>
        private const int BrickWidth = 50;
        /// <summary>
        /// The number of rows of bricks
        /// </summary>
        private const int BrickRowCount = 6;
        /// <summary>
        /// The colors to use for each row of bricks
        /// </summary>
        private readonly Color[] rowColors = new[] { Color.Red, Color.Blue, Color.Yellow, Color.Green, Color.Purple, Color.Orange };
        /// <summary>
        /// Our graphics device manager
        /// </summary>
        GraphicsDeviceManager graphics;
        /// <summary>
        /// The size of the play field
        /// </summary>
        private Rectangle screenBounds;
        /// <summary>
        /// Our SpriteBatch for managing all of our many sprites
        /// </summary>
        SpriteBatch spriteBatch;

        public Fenrir()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // get and save the bounds of the screen
            screenBounds = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            paddle = new Paddle(Content.Load<Texture2D>("paddle"));
            // put the paddle in the middle of the screen
            paddle.Position = new Vector2((screenBounds.Width - paddle.Texture.Width) / 2f, screenBounds.Height - paddle.Texture.Height - 5);
            // a direction of 1,-1 will set the ball moving up and to the right
            ball = new Ball(Content.Load<Texture2D>("ball")) { Direction = new Vector2(1, -1), Speed = 5 };
            ball.Position = new Vector2(paddle.Position.X + ((paddle.Texture.Width - ball.Texture.Width) / 2f), paddle.Position.Y - ball.Texture.Height - 1);
            // an array of bricks
            bricks = new Brick[BrickColumnCount, BrickRowCount];
            for (var columnIndex = 0; columnIndex < BrickColumnCount; ++columnIndex)
            {
                for (var rowIndex = 0; rowIndex < BrickRowCount; ++rowIndex)
                {
                    bricks[columnIndex, rowIndex] = new Brick(Content.Load<Texture2D>("brick")) { Position = new Vector2(columnIndex * BrickWidth, rowIndex * BrickHeight + 30), InPlay = true };
                }
            }

            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // Unload non-ContentManager content
            spriteBatch.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // exit the game if the gamepad's back button is pressed or if esc is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // set the paddle's new position. NOTE: the paddle only moves horizontally. its Y position is fixed
            var newPaddlePosition = new Vector2(Mouse.GetState().X, screenBounds.Height - paddle.Texture.Height - 5);
            // ensure that the paddle stays inside the window
            if (newPaddlePosition.X < 0)
            {
                newPaddlePosition.X = 0;
            }
            if (newPaddlePosition.X + paddle.Texture.Width > screenBounds.Width)
            {
                newPaddlePosition.X = screenBounds.Width - paddle.Texture.Width;
            }
            paddle.Position = newPaddlePosition;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // set background color to black
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            // draw the bricks
            for (int columnIndex = 0; columnIndex < BrickColumnCount; ++columnIndex)
            {
                for (int rowIndex = 0; rowIndex < BrickRowCount; ++rowIndex)
                {
                    if (bricks[columnIndex, rowIndex].InPlay)
                    {
                        spriteBatch.Draw(bricks[columnIndex, rowIndex].Texture, bricks[columnIndex, rowIndex].Position, rowColors[rowIndex]);
                    }
                }
            }
            // draw the ball
            spriteBatch.Draw(ball.Texture, ball.Position, Color.White);
            // draw the paddle
            spriteBatch.Draw(paddle.Texture, paddle.Position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
