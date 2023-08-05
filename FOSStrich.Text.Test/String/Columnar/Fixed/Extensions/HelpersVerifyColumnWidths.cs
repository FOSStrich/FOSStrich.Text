﻿namespace FOSStrich.Text;

public class StringFixedExtensionsTests_VerifyColumnWidths
{
    [Fact]
    public void Basic()
    {
        foreach (int count in Enumerable.Range(1, 10))
            StringFixedExtensions.VerifyColumnWidths(Enumerable.Range(1, count).ToArray());
    }

    [Fact]
    public void Exceptions()
    {
        Action act = null;

        act = () => StringFixedExtensions.VerifyColumnWidths(null);
        act.Should().Throw<ArgumentNullException>();

        act = () => StringFixedExtensions.VerifyColumnWidths(Array.Empty<int>());
        act.Should().Throw<ArgumentException>();

        act = () => StringFixedExtensions.VerifyColumnWidths(new[] { 0 });
        act.Should().Throw<ArgumentOutOfRangeException>("WidthEqualToZero");

        act = () => StringFixedExtensions.VerifyColumnWidths(new[] { 0, 1 });
        act.Should().Throw<ArgumentOutOfRangeException>("WidthEqualToZero");

        act = () => StringFixedExtensions.VerifyColumnWidths(new[] { 1, 0 });
        act.Should().Throw<ArgumentOutOfRangeException>("WidthEqualToZero");

        act = () => StringFixedExtensions.VerifyColumnWidths(new[] { -1 });
        act.Should().Throw<ArgumentOutOfRangeException>("WidthLessThanZero");

        act = () => StringFixedExtensions.VerifyColumnWidths(new[] { -1, 1 });
        act.Should().Throw<ArgumentOutOfRangeException>("WidthLessThanZero");

        act = () => StringFixedExtensions.VerifyColumnWidths(new[] { 1, -1 });
        act.Should().Throw<ArgumentOutOfRangeException>("WidthLessThanZero");
    }
}