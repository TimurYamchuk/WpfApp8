﻿using System.Windows.Media;

namespace WpfApp8.Models
{
    public class ColorModel
    {
        public SolidColorBrush Color { get; set; }
        public string HexValue => Color.Color.ToString();
    }
}
