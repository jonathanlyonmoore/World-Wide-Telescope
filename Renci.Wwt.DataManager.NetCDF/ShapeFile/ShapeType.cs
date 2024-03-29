﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renci.Wwt.DataManager.NetCDF.ShapeFile
{
    public enum ShapeType
    {
        Null = 0,
        Point = 1,
        PolyLine = 3,
        Polygon = 5,
        MultiPoint = 8,
        PointZ = 11,
        PolyLineZ = 13,
        PolygonZ = 15,
        MultiPointZ = 18,
        PointM = 21,
        PolyLineM = 23,
        PolygonM = 25,
        MultiPointM = 28,
        MultiPatch = 31,
    }
}
