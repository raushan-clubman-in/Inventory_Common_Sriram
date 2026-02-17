Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Module GlobalVariables
    '========================# IM POLICY CODE START #===========================
    Public MCA, Autherize As String
    '========================# IM POLICY CODE END #===========================
    Public gValidity As Boolean = True
    Public Licensebool As Boolean
    Public GSTSTARTdATE As Date = "01 JUL 2017"
    Public I As Integer
    Public USER As String
    Public boolyec As Boolean
    Public boolConv As Boolean
    Public EXECBOOL As Boolean
    Public NewInvTag As String
    Public TINNO As String
    Public SERVICETAX As String
    Public gpdf, mailid As String
    Public gdirissue As String
    Public stryecmsg, gInventoryVersion As String
    Public MDIParentobj As Object
    Public nonstockable As New DataTable
    Public GInvSeq As Double
    Public gIssueregister As Boolean
    Public gridviewstatus As String
    Public gSQLString As String
    Public AuthYN As Boolean = False
    Public M_Groupby As String
    Public M_WhereCondition As String
    Public M_ORDERBY As String
    Public strexcelpath As String
    Public Photogen As String
    Public gUsername As String
    Public ggusername As String
    Public ggpassword, strDataSqlUsr, strDataSqlPwd, strCompany_ID As String
    Public ggproductkey As String
    Public DefaultGRN As String = "NA"
    Public GINDENTNO As String
    Public mysql As String
    Public GACCPOST, GBATCHNO, GEXPIRY, GSHELVING As String
    Public chkClsQty As Boolean = False
    Public chkStorecode As String
    Public gPrint As Boolean
    Public gDosPrint As Boolean
    Public AppPath As String
    Public gCompanyname, gcompname As String
    Public gCompanyAddress(10) As String
    Public gDatabase, History As String
    Public gDivCode As String
    Public gDivName As String
    Public gSeasion As String
    Public gUserCategory As String
    Public ModuleAdmin As Boolean
    Public wemp1, wemp2, wemp3 As String
    Public Reportsql As String
    Public VFilePath As String
    Public printfile As String
    Public tables As String
    Public Gheader As String
    Public gserver As String
    Public gdataset As New DataSet
    Public gdreader As SqlDataReader
    Public gadapter As SqlDataAdapter
    Public gcommand As SqlCommand
    Public gfstream As FileStream
    Public gtrans As SqlTransaction
    Public SponsorMasterbool As Boolean
    Public GroupMasterbool As Boolean
    Public SubGroupMasterbool As Boolean
    Public StoreMasterbool As Boolean
    Public ItemMasterbool As Boolean
    Public TenderMasterbool As Boolean
    Public UOMRelationMasterbool As Boolean
    Public BillingMaterialbool As Boolean
    Public PurchaseOrderbool As Boolean
    Public IndentOrderbool As Boolean
    Public UserAdminbool As Boolean
    Public GRNCumPurchaseBillTransbool As Boolean
    Public StockIssueTransbool As Boolean
    Public CockTailRatioTransbool As Boolean
    Public StockTransferTransbool As Boolean
    Public StockAdjustmentTransbool As Boolean
    Public StockDamageTransbool As Boolean
    Public vOutfile, vOutfile1, vheader, vLine, directissueing, TABNAME As String
    Public gFinancalyearStart As String
    Public gFinancialyearEnd As String
    Public Filewrite As StreamWriter
    Public kotentrybool As Boolean
    Public finalbillbool As Boolean
    Public manualbillbool As Boolean
    Public cashreceiptbool As Boolean


    Public gFyear As Boolean = False


    Public Printername As String = "EpsonCom"
    Public computername As String = "debasish"
    Public search As String
    Public MyCompanyName As String
    Public Address1 As String
    Public Address2 As String
    Public DateClsValue As Double
    Public gCity As String
    Public gState As String
    Public gPincode As String
    Public gPhone1 As String
    Public gPhone2 As String
    Public gFax As String
    Public gEMail, gGSTINNO As String
    Public chkdatevalidate As Boolean
    Public PrintTaxheading1 As String
    Public PrintTaxheading2 As String
    Public gCreditors As String
    Public gDebitors As String
    Public Guseraccess As String
    Public gAcTaggingType As String = "IW"

    Public gAcPostingWise As String
    Public gConsumpTionAllow As String
    Public gCostcenter As String
    Public Mbutton As Object
    Public subform As String
    Public GmoduleName As String
    Public BATCH_REQ, exp_req As String
    Public gpocode As String
    Public GSUPPLIER As String
    Public gpaymentcode, gShortname As String
    Public serverdate As DateTime
    Public servertime As DateTime
    Public PoNumber As String
    Public gTAXcode As String
    Public ShowCompany As Boolean

    Public gFinancialyearStart As Date
    Public gFinancialyearEnding As Date
    Public gstartingdate As String
    Public gstartingdateNew As Date
    Public gendingdate As String
    Public RESU1 As String

    Public Filepath As String
    Public FileSize As Long
    Public dtCreationDate As DateTime
    Public dtLastAccessTime As DateTime
    Public dtLastWriteTime As DateTime
    Public GModule As String = "INVENTORY"
    Public GVerValidate As Boolean = True
    Public RSILINK, HYDLINK, CATHOLIC, positemstorelink As String
    Public gRSILINK, gHYDLINK, gCATHOLIC, gpositemstorelink, gsalerate, gvendorlink, gavgrate, gGRNGLCODE As String
    Public currendate As Date = Format(Date.Now, "dd-MMM-yyyy")




    'end


End Module
