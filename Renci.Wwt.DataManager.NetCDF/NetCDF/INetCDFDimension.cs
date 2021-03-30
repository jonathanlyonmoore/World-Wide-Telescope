//*********************************************************
//
//    Copyright (c) Microsoft. All rights reserved.
//    This code is licensed under the Apache License, Version 2.0.
//    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
//    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
//    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
//    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Research.ScientificWorkflow.NetCDF.CSharpAPI
{
    public interface INetCDFDimension
    {
        string Name { get; }

        uint Length { get; }

        /// <summary>
        /// Returns true if the Dimension is a Record Dimension.
        /// </summary>
        bool IsRecordDimension { get; }
    }
}
