using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HowMuch
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Keep track of the current number
        int counter;
        //Keep track of old keyboard state
        KeyboardState oldKB;

        SpriteFont font;

        int number1;
        int number2;
        int number3;

        string myString1;
        string myString2;
        string myString3;

        int timer = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            oldKB = Keyboard.GetState();
            //set the initial value to 0
            counter = 0;
            //Initialize values for each digit
            number1 = 0;
            number2 = 0;
            number3 = 0;
            //Initialize the string,so they can be displayed
            myString1 = number1.ToString();
            myString2 = number2.ToString();
            myString3 = number3.ToString();

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

            // TODO: use this.Content to load your game content here
            //Load the font
            font = this.Content.Load<SpriteFont>("SpriteFont1");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Get the current keyboard state
            KeyboardState kb = Keyboard.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            //If the key is pressed increment counter,this also requires key to be pressed each time rather than allowing for a long press
            if (kb.IsKeyDown(Keys.Up) && !oldKB.IsKeyDown(Keys.Up))
            {
                //Make the number bigger
                counter++;
                number1++;
            }

            if (kb.IsKeyDown(Keys.Down) && !oldKB.IsKeyDown(Keys.Down))
            {
                //Make the number smaller
                counter--;
                number1--;
            }
            //Set max number to 10
            if (counter > 10)
            {
                counter = 10;
            }
            //Set min number to -10
            if (counter < -10)
            {
                counter = -10;
            }
            //Set the old keyboard to the current one,so they can be compared on the next call of Update
            oldKB = kb;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Create the myCounter String,and pad it with zeros
            string myCounter = " " + counter.ToString().PadLeft(2, '0');
            //If the number is negative,add a negative symbol along with the padding
            if (myCounter.Substring(1, 1) == "-")
            {
                myCounter = "-" + counter.ToString().Replace("-", "").PadLeft(2, '0');
            }
            //get all three digits
            string myString1 = myCounter.Substring(2, 1);
            string myString2 = myCounter.Substring(1, 1);
            string myString3 = myCounter.Substring(0, 1);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //Draw all of the digits in black with the Font "font"
            spriteBatch.DrawString(font, myString3, new Vector2(250, 100), Color.Black);
            spriteBatch.DrawString(font, myString2, new Vector2(350, 100), Color.Black);
            spriteBatch.DrawString(font, myString1, new Vector2(450, 100), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
