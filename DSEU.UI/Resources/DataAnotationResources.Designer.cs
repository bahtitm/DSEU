﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DSEU.UI.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class DataAnotationResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DataAnotationResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DSEU.UI.Resources.DataAnotationResources", typeof(DataAnotationResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos;  и &apos;{1}&apos; не совпадают.
        /// </summary>
        public static string CompareAttribute_MustMatch {
            get {
                return ResourceManager.GetString("CompareAttribute_MustMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Поле {0} не является действующим электронным адресом  {1}.
        /// </summary>
        public static string EmailAddressAttribute_Invalid {
            get {
                return ResourceManager.GetString("EmailAddressAttribute_Invalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Поле {0} должно быть в виде ряда или строя с максимальной длиной  {1}.
        /// </summary>
        public static string MaxLengthAttribute_ValidationError {
            get {
                return ResourceManager.GetString("MaxLengthAttribute_ValidationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Поле {0} должно быть в виде ряда или строя с минимальной длиной  {1}.
        /// </summary>
        public static string MinLengthAttribute_ValidationError {
            get {
                return ResourceManager.GetString("MinLengthAttribute_ValidationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Пароль.
        /// </summary>
        public static string Password {
            get {
                return ResourceManager.GetString("Password", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Поле {0} не является действующим телефонным номером.
        /// </summary>
        public static string PhoneAttribute_Invalid {
            get {
                return ResourceManager.GetString("PhoneAttribute_Invalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Пример должен быть построен в виде действующего стандартного выражения.
        /// </summary>
        public static string RegularExpressionAttribute_Empty_Pattern {
            get {
                return ResourceManager.GetString("RegularExpressionAttribute_Empty_Pattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Требуется поле {0}.
        /// </summary>
        public static string RequiredAttribute_ValidationError {
            get {
                return ResourceManager.GetString("RequiredAttribute_ValidationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Максимальная длина должна быть неотрицательное целое число.
        /// </summary>
        public static string StringLengthAttribute_InvalidMaxLength {
            get {
                return ResourceManager.GetString("StringLengthAttribute_InvalidMaxLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Поле {0} должно быть в виде  ряда с максимальной длиной  {1}.
        /// </summary>
        public static string StringLengthAttribute_ValidationError {
            get {
                return ResourceManager.GetString("StringLengthAttribute_ValidationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Длина {0} должна быть не менее {2} и не более {1} символов..
        /// </summary>
        public static string StringLengthAttribute_ValidationErrorIncludingMinimum {
            get {
                return ResourceManager.GetString("StringLengthAttribute_ValidationErrorIncludingMinimum", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Поле {0} не является действующим полноценным http, https или ftp URL..
        /// </summary>
        public static string UrlAttribute_Invalid {
            get {
                return ResourceManager.GetString("UrlAttribute_Invalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Логин.
        /// </summary>
        public static string UserName {
            get {
                return ResourceManager.GetString("UserName", resourceCulture);
            }
        }
    }
}
