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

namespace ND.ChargeNumber {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="MiDataCollectForProcessLotForEachServiceBinding", Namespace="http://machineintegration.ws.atlmes.com/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(miCommonResponse))]
    public partial class MiDataCollectForProcessLotForEachServiceService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback miDataCollectForProcessLotForEachOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MiDataCollectForProcessLotForEachServiceService() {
            this.Url = global::ND.Properties.Settings.Default.NDL10_ChargeNumber_MiDataCollectForProcessLotForEachServiceService;
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
        public event miDataCollectForProcessLotForEachCompletedEventHandler miDataCollectForProcessLotForEachCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("miDataCollectForProcessLotForEachResponse", Namespace="http://machineintegration.ws.atlmes.com/")]
        public miDataCollectForProcessLotForEachResponse miDataCollectForProcessLotForEach([System.Xml.Serialization.XmlElementAttribute("miDataCollectForProcessLotForEach", Namespace="http://machineintegration.ws.atlmes.com/")] miDataCollectForProcessLotForEach miDataCollectForProcessLotForEach1) {
            object[] results = this.Invoke("miDataCollectForProcessLotForEach", new object[] {
                        miDataCollectForProcessLotForEach1});
            return ((miDataCollectForProcessLotForEachResponse)(results[0]));
        }
        
        /// <remarks/>
        public void miDataCollectForProcessLotForEachAsync(miDataCollectForProcessLotForEach miDataCollectForProcessLotForEach1) {
            this.miDataCollectForProcessLotForEachAsync(miDataCollectForProcessLotForEach1, null);
        }
        
        /// <remarks/>
        public void miDataCollectForProcessLotForEachAsync(miDataCollectForProcessLotForEach miDataCollectForProcessLotForEach1, object userState) {
            if ((this.miDataCollectForProcessLotForEachOperationCompleted == null)) {
                this.miDataCollectForProcessLotForEachOperationCompleted = new System.Threading.SendOrPostCallback(this.OnmiDataCollectForProcessLotForEachOperationCompleted);
            }
            this.InvokeAsync("miDataCollectForProcessLotForEach", new object[] {
                        miDataCollectForProcessLotForEach1}, this.miDataCollectForProcessLotForEachOperationCompleted, userState);
        }
        
        private void OnmiDataCollectForProcessLotForEachOperationCompleted(object arg) {
            if ((this.miDataCollectForProcessLotForEachCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.miDataCollectForProcessLotForEachCompleted(this, new miDataCollectForProcessLotForEachCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://machineintegration.ws.atlmes.com/")]
    public partial class miDataCollectForProcessLotForEach {
        
        private dataCollectForProcessLotForEachRequest dataCollectForProcessLotForEachRequestField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public dataCollectForProcessLotForEachRequest DataCollectForProcessLotForEachRequest {
            get {
                return this.dataCollectForProcessLotForEachRequestField;
            }
            set {
                this.dataCollectForProcessLotForEachRequestField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://machineintegration.ws.atlmes.com/")]
    public partial class dataCollectForProcessLotForEachRequest {
        
        private string siteField;
        
        private string processLotField;
        
        private string operationField;
        
        private string operationRevisionField;
        
        private string resourceField;
        
        private string userField;
        
        private string activityIDField;
        
        private bool isDispositionRequiredField;
        
        private bool isDispositionRequiredFieldSpecified;
        
        private ModeProcessSfc modeProcessSfcField;
        
        private dataCollectSfcParametricData[] sfcArrayField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string operation {
            get {
                return this.operationField;
            }
            set {
                this.operationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string operationRevision {
            get {
                return this.operationRevisionField;
            }
            set {
                this.operationRevisionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string resource {
            get {
                return this.resourceField;
            }
            set {
                this.resourceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string user {
            get {
                return this.userField;
            }
            set {
                this.userField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string activityID {
            get {
                return this.activityIDField;
            }
            set {
                this.activityIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool isDispositionRequired {
            get {
                return this.isDispositionRequiredField;
            }
            set {
                this.isDispositionRequiredField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool isDispositionRequiredSpecified {
            get {
                return this.isDispositionRequiredFieldSpecified;
            }
            set {
                this.isDispositionRequiredFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ModeProcessSfc modeProcessSfc {
            get {
                return this.modeProcessSfcField;
            }
            set {
                this.modeProcessSfcField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sfcArray", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public dataCollectSfcParametricData[] sfcArray {
            get {
                return this.sfcArrayField;
            }
            set {
                this.sfcArrayField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://machineintegration.ws.atlmes.com/")]
    public enum ModeProcessSfc {
        
        /// <remarks/>
        MODE_NONE,
        
        /// <remarks/>
        MODE_START_SFC_PRE_DC,
        
        /// <remarks/>
        MODE_COMPLETE_SFC_POST_DC,
        
        /// <remarks/>
        MODE_PASS_SFC_POST_DC,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://machineintegration.ws.atlmes.com/")]
    public partial class dataCollectSfcParametricData {
        
        private string sfcField;
        
        private string dcGroupField;
        
        private string dcGroupRevisionField;
        
        private machineIntegrationParametricData[] parametricDataArrayField;
        
        private nonConfirmCodeArray[] ncCodeArrayField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sfc {
            get {
                return this.sfcField;
            }
            set {
                this.sfcField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string dcGroup {
            get {
                return this.dcGroupField;
            }
            set {
                this.dcGroupField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string dcGroupRevision {
            get {
                return this.dcGroupRevisionField;
            }
            set {
                this.dcGroupRevisionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("parametricDataArray", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public machineIntegrationParametricData[] parametricDataArray {
            get {
                return this.parametricDataArrayField;
            }
            set {
                this.parametricDataArrayField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ncCodeArray", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public nonConfirmCodeArray[] ncCodeArray {
            get {
                return this.ncCodeArrayField;
            }
            set {
                this.ncCodeArrayField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://machineintegration.ws.atlmes.com/")]
    public partial class machineIntegrationParametricData {
        
        private string nameField;
        
        private string valueField;
        
        private ParameterDataType dataTypeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ParameterDataType dataType {
            get {
                return this.dataTypeField;
            }
            set {
                this.dataTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.sap.com/me/datacollection")]
    public enum ParameterDataType {
        
        /// <remarks/>
        NUMBER,
        
        /// <remarks/>
        TEXT,
        
        /// <remarks/>
        FORMULA,
        
        /// <remarks/>
        BOOLEAN,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://machineintegration.ws.atlmes.com/")]
    public partial class dataCollectResultArrayData {
        
        private string sfcField;
        
        private int resultCodeField;
        
        private bool resultCodeFieldSpecified;
        
        private string errorMessageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sfc {
            get {
                return this.sfcField;
            }
            set {
                this.sfcField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int resultCode {
            get {
                return this.resultCodeField;
            }
            set {
                this.resultCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool resultCodeSpecified {
            get {
                return this.resultCodeFieldSpecified;
            }
            set {
                this.resultCodeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string errorMessage {
            get {
                return this.errorMessageField;
            }
            set {
                this.errorMessageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(dataCollectForProcessLotForEachResponse))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://machineintegration.ws.atlmes.com/")]
    public partial class miCommonResponse {
        
        private int codeField;
        
        private bool codeFieldSpecified;
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool codeSpecified {
            get {
                return this.codeFieldSpecified;
            }
            set {
                this.codeFieldSpecified = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://machineintegration.ws.atlmes.com/")]
    public partial class dataCollectForProcessLotForEachResponse : miCommonResponse {
        
        private dataCollectResultArrayData[] resultArrayField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("resultArray", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public dataCollectResultArrayData[] resultArray {
            get {
                return this.resultArrayField;
            }
            set {
                this.resultArrayField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://machineintegration.ws.atlmes.com/")]
    public partial class miDataCollectForProcessLotForEachResponse {
        
        private dataCollectForProcessLotForEachResponse returnField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public dataCollectForProcessLotForEachResponse @return {
            get {
                return this.returnField;
            }
            set {
                this.returnField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://machineintegration.ws.atlmes.com/")]
    public partial class nonConfirmCodeArray {
        
        private string ncCodeField;
        
        private bool hasNcField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ncCode {
            get {
                return this.ncCodeField;
            }
            set {
                this.ncCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool hasNc {
            get {
                return this.hasNcField;
            }
            set {
                this.hasNcField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void miDataCollectForProcessLotForEachCompletedEventHandler(object sender, miDataCollectForProcessLotForEachCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class miDataCollectForProcessLotForEachCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal miDataCollectForProcessLotForEachCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public miDataCollectForProcessLotForEachResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((miDataCollectForProcessLotForEachResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591