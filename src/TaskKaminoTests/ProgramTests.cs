using TaskKamino;

namespace TaskKaminoTests;

public class ProgramTests
{
    [Theory()]
    [InlineData(new[] { 3, 2, 4 }, 6)]
    [InlineData(new[] { 2, 7, 11, 15 }, 9)]
    [InlineData(new[] { 3, 3 }, 6)]
    public void Test(int[] nums, int expectedTarget)
    {
        //act
        var result = ArrayUtils.GetIndexes(nums, expectedTarget);
        int target = nums[result.Item1] + nums[result.Item2];
        
        //assert
        Assert.Equal(expectedTarget, target);
    }

    [Fact()]
    public void GetIndexes_ShouldThrowArgumentException_WhenArrayIsNull()
    {
        //arrange
        int[] nums = null;
        int target = 1;

        //act
        var exception = Assert.Throws<ArgumentException>(() => ArrayUtils.GetIndexes(nums, target));

        //assert
        Assert.Equal("Array is null or empty (Parameter 'nums')", exception.Message);
    }

    
    [Fact]
    public void GetIndexes_ShouldThrowArgumentException_WhenArrayIsEmphty()
    {
        //arrange
        int[] array = {};
        int target = 1;

        //act
        var exception = Assert.Throws<ArgumentException>(() => ArrayUtils.GetIndexes(array, target));

        //assert
        Assert.Equal("Array is null or empty (Parameter 'nums')", exception.Message);
    }


    [Fact]

    public void GetIndexes_ShouldThrowArgumentException_WhenElementsNotFound()
    {
        //arrange
        int[] nums2 = { 6, 2, 3, 5 };
        int target = 1;
        
        //act
        var exception = Assert.Throws<ArgumentException>(() => ArrayUtils.GetIndexes(nums2, target));
        
        //assert
        Assert.Equal("No elements were found whose sum is equal to target (Parameter 'nums')", exception.Message);
    }
}