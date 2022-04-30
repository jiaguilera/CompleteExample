using CompleteExample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CompleteExample.Logic.Tests
{
    public class UnitTest1
    {
        private CompleteExampleDBContext _context;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

            var optionBuilder = new DbContextOptionsBuilder<CompleteExampleDBContext>();
            optionBuilder.UseSqlServer(config.GetConnectionString("SchoolContext"));
            _context = new CompleteExampleDBContext(optionBuilder.Options);

        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test()
        {
        }
    }
}