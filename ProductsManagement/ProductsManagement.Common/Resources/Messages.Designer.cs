﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductsManagement.Common.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ProductsManagement.Common.Resources.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to Producto creado exitosamente.
        /// </summary>
        public static string ProductCreated {
            get {
                return ResourceManager.GetString("ProductCreated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Producto eliminado exitosamente.
        /// </summary>
        public static string ProductDeleted {
            get {
                return ResourceManager.GetString("ProductDeleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Producto no encontrado.
        /// </summary>
        public static string ProductNotFound {
            get {
                return ResourceManager.GetString("ProductNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Producto actualizado exitosamente.
        /// </summary>
        public static string ProductUpdated {
            get {
                return ResourceManager.GetString("ProductUpdated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuario creado exitosamente.
        /// </summary>
        public static string UserCreated {
            get {
                return ResourceManager.GetString("UserCreated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error en la creación del usuario. Verifica los datos del usuario e intenta de nuevo.
        /// </summary>
        public static string UserCreationError {
            get {
                return ResourceManager.GetString("UserCreationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El usuario ya existe.
        /// </summary>
        public static string UserExists {
            get {
                return ResourceManager.GetString("UserExists", resourceCulture);
            }
        }
    }
}
