using System;
using System.Collections.Generic;
namespace BackOfficeWeb
{
    public class PO
    {
        public string Mode { get; set; }
        public string DocEntry { get; set; }
        public string Branch { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string VATStatus { get; set; }
        public string PaymentTerm { get; set; }
        public string SaleCode { get; set; }
        public string Remark { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DPMAmount { get; set; }
        public decimal VATAmount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DocAmount { get; set; }
        public string DocStatus { get; set; }
        public string SAPCode { get; set; }
        public string SAPStatus { get; set; }
        public string APIStatus { get; set; }
        public string APIErrorMessage { get; set; }
        public string DoCur { get; set; }

        // Optional: list of PO1 items
        public List<PO1> PODetails { get; set; } = new List<PO1>();
    }

    public class PO1
    {
        public string DocEntry { get; set; }
        public int LineNum { get; set; }
        public string BaseType { get; set; }
        public string BaseEntry { get; set; }
        public int? BaseLineNum { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public string VAT { get; set; }
        public decimal LineAmount { get; set; }
        public string Warehouse { get; set; }
        public string OcrCode { get; set; }
        public string OcrCode2 { get; set; }
        public string OcrCode3 { get; set; }
        public string OcrCode4 { get; set; }
        public string Project { get; set; }
        public string LineStatus { get; set; }
        public string Remark { get; set; }
        public string IsFather { get; set; }
        public string FatherCode { get; set; }

        // Removed navigation property to avoid EF Core errors
        // public PO PO { get; set; }
    }


    public class Item
    {
        public string Mode { get; set; }
        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public short? ItemGroupCode { get; set; }

        public string ItemGroupName { get; set; }

        public int? UgpEntry { get; set; }

        public decimal? Onhand { get; set; }

        public decimal? OnOrder { get; set; }

        public decimal? IsCommited { get; set; }

        public decimal? Available { get; set; }

        public decimal? MinLevel { get; set; }

        public decimal? MaxLevel { get; set; }

        public string Status { get; set; }

        public string? ImageUrlServer { get; set; }

        public string? ImageUrlLocal { get; set; }

        public string? FrgnName { get; set; }

        public string InvUoMCode { get; set; }

        public int? InvUoMEntry { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string OcrCode { get; set; }

        public string OcrCode2 { get; set; }

        public string OcrCode3 { get; set; }

        public string OcrCode4 { get; set; }

        public string Manufacturer { get; set; }
        public string ManufacturerDes { get; set; }

        public string SubGroup { get; set; }
        public string SubGroupDes { get; set; }

        public string ItemBrand { get; set; }
        public string ItemBrandDes { get; set; }

        public string ItemType { get; set; }
        public string ItemTypeDes { get; set; }

        public string ProteinType { get; set; }
        public string ProteinTypeDes { get; set; }

        public string SubGroup2 { get; set; }
        public string SubGroup2Des { get; set; }

        public string Factory { get; set; }
        public string FactoryDes { get; set; }

        public string BarCode { get; set; }

        public int? DefEntry { get; set; }

        public decimal? AltQty { get; set; }
    }

    public class ItemPricing
    {
        public string Mode { get; set; }
        public string ItemCode { get; set; }
        public string PriceListCode { get; set; }
        public string UoMEntry { get; set; }
        public decimal? Amount { get; set; }
        public string? Status { get; set; }
    }

    public class Whs
    {
        public string Mode { get; set; }
        public string WhsCode { get; set; }
        public string WhsName { get; set; }
        public string WhsStatus { get; set; }
        public string Shows { get; set; }
    }

    public class UoMGroup
    {
        public int UgpEntry { get; set; }
        public int UoMEntry { get; set; }
        public string UgpName { get; set; }
        public string UoMCode { get; set; }
        public decimal? BaseQty { get; set; }
        public decimal? AltQty { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
    }

    public class UoM
    {
        public int UoMEntry { get; set; }
        public string UoMCode { get; set; }
        public string Mode { get; set; }
    }

    public class PriceList
    {
        public string Mode { get; set; }
        public int ListNum { get; set; }
        public string ListName { get; set; }
        public string Status { get; set; }
    }

    public class ItemBrand
    {
        public string ItemBrandCode { get; set; }
        public string ItemBrandName { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
    }

    public class ItemGroup
    {
        public string ItemGroupCode { get; set; }
        public string ItemGroupName { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
    }

    public class ItemProteinType
    {
        public string ProteinType { get; set; }
        public string ProteinName { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
    }

    public class ItemSubGroup
    {
        public string SubGroupCode { get; set; }
        public string SubGroupName { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
    }

    public class ItemSubGroup2
    {
        public string ItemSubGroup2Code { get; set; }
        public string ItemSubGroup2Name { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
    }

    public class ItemType
    {
        public string ItemTypeCode { get; set; }
        public string ItemTypeName { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
    }


    public class Customer
    {
        public string? Mode { get; set; }
        public string? CardCode { get; set; }           // nvarchar(50), Primary Key
        public string? CardName { get; set; }           // nchar(10)
        public string? CardFName { get; set; }          // nchar(10)
        public int? GroupCode { get; set; }             // int, nullable
        public string? GroupName { get; set; }          // nvarchar(200), nullable
        public string? ID { get; set; }                 // nvarchar(50), nullable
        public string? Tel1 { get; set; }               // nvarchar(50), nullable
        public string? Tel2 { get; set; }               // nvarchar(50), nullable
        public string? Mobile { get; set; }             // nvarchar(50), nullable
        public string? ContactPerson { get; set; }      // nvarchar(50), nullable
        public string? ContactPersonName { get; set; }  // nvarchar(500), nullable
        public string? FullAddress { get; set; }        // nvarchar(500), nullable
        public string? Paymenterm { get; set; }         // nvarchar(50), nullable
        public string? PriceList { get; set; }          // nvarchar(50), nullable
        public decimal? CreditLimit { get; set; }       // numeric(19,6), nullable
    }


    public class PromotionHeaderV2
    {
        public string Mode { get; set; } = "Add";       // Add / Update
        public string Code { get; set; }                // PK
        public string? Name { get; set; }
        public int DocEntry { get; set; }
        public string? Canceled { get; set; }           // 'Y'/'N'
        public string? Object { get; set; }
        public int? LogInst { get; set; }
        public int? UserSign { get; set; }
        public string? Transfered { get; set; }         // 'Y'/'N'
        public DateTime? CreateDate { get; set; }
        public short? CreateTime { get; set; }
        public DateTime? UpdateDate { get; set; }
        public short? UpdateTime { get; set; }
        public string? DataSource { get; set; }         // 'C'?
        public string U_RefNo { get; set; }             // NOT NULL
        public DateTime? U_FromDate { get; set; }
        public DateTime? U_ToDate { get; set; }
        public string U_CardCode { get; set; }          // NOT NULL
        public string? U_CardName { get; set; }
        public string U_PromotionType { get; set; }     // NOT NULL
        public string U_ApplyType { get; set; }         // NOT NULL
        public string? U_RemarkCode { get; set; }
        public string? U_Remark { get; set; }
        public string U_ItemGroup { get; set; }         // NOT NULL
        public string U_Status { get; set; }            // NOT NULL
        public string? U_Attactment { get; set; }

        // ✅ Include child rows for API serialization
        public List<PromotionRowV2>? PromotionRows { get; set; } = new();
    }

    public class PromotionRowV2
    {
        public string Mode { get; set; } = "Add";       // Add / Update
        public string Code { get; set; }                // FK to PromotionHeaderV2
        public int LineId { get; set; }                 // PK with Code
        public string? Object { get; set; }
        public int? LogInst { get; set; }
        public string U_LevelType { get; set; }         // NOT NULL
        public string? U_UOMType { get; set; }
        public string? U_Code { get; set; }
        public string? U_Description { get; set; }
        public decimal? U_StartQty { get; set; }
        public decimal? U_FreeQty { get; set; }
        public decimal? U_PromotionPercent { get; set; }
        public decimal? U_PromotionAmount { get; set; }
        public decimal? U_TransportationPercent { get; set; }
        public decimal? U_TransportionAmount { get; set; }       // spelling as in SQL
        public decimal? U_TransportationAmountKH { get; set; }
    }


    public class Users
    {
        public string Code { get; set; }                 // PK
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Profile { get; set; }
        public string? CompanyName { get; set; }
        public string? UserType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Status { get; set; }
        public int? SlpCode { get; set; }
        public string? IsWebUser { get; set; }
        public string? IsEndofDay { get; set; }
        public string? Manager { get; set; }
        public string? DeviceID { get; set; }
        public string? PrinterName { get; set; }
        public string? PrinterMac { get; set; }

        // Optional: Mode for API (Add/Update)
        public string? Mode { get; set; }
    }



    public class LoginRequest
    {
        public string UserCode { get; set; }
        public string Password { get; set; }
        public string DeviceID { get; set; }
    }

    public class LoginResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string? CodeUser { get; set; }
        public string? CompanyName { get; set; }
        public string? DeviceID { get; set; }
        public string? Email { get; set; }
        public string? IsWebUser { get; set; }
        public string? Manager { get; set; }
        public string? Name { get; set; }
        public string? PrinterMac { get; set; }
        public string? PrinterName { get; set; }
        public string? Profile { get; set; }
        public int? SlpCode { get; set; }
        public string? Status { get; set; }
        public string? UserType { get; set; }
    }

    public class ItemLoginResult
    {
        public int Code { get; set; }
        public string? Message { get; set; }

        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public short? ItemGroupCode { get; set; }
        public string? ItemGroupName { get; set; }
        public int? UgpEntry { get; set; }

        public decimal? Onhand { get; set; }
        public decimal? OnOrder { get; set; }
        public decimal? IsCommited { get; set; }
        public decimal? Available { get; set; }

        public decimal? MinLevel { get; set; }
        public decimal? MaxLevel { get; set; }

        public string? Status { get; set; }

        public string? ImageUrlServer { get; set; }
        public string? ImageUrlLocal { get; set; }

        public string? FrgnName { get; set; }

        public string? InvUoMCode { get; set; }
        public int? InvUoMEntry { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? OcrCode { get; set; }
        public string? OcrCode2 { get; set; }
        public string? OcrCode3 { get; set; }
        public string? OcrCode4 { get; set; }

        public string? Manufacturer { get; set; }
        public string? ManufacturerDes { get; set; }

        public string? SubGroup { get; set; }
        public string? SubGroupDes { get; set; }

        public string? ItemBrand { get; set; }
        public string? ItemBrandDes { get; set; }

        public string? ItemType { get; set; }
        public string? ItemTypeDes { get; set; }

        public string? ProteinType { get; set; }
        public string? ProteinTypeDes { get; set; }

        public string? SubGroup2 { get; set; }
        public string? SubGroup2Des { get; set; }

        public string? Factory { get; set; }
        public string? FactoryDes { get; set; }

        public string? BarCode { get; set; }

        public int? DefEntry { get; set; }

        public decimal? AltQty { get; set; }
    }

    public class CustomerResult
    {
        public int? Code { get; set; }

        public string? Message { get; set; }

        public string? CardCode { get; set; }

        public string? CardName { get; set; }

        public string? CardFName { get; set; }

        public int? GroupCode { get; set; }

        public string? GroupName { get; set; }

        public string? ID { get; set; }

        public string? Tel1 { get; set; }

        public string? Tel2 { get; set; }

        public string? Mobile { get; set; }

        public string? ContactPerson { get; set; }

        public string? ContactPersonName { get; set; }

        public string? FullAddress { get; set; }

        public string? Paymenterm { get; set; }

        public string? PriceList { get; set; }

        public decimal? CreditLimit { get; set; }
    }

    public class WhsResult
    {
        public int Code { get; set; }
        public string? Message { get; set; }

        public string? WhsCode { get; set; }
        public string? WhsName { get; set; }
        public string? WhsStatus { get; set; }
        public string? Shows { get; set; }
    }

    public class UoMResult
    {
        public int Code { get; set; }
        public string? Message { get; set; }

        public int UoMEntry { get; set; }

        public string? UoMCode { get; set; }

        public string? Status { get; set; }
    }

    public class UoMGroupResult
    {
        public int Code { get; set; }
        public string? Message { get; set; }

        public int? UgpEntry { get; set; }
        public int? UoMEntry { get; set; }

        public string? UgpName { get; set; }
        public string? UoMCode { get; set; }

        public decimal? BaseQty { get; set; }
        public decimal? AltQty { get; set; }

        public string? Status { get; set; }
    }

    public class PriceListResult
    {
        public int Code { get; set; }
        public string? Message { get; set; }

        public int? ListNum { get; set; }
        public string? ListName { get; set; }
        public string? Status { get; set; }
    }

    public class ItemPricingResult
    {
        public int Code { get; set; }
        public string? Message { get; set; }

        public string? ItemCode { get; set; }
        public string? PriceListCode { get; set; }
        public string? UoMEntry { get; set; }

        public decimal? Amount { get; set; }
        public string? Status { get; set; }
    }

    public class SpResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string PrimaryKey { get; set; }
    }
}
