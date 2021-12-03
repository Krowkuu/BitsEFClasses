using System.Collections.Generic;
using System.Linq;
using System;

using NUnit.Framework;
using BitsEFClasses.Models;
using Microsoft.EntityFrameworkCore;

namespace BitsTests
{
    public class AppConfigTests
    {
        bitsContext dbContext;
        AppConfig appCon;
        List<AppConfig> appConfigs;

        [SetUp]
        public void Setup()
        {
            dbContext = new bitsContext();
        }

        [Test]
        public void CanAccessTest()
        {
            appConfigs = dbContext.AppConfigs.OrderBy(appCon => appCon.BreweryId).ToList();
            Assert.AreEqual(1, appConfigs.Count);
            Assert.AreEqual("Manifest", appConfigs[0].BreweryName);
        }

        [Test]
        public void GetByPrimaryKeyTest()
        {
            appCon = dbContext.AppConfigs.Find(1);
            Assert.IsNotNull(appCon);
            Assert.AreEqual(1, appCon.BreweryId);
            Console.WriteLine(appCon);
        }

        [Test]
        public void UpdateTest()
        {
            //I create, update, and delete in this test so that I don't mess up the database
            //but I want to make sure that I understand how updating works and that it can be updated

            #region create
            appCon = new AppConfig();
            appCon.BreweryId = 2;
            appCon.DefaultUnits = "metric";
            appCon.BreweryName = "TestBrewery";
            dbContext.AppConfigs.Add(appCon);
            dbContext.SaveChanges();
            Assert.IsNotNull(dbContext.AppConfigs.Find(2));
            #endregion


            appCon = dbContext.AppConfigs.Find(2);
            appCon.BreweryName = "Brewery Test";
            dbContext.AppConfigs.Update(appCon);
            dbContext.SaveChanges();
            appCon = dbContext.AppConfigs.Find(2);
            Assert.AreEqual("Brewery Test", appCon.BreweryName);

            #region delete

            appCon = dbContext.AppConfigs.Find(2);
            dbContext.AppConfigs.Remove(appCon);
            dbContext.SaveChanges();
            Assert.IsNull(dbContext.AppConfigs.Find(2));

            #endregion
        }
    }
}