﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlazingPizza.ComponentsLibrary.Map
{
    public class Marker
    {
        public string Description { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public bool ShowPopup { get; set; }
    }
}
