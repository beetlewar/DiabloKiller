using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Engine.Tests
{
    [TestFixture]
    public class SimpleRandomizerTests
    {
        [Test]
        public void RandomizeBool_ProviderZeroChance_AlwaysReturnsFalse()
        {
            for (int i = 0; i < 100; ++i)
            {
                Assert.False(new SimpleRandomizer().RandomizeBool(0));
            }
        }

        [Test]
        public void RandomizeBool_ProviderOneChance_AlwaysReturnsTrue()
        {
            for (int i = 0; i < 100; ++i)
            {
                Assert.True(new SimpleRandomizer().RandomizeBool(1));
            }
        }

        [TestCase(-1)]
        [TestCase(1.1f)]
        public void RandomizeBool_ChanceOutOfRange_ThrowsEngineException(float chance)
        {
            Assert.Throws<EngineException>(() => new SimpleRandomizer().RandomizeBool(chance));
        }

        [Test]
        public void RandomizeBool_FiftyPercent_ReturnsBothTrueAndFalse()
        {
            bool bFalse = false;
            bool bTrue = false;

            var rnd = new SimpleRandomizer();
            for(int i = 0; i < 100000; ++i)
            {
                if(rnd.RandomizeBool(0.5f))
                {
                    bTrue = true;
                }
                else
                {
                    bFalse = true;
                }

                if(bFalse && bTrue)
                {
                    Assert.Pass();
                }
            }

            Assert.Fail();
        }

        [Test]
        public void RandomizeInt_ProviderRange_ReturnsAllValuesFromTheRange()
        {
            var bFirst = false;
            var bSecond = false;
            var bThird = false;

            var rnd = new SimpleRandomizer();

            for (int i = 0; i < 100000; ++i )
            {
                var result = rnd.RandomizeInt(5, 7);
                switch(result)
                {
                    case 5:
                        bFirst = true;
                        break;
                    case 6:
                        bSecond = true;
                        break;
                    case 7:
                        bThird = true;
                        break;
                    default:
                        // это значение не ожидалось
                        Assert.Fail();
                        break;
                }

                if(bFirst && bSecond && bThird)
                {
                    Assert.Pass();
                }
            }

                Assert.Fail();
        }
    }
}
