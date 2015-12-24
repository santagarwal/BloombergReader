//------------------------------------------
// ArrowEnds.cs (c) 2007 by Charles Petzold
// http://www.charlespetzold.com/blog/2007/04/191200.html
//------------------------------------------
using System;

namespace BloombergReader.View.Shapes
{
    /// <summary>
    ///     Indicates which end of the line has an arrow.
    /// </summary>
    [Flags]
    public enum ArrowEnds
    {
        None = 0,
        Start = 1,
        End = 2,
        Both = 3
    }
}