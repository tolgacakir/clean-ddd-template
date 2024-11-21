using System.ComponentModel;
using System.Runtime.Serialization;

namespace Domain.Aggregates.Shared;

/// <summary>
/// Enumeration of ISO 4217 currency codes, indexed with their respective ISO 4217 numeric currency codes. 
/// Only codes support in .Net with RegionInfo objects are listed
/// </summary>
public enum Currency
{ 
    [EnumMember(Value = "EUR")] [Description("Euro")]
    EUR = 978,

    [EnumMember(Value = "GBP")] [Description("Pound sterling")]
    GBP = 826,
    
    [EnumMember(Value = "TRY")] [Description("Turkish lira")]
    TRY = 949,

    [EnumMember(Value = "USD")] [Description("United States dollar")]
    USD = 840
}