﻿//-----------------------------------------------------------------------
// <copyright company="Microsoft" file="DataFormTests_AutoGeneration.cs">
//      (c) Copyright Microsoft Corporation.
//      This source is subject to the Microsoft Public License (Ms-PL).
//      Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//      All other rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System.Windows.Controls.Primitives;

namespace System.Windows.Controls.UnitTests
{
    /// <summary>
    /// Tests <see cref="DataForm"/> autogeneration.
    /// </summary>
    [TestClass]
    public class DataFormTests_AutoGeneration : DataFormTests_Base
    {
        #region Helper Properties

        /// <summary>
        /// Gets the <see cref="DataForm"/> app.
        /// </summary>
        private DataFormApp_AutoGeneration DataFormApp
        {
            get
            {
                return this.DataFormAppBase as DataFormApp_AutoGeneration;
            }
        }

        /// <summary>
        /// Gets the <see cref="DataForm"/>.
        /// </summary>
        private DataForm DataForm
        {
            get
            {
                return this.DataFormApp.dataForm;
            }
        }

        #endregion Helper Properties

        #region Initialization

        /// <summary>
        /// Initializes the test framework.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            this.DataFormAppBase = new DataFormApp_AutoGeneration();
        }

        #endregion Initialization

        /// <summary>
        /// Ensure that fields are autogenerated properly.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that fields are autogenerated properly.")]
        public void AutoGenerateFields()
        {
            this.EnqueueCallback(() =>
            {
                this.DataForm.CurrentItem = new DataClass();
            });

            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                Assert.AreEqual(5, this.DataForm.Fields.Count);
                Binding[] bindings = this.GetBindings();

                Assert.AreEqual("BoolProperty", bindings[0].Path.Path);
                Assert.IsTrue(bindings[0].ValidatesOnExceptions);
                Assert.IsTrue(bindings[0].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[0].Content, typeof(CheckBox));

                Assert.AreEqual("DateTimeProperty", bindings[1].Path.Path);
                Assert.IsTrue(bindings[1].ValidatesOnExceptions);
                Assert.IsTrue(bindings[1].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[1].Content, typeof(DatePicker));

                Assert.AreEqual("IntProperty", bindings[2].Path.Path);
                Assert.IsTrue(bindings[2].ValidatesOnExceptions);
                Assert.IsTrue(bindings[2].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[2].Content, typeof(TextBox));

                Assert.AreEqual("IntPropertyWithoutAutoGenerateField", bindings[3].Path.Path);
                Assert.IsTrue(bindings[3].ValidatesOnExceptions);
                Assert.IsTrue(bindings[3].NotifyOnValidationError);

                Assert.IsInstanceOfType(this.DataForm.Fields[3].Content, typeof(TextBox));

                Assert.AreEqual("StringProperty", bindings[4].Path.Path);
                Assert.IsTrue(bindings[4].ValidatesOnExceptions);
                Assert.IsTrue(bindings[4].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[4].Content, typeof(TextBox));
            });

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that fields are autogenerated properly with AutoGeneratingField.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that fields are autogenerated properly with AutoGeneratingField.")]
        public void AutoGenerateFieldsWithAutoGeneratingField()
        {
            this.EnqueueCallback(() =>
            {
                this.DataForm.AutoGeneratingField += new EventHandler<DataFormAutoGeneratingFieldEventArgs>(OnDataFormAutoGeneratingField);
                this.DataForm.CurrentItem = new DataClassAllTwoWayBindings();
            });

            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                Assert.AreEqual(3, this.DataForm.Fields.Count);
                Binding[] bindings = this.GetBindings();

                Assert.AreEqual("DateTimeProperty", bindings[0].Path.Path);
                Assert.IsTrue(bindings[0].ValidatesOnExceptions);
                Assert.IsTrue(bindings[0].NotifyOnValidationError);

                Assert.AreEqual("IntProperty", bindings[1].Path.Path);
                Assert.IsTrue(bindings[1].ValidatesOnExceptions);
                Assert.IsTrue(bindings[1].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[1].Content, typeof(ComboBox));

                Assert.AreEqual("StringProperty", bindings[2].Path.Path);
                Assert.IsTrue(bindings[2].ValidatesOnExceptions);
                Assert.IsTrue(bindings[2].NotifyOnValidationError);
            });

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that fields are autogenerated properly with an enum property.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that fields are autogenerated properly with an enum property.")]
        public void AutoGenerateFieldsWithEnum()
        {
            this.EnqueueCallback(() =>
            {
                this.DataForm.CurrentItem = new DataClassWithEnum() { EnumProperty = DataEnum.SecondValue };
            });

            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                Assert.AreEqual(6, this.DataForm.Fields.Count);
                Binding[] bindings = this.GetBindings();

                Assert.AreEqual("BoolProperty", bindings[0].Path.Path);
                Assert.IsTrue(bindings[0].ValidatesOnExceptions);
                Assert.IsTrue(bindings[0].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[0].Content, typeof(CheckBox));

                Assert.AreEqual("DateTimeProperty", bindings[1].Path.Path);
                Assert.IsTrue(bindings[1].ValidatesOnExceptions);
                Assert.IsTrue(bindings[1].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[1].Content, typeof(DatePicker));

                Assert.AreEqual("EnumProperty", bindings[2].Path.Path);
                Assert.IsTrue(bindings[2].ValidatesOnExceptions);
                Assert.IsTrue(bindings[2].NotifyOnValidationError);

                ComboBox comboBox = this.DataForm.Fields[2].Content as ComboBox;
                Assert.IsNotNull(comboBox);
                Assert.AreEqual(1, comboBox.SelectedIndex);
                Assert.AreEqual("SecondValue", comboBox.SelectedItem);

                Assert.AreEqual("IntProperty", bindings[3].Path.Path);
                Assert.IsTrue(bindings[3].ValidatesOnExceptions);
                Assert.IsTrue(bindings[3].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[3].Content, typeof(TextBox));

                Assert.AreEqual("IntPropertyWithoutAutoGenerateField", bindings[4].Path.Path);
                Assert.IsTrue(bindings[4].ValidatesOnExceptions);
                Assert.IsTrue(bindings[4].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[4].Content, typeof(TextBox));

                Assert.AreEqual("StringProperty", bindings[5].Path.Path);
                Assert.IsTrue(bindings[5].ValidatesOnExceptions);
                Assert.IsTrue(bindings[5].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[5].Content, typeof(TextBox));
            });

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that fields are autogenerated properly with DisplayAttribute.Order.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that fields are autogenerated properly with DisplayAttribute.Order.")]
        public void AutoGenerateFieldsWithOrder()
        {
            this.EnqueueCallback(() =>
            {
                this.DataForm.CurrentItem = new DataClassWithOrder();
            });

            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                Assert.AreEqual(5, this.DataForm.Fields.Count);
                Binding[] bindings = this.GetBindings();

                Assert.AreEqual("IntPropertyWithoutAutoGenerateField", bindings[0].Path.Path);
                Assert.IsTrue(bindings[0].ValidatesOnExceptions);
                Assert.IsTrue(bindings[0].NotifyOnValidationError);

                Assert.AreEqual("StringProperty", bindings[1].Path.Path);
                Assert.IsTrue(bindings[1].ValidatesOnExceptions);
                Assert.IsTrue(bindings[1].NotifyOnValidationError);

                Assert.AreEqual("BoolProperty", bindings[2].Path.Path);
                Assert.IsTrue(bindings[2].ValidatesOnExceptions);
                Assert.IsTrue(bindings[2].NotifyOnValidationError);

                Assert.AreEqual("IntProperty", bindings[3].Path.Path);
                Assert.IsTrue(bindings[3].ValidatesOnExceptions);
                Assert.IsTrue(bindings[3].NotifyOnValidationError);

                Assert.AreEqual("DateTimeProperty", bindings[4].Path.Path);
                Assert.IsTrue(bindings[4].ValidatesOnExceptions);
                Assert.IsTrue(bindings[4].NotifyOnValidationError);
            });

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that fields are autogenerated properly with a list of strings.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that fields are autogenerated properly with a list of strings.")]
        public void AutoGenerateFieldsWithStringList()
        {
            this.EnqueueCallback(() =>
            {
                this.DataForm.ItemsSource = new List<string>() { "test string 0", "test string 1" };
            });

            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                Assert.AreEqual(1, this.DataForm.Fields.Count);
                Binding[] bindings = this.GetBindings();

                Assert.AreEqual(string.Empty, bindings[0].Path.Path);
                Assert.IsFalse(bindings[0].ValidatesOnExceptions);
                Assert.IsFalse(bindings[0].NotifyOnValidationError);

                TextBox textBox = this.DataFormInputControls[0] as TextBox;
                Assert.AreEqual("test string 0", textBox.Text);

                Assert.IsTrue(this.DataForm.Fields[0].IsReadOnly);
            });

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that the control within the first field gets focus when an edit is begin in autogeneration mode.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that the control within the first field gets focus when an edit is begin in autogeneration mode.")]
        public void EnsureFirstFieldGetsFocus()
        {
            this.EnqueueCallback(() =>
            {
                this.DataForm.CurrentItem = new DataClass();
            });

            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                this.ExpectContentLoaded();
                ButtonBase editButton = this.GetTemplatePart<ButtonBase>("EditButton");
                InvokeButton(editButton);
            });

            this.WaitForContentLoaded();

            this.EnqueueCallback(() =>
            {
                Assert.AreEqual(this.DataFormInputControls[0], FocusManager.GetFocusedElement());
            });

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that having a PagedCollectionView with grouping as the DataForm's items source does not cause the order of elements to change when navigating.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that having a PagedCollectionView with grouping as the DataForm's items source does not cause the order of elements to change when navigating.")]
        public void EnsureGroupingDoesNotChangeOrder()
        {
            this.EnqueueCallback(() =>
            {
                DataClassList dataClassList = DataClassList.GetDataClassList(2, ListOperations.All);
                PagedCollectionView pcv = new PagedCollectionView(dataClassList);
                pcv.GroupDescriptions.Add(new PropertyGroupDescription("StringProperty"));
                this.DataForm.ItemsSource = pcv;
                this.DataForm.AutoEdit = false;
            });

            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                Assert.AreEqual(5, this.DataForm.Fields.Count);
                Binding[] bindings = this.GetBindings();

                Assert.AreEqual("BoolProperty", bindings[0].Path.Path);
                Assert.IsTrue(bindings[0].ValidatesOnExceptions);
                Assert.IsTrue(bindings[0].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[0].Content, typeof(CheckBox));

                Assert.AreEqual("DateTimeProperty", bindings[1].Path.Path);
                Assert.IsTrue(bindings[1].ValidatesOnExceptions);
                Assert.IsTrue(bindings[1].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[1].Content, typeof(DatePicker));

                Assert.AreEqual("IntProperty", bindings[2].Path.Path);
                Assert.IsTrue(bindings[2].ValidatesOnExceptions);
                Assert.IsTrue(bindings[2].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[2].Content, typeof(TextBox));

                Assert.AreEqual("IntPropertyWithoutAutoGenerateField", bindings[3].Path.Path);
                Assert.IsTrue(bindings[3].ValidatesOnExceptions);
                Assert.IsTrue(bindings[3].NotifyOnValidationError);

                Assert.IsInstanceOfType(this.DataForm.Fields[3].Content, typeof(TextBox));

                Assert.AreEqual("StringProperty", bindings[4].Path.Path);
                Assert.IsTrue(bindings[4].ValidatesOnExceptions);
                Assert.IsTrue(bindings[4].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[4].Content, typeof(TextBox));

                this.ExpectContentLoaded();
                this.DataForm.CurrentIndex = 1;
            });

            this.WaitForContentLoaded();

            this.EnqueueCallback(() =>
            {
                Assert.AreEqual(5, this.DataForm.Fields.Count);
                Binding[] bindings = this.GetBindings();

                Assert.AreEqual("BoolProperty", bindings[0].Path.Path);
                Assert.IsTrue(bindings[0].ValidatesOnExceptions);
                Assert.IsTrue(bindings[0].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[0].Content, typeof(CheckBox));

                Assert.AreEqual("DateTimeProperty", bindings[1].Path.Path);
                Assert.IsTrue(bindings[1].ValidatesOnExceptions);
                Assert.IsTrue(bindings[1].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[1].Content, typeof(DatePicker));

                Assert.AreEqual("IntProperty", bindings[2].Path.Path);
                Assert.IsTrue(bindings[2].ValidatesOnExceptions);
                Assert.IsTrue(bindings[2].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[2].Content, typeof(TextBox));

                Assert.AreEqual("IntPropertyWithoutAutoGenerateField", bindings[3].Path.Path);
                Assert.IsTrue(bindings[3].ValidatesOnExceptions);
                Assert.IsTrue(bindings[3].NotifyOnValidationError);

                Assert.IsInstanceOfType(this.DataForm.Fields[3].Content, typeof(TextBox));

                Assert.AreEqual("StringProperty", bindings[4].Path.Path);
                Assert.IsTrue(bindings[4].ValidatesOnExceptions);
                Assert.IsTrue(bindings[4].NotifyOnValidationError);
                Assert.IsInstanceOfType(this.DataForm.Fields[4].Content, typeof(TextBox));
            });

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Trims out everything but letters from a string.
        /// </summary>
        private static string TrimNonLetters(string s)
        {
            return Regex.Replace(s, "[^a-zA-Z]", string.Empty);
        }

        /// <summary>
        /// Get the bindings on the <see cref="DataForm"/>.
        /// </summary>
        /// <returns>The bindings.</returns>
        private Binding[] GetBindings()
        {
            List<Binding> bindings = new List<Binding>();

            for (int i = 0; i < this.DataForm.Fields.Count; i++)
            {
                List<DataFormBindingInfo> bindingInfos = this.DataForm.Fields[i].GetDataFormBindingInfo(this.DataForm.CurrentItem, false /* twoWayOnly */, true /* searchChildren */);

                foreach (DataFormBindingInfo bindingInfo in bindingInfos)
                {
                    bindings.Add(bindingInfo.BindingExpression.ParentBinding);
                }
            }

            return bindings.ToArray();
        }

        /// <summary>
        /// Handles the situation where the <see cref="DataForm"/> auto-generates a field.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void OnDataFormAutoGeneratingField(object sender, DataFormAutoGeneratingFieldEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "BoolProperty":
                    e.Cancel = true;
                    break;

                case "IntProperty":
                    {
                        ComboBox comboBox = new ComboBox();
                        comboBox.ItemsSource = new IntCollection();
                        comboBox.SetBinding(ComboBox.SelectedItemProperty, new Binding("IntProperty") { Mode = BindingMode.TwoWay });
                        e.Field = new DataField() { Content = comboBox };
                    }

                    break;
            }
        }
    }
}
