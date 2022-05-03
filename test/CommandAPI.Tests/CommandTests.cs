using System;
using Xunit;
using CommandAPI.Models;

namespace CommandAPI.Tests;

public class CommandTests
{
    [Fact]
    public void CanChangeHowTo()
    {
        //Arrange
        var testCommand = new Command
        {
            HowTo = "Do something awesome",
            Platform = "xUnit",
            CommandLine = "dotnet test"
        };
        //Act
        testCommand.HowTo = "Execute Unit Tests";
        //Assert
        Assert.Equal("Execute Unit Tests", testCommand.HowTo);
    }
}