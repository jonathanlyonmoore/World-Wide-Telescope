﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

extern alias Silverlight;
using System.ComponentModel;
using System.Windows.Controls.Design.Common;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.PropertyEditing;
using SSWC = Silverlight::System.Windows.Controls;

namespace System.Windows.Controls.Input.Design
{
    /// <summary>
    /// To register design time metadata for SSWC.TimeUpDown.
    /// </summary>
    internal class TimeUpDownMetadata : AttributeTableBuilder
    {
        /// <summary>
        /// To register design time metadata for SSWC.TimeUpDown.
        /// </summary>
        public TimeUpDownMetadata()
            : base()
        {
            AddCallback(
                typeof(SSWC.TimeUpDown),
                b =>
                {
                    b.AddCustomAttributes(new DefaultPropertyAttribute(Extensions.GetMemberName<SSWC.TimeUpDown>(x => x.Value)));
                    b.AddCustomAttributes(new DefaultEventAttribute("ValueChanged"));
                });
        }
    }
}
