namespace NUnit.Test.MyTests

module testmodule =

    open NUnit.Framework
    open MyProject.MyFunctions

    [<TestFixture>]
    type myFixture() =

        [<Test>]
        member self.myTest() =
            Assert.AreEqual("hello world!", sayHello "world!")

        [<Test>]
        member self.otherTest() =
            Assert.AreEqual("hello jupiter", sayHello "sun")


