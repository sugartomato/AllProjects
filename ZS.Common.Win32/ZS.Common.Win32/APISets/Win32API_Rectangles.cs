using System;
using System.Runtime.InteropServices;

namespace ZS.Common.Win32
{
    public partial class API
    {


        /// <summary>
        /// The POINT structure defines the x- and y- coordinates of a point.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>
            /// The x-coordinate of the point.
            /// </summary>
            public Int32 X { get; set; }
            /// <summary>
            /// The y-coordinate of the point.
            /// </summary>
            public Int32 Y { get; set; }

            /// <summary>
            /// 通过制定的坐标值构造一个新的POINT
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public POINT(Int32 x, Int32 y)
            {
                this.X = x;
                this.Y = y;
            }

            /// <summary>
            /// 通过System.Drawing.Point对象构造一个新的POINT
            /// </summary>
            /// <param name="pt"></param>
            public POINT(System.Drawing.Point pt) : this(pt.X, pt.Y) { }

            /// <summary>
            /// 提供POINT到System.Drawing.Point的隐式转换
            /// </summary>
            /// <param name="p"></param>
            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            /// <summary>
            /// 提供System.Drawing.Point到POINT的隐式转换
            /// </summary>
            /// <param name="pt"></param>
            public static implicit operator POINT(System.Drawing.Point pt)
            {
                return new POINT(pt.X, pt.Y);
            }
        }

		/// <summary>
		/// The RECT structure defines the coordinates of the upper-left and lower-right corners of a rectangle.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public Int32 left;
			public Int32 top;
			public Int32 right;
			public Int32 bottom;

			public override string ToString()
			{
				return String.Format("left:{0},top:{1},right:{2},bottom:{3}", this.left, this.top,this.right, this.bottom);
			}
		}




	}
}
