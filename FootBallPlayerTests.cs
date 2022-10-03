using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Tests
{
    [TestClass()]
    public class FootBallPlayerTests
    {
        private FootBallPlayer player = new FootBallPlayer(1, "Bob", 23, 9);
        private FootBallPlayer playerNullName = new FootBallPlayer(1, null, 23, 9);
        private FootBallPlayer playerShortName = new FootBallPlayer(1, "", 23, 9);
        private FootBallPlayer playerUnderAge = new FootBallPlayer(1, "Bob", 0, 9);
        private FootBallPlayer playerShirtnumberTooLow = new FootBallPlayer(1, "Bob", 23, 0);
        private FootBallPlayer playerShirtnumberTooHigh = new FootBallPlayer(1, "Bob", 23, 999);
        //Declaring test cases to be global to be able to call the specific test case in a specific testmethod
        [TestMethod()]
        public void FootBallPlayerTest()
        {
            var player = new FootBallPlayer();
            Assert.IsNotNull(player);
            //testing if footballplayer object is created and asserting that the newly created player is not null
        }

        [TestMethod()]
        public void FootBallPlayerTest1()
        {
            
            Assert.IsNotNull(player);
            //Asserting first that a global palyer with defined properties is no null
            Assert.IsNotNull(playerNullName);
            //Asserting that if a player whose name value is null does not mean the entire object is null
        }

        [TestMethod()]
        public void ToStringTest()
        {
            
            string tString = player.ToString();
            Assert.AreEqual("1Bob239", tString);
            //Testing the tostring() method, asserting that global player's values are equal to the players'.tostring method call
        }

        [TestMethod()]
        public void AgeValidatorTest()
        {
            player.AgeValidator();
            
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => playerUnderAge.AgeValidator());
            //by running the agevalidator method on player first, we validate a working and correct player, after we assert that if a player has an age that is under the limit, exception is thrown
        }

        [TestMethod()]
        public void NameValidatorTest()
        {
            player.NameValidator();
            Assert.ThrowsException<ArgumentNullException>(() => playerNullName.NameValidator());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => playerShortName.NameValidator());
            //Assert null exception for a player who has a null name, and an out of range exception for a player with a name that is too short
        }

        [TestMethod()]
        public void ShirtNumberValidatorTest()
        {
            player.ShirtNumberValidator();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => playerShirtnumberTooLow.ShirtNumberValidator());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => playerShirtnumberTooHigh.ShirtNumberValidator());
            // Asserting with a players shirtnumber is either too low or too high, either will throw out of range exception
        }

        [TestMethod()]
        public void ValidatorTest()
        {
            player.Validator();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => playerShortName.Validator());
            Assert.ThrowsException<ArgumentNullException>(() => playerNullName.Validator());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => playerShirtnumberTooHigh.Validator());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => playerShirtnumberTooLow.Validator());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => playerUnderAge.Validator());
            //first showing happy path, in validating a player with no errors, after this checking if player name is either null or short, shirt number is too high or low, and if player is underage
        }
    }
}