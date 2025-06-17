using System;
using NUnit.Framework;

namespace Plants
{
    public class PotTests
    {
        [Test]
        public void NewPotIsEmpty()
        {
            Assert.That(new Pot().IsEmpty, Is.True);
        }

        [Test]
        public void NewPotIsNotWet()
        {
            Assert.That(new Pot().IsWet, Is.False);
        }
        
        [Test]
        public void SowSeed_SoPotIsNotEmpty()
        {
            var pot = new Pot();
            pot.SowSeed("anySeed");
            Assert.That(pot.IsEmpty, Is.False);
        }
        
        [Test]
        public void WateringPot_WetsIt()
        {
            var pot = new Pot();
            pot.SowSeed("anySeed");
            
            pot.Water();
            
            Assert.That(pot.IsWet, Is.True);
        }

        [Test]
        public void WetPot_AfterEnoughTime_IsNotWetAnymore()
        {
            var pot = new Pot();
            pot.SowSeed("anySeed");
            pot.Water();

            pot.PassTime(TimeSpan.FromDays(0.5));
            pot.PassTime(TimeSpan.FromDays(0.6));
            
            Assert.That(pot.IsWet, Is.False);
        }

        [Test]
        public void WetPot_AfterNotEnoughTime_IsStillWet()
        {
            var pot = new Pot();
            pot.SowSeed("anySeed");
            pot.Water();

            pot.PassTime(TimeSpan.FromDays(1));
            
            Assert.That(pot.IsWet, Is.True);
        }
        
        [Test]
        public void WaterAgain_AfterThePotBecameDry_WetsThePot()
        {
            var pot = new Pot();
            pot.SowSeed("anySeed");
            pot.Water();
            pot.PassTime(TimeSpan.FromDays(2));
            
            pot.Water();
            pot.PassTime(TimeSpan.FromDays(.5));
            
            Assert.That(pot.IsWet, Is.True);
        }
        
        [Test]
        public void InWetPotWithSeed_AfterSomeTime_SproutSpawns()
        {
            var pot = new Pot();
            pot.SowSeed("anySeed");
            pot.Water();
            
            pot.PassTime(TimeSpan.FromDays(1));
            
            Assert.That(pot.HasSprout, Is.True);
        }
        
        [Test]
        public void InDryPotWithSeed_AfterSomeTime_NoSproutSpawns()
        {
            var pot = new Pot();
            pot.SowSeed("anySeed");
            
            pot.PassTime(TimeSpan.FromDays(1));
            
            Assert.That(pot.HasSprout, Is.False);
        }
        
        [Test, Ignore("TODO: Implement this test")]
        public void InWetPotWithSeed_AfterNotEnoughTime_NoSproutSpawns()
        {
            var pot = new Pot();
            pot.SowSeed("anySeed");
            pot.Water();
            
            pot.PassTime(TimeSpan.FromDays(0.5));
            
            Assert.That(pot.HasSprout, Is.False);
        }
    }
}