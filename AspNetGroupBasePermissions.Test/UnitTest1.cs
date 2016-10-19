using Xunit;


namespace AspNetGroupBasePermissions.Test
{
   
    public class ExampleTestWithXUnit
    {
        [Theory]
        [InlineData(3)]
        public void FirstTExtWithXunitForFailer(int expected)
        {
            //arrange

            //act
            int x = 2 - expected;
            //assert
            Assert.NotEqual(expected, x);
        }
        [Theory]
        [InlineData(1)]
        public void FirstTExtWithXunitForPass(int expected)
        {
            //arrange

            //act
            int x = 2 - expected;
            //assert
            Assert.Equal(expected, x);
        }
    }
}
