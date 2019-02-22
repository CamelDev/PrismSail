using System;
using NUnit.Framework;

namespace UserInterface
{
    public abstract class specification
    {
        protected Exception ExceptionThrown;
        protected bool ScenarioExpectsException;

        [OneTimeSetUp]
        public void Setup()
        {
            InitializeState();
            EstablishContext();
            try
            {
                When();
                AfterWhen();
            }
            catch (Exception e)
            {
                TearDown();
                if (!ScenarioExpectsException) throw;

                ExceptionThrown = e;
            }
        }

        protected virtual void AfterWhen()
        {
        }

        protected virtual void InitializeState()
        {
        }

        protected virtual void EstablishContext()
        {
        }

        protected virtual void When()
        {
        }

        [OneTimeTearDown]
        protected virtual void TearDown()
        {
        }
    }
}