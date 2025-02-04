﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberGear_Control_.NET
{
    // Funciones numericas para transformar tipos de datos a valores.
    /// <summary>
    /// 提供数学计算功能的类，用于CyberGear控制系统中的数据处理。
    /// </summary>
    /// <remarks>
    /// 包括将输入值映射到指定范围的功能，以及可能的其他数学操作。
    /// 主要用于处理和转换控制系统中的信号和数据。
    /// </remarks>
    internal class Calculate
    {
        // 用于将输入映射到0到65535的范围，val为输入值
        public static uint FToU(double val, double xmin, double xmax)
        {
            // 计算目标区间和原始区间的长度
            double targetRange = xmax - xmin;
            double originalRange = 65535 - 1; // 0到65535

            // 确保val值在xmin到xmax之间
            if (val < xmin || val > xmax)
            {
                throw new ArgumentOutOfRangeException(nameof(val), $"Value must be between {xmin} and {xmax}.");
            }

            // 计算比例因子
            double scaleFactor = originalRange / targetRange;

            // 应用映射
            double mappedValue = (val - xmin) * scaleFactor;

            // 四舍五入并转换为整数
            return (uint)Math.Round(mappedValue);
        }

        // 用于将输入映射到0到65535的范围，x为输入值
        public static double UToF(int x, double xmin, double xmax)
        {
            // 确保x值在0到65535之间
            if (x < 0 || x > 65535)
            {
                throw new ArgumentOutOfRangeException(nameof(x), "x must be between 0 and 65535.");
            }

            // 计算原始区间和目标区间的长度
            double originalRange = 65535; // 0到65535
            double targetRange = xmax - xmin;
            // 计算比例因子
            double scaleFactor = targetRange / originalRange;
            // 应用映射
            double mappedValue = (x * scaleFactor) + xmin;
            // 四舍五入并转换为整数
            return mappedValue;
        }
    }
}
