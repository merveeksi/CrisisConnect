﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.CrossCuttingConcerns.Resources.Common.Localizations {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CommonLocalization_ru_RU {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CommonLocalization_ru_RU() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Core.CrossCuttingConcerns.Resources.Common.Localizations.CommonLocalization_ru_RU" +
                            "", typeof(CommonLocalization_ru_RU).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string GeneralValidationException {
            get {
                return ResourceManager.GetString("GeneralValidationException", resourceCulture);
            }
        }
        
        internal static string GeneralInternalServerException {
            get {
                return ResourceManager.GetString("GeneralInternalServerException", resourceCulture);
            }
        }
        
        internal static string ValidationIsRequired {
            get {
                return ResourceManager.GetString("ValidationIsRequired", resourceCulture);
            }
        }
        
        internal static string ValidationIsInvalid {
            get {
                return ResourceManager.GetString("ValidationIsInvalid", resourceCulture);
            }
        }
        
        internal static string ValidationMustBeBetween {
            get {
                return ResourceManager.GetString("ValidationMustBeBetween", resourceCulture);
            }
        }
        
        internal static string ValidationNotContainSpecialCharacters {
            get {
                return ResourceManager.GetString("ValidationNotContainSpecialCharacters", resourceCulture);
            }
        }
        
        internal static string ValidationDatetimeNotFuture {
            get {
                return ResourceManager.GetString("ValidationDatetimeNotFuture", resourceCulture);
            }
        }
    }
}
