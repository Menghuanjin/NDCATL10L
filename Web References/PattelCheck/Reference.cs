﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.42000 版自动生成。
// 
#pragma warning disable 1591

namespace ND.PattelCheck {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MiCheckProcessLotServiceBinding", Namespace="http://celltestintegration.ws.atlmes.com/")]
    public partial class MiCheckProcessLotServiceService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback miCheckProcessLotOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MiCheckProcessLotServiceService() {
            this.Url = global::ND.Properties.Settings.Default.NDL10_PattelCheck_MiCheckProcessLotServiceService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event miCheckProcessLotCompletedEventHandler miCheckProcessLotCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("miCheckProcessLotResponse", Namespace="http://celltestintegration.ws.atlmes.com/")]
        public miCheckProcessLotResponse miCheckProcessLot([System.Xml.Serialization.XmlElementAttribute("miCheckProcessLot", Namespace="http://celltestintegration.ws.atlmes.com/")] miCheckProcessLot miCheckProcessLot1) {
            object[] results = this.Invoke("miCheckProcessLot", new object[] {
                        miCheckProcessLot1});
            return ((miCheckProcessLotResponse)(results[0]));
        }
        
        /// <remarks/>
        public void miCheckProcessLotAsync(miCheckProcessLot miCheckProcessLot1) {
            this.miCheckProcessLotAsync(miCheckProcessLot1, null);
        }
        
        /// <remarks/>
        public void miCheckProcessLotAsync(miCheckProcessLot miCheckProcessLot1, object userState) {
            if ((this.miCheckProcessLotOperationCompleted == null)) {
                this.miCheckProcessLotOperationCompleted = new System.Threading.SendOrPostCallback(this.OnmiCheckProcessLotOperationCompleted);
            }
            this.InvokeAsync("miCheckProcessLot", new object[] {
                        miCheckProcessLot1}, this.miCheckProcessLotOperationCompleted, userState);
        }
        
        private void OnmiCheckProcessLotOperationCompleted(object arg) {
            if ((this.miCheckProcessLotCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.miCheckProcessLotCompleted(this, new miCheckProcessLotCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://celltestintegration.ws.atlmes.com/")]
    public partial class miCheckProcessLot {
        
        private checkProcessLotRequest requestField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public checkProcessLotRequest Request {
            get {
                return this.requestField;
            }
            set {
                this.requestField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://celltestintegration.ws.atlmes.com/")]
    public partial class checkProcessLotRequest {
        
        private string siteField;
        
        private string processLotField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string site {
            get {
                return this.siteField;
            }
            set {
                this.siteField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string processLot {
            get {
                return this.processLotField;
            }
            set {
                this.processLotField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://celltestintegration.ws.atlmes.com/")]
    public partial class checkProcessLotResponse {
        
        private string codeField;
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://celltestintegration.ws.atlmes.com/")]
    public partial class miCheckProcessLotResponse {
        
        private checkProcessLotResponse returnField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public checkProcessLotResponse @return {
            get {
                return this.returnField;
            }
            set {
                this.returnField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void miCheckProcessLotCompletedEventHandler(object sender, miCheckProcessLotCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class miCheckProcessLotCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal miCheckProcessLotCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public miCheckProcessLotResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((miCheckProcessLotResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591