using System.Text.Json.Serialization;

namespace DocuPipe.Clients.Account.Models;

/// <summary>
/// Response payload for GET /account. The enumerated fields stay strings so a value DocuPipe adds later
/// does not stop the whole response being read.
/// </summary>
public sealed class AccountResponse
{
    [JsonPropertyName("planName")] public string? PlanName { get; set; }

    /// <summary>overage or topoff.</summary>
    [JsonPropertyName("pricingRegime")] public string? PricingRegime { get; set; }

    /// <summary>Credits left under the current plan. Using these incurs no charge.</summary>
    [JsonPropertyName("remainingCredits")] public decimal RemainingCredits { get; set; }

    /// <summary>Overage credits, billed in the billing cycle.</summary>
    [JsonPropertyName("overageCredits")] public decimal OverageCredits { get; set; }

    [JsonPropertyName("renewalDate")] public DateTimeOffset? RenewalDate { get; set; }

    /// <summary>Days data is retained. Null means unlimited.</summary>
    [JsonPropertyName("retentionDays")] public int? RetentionDays { get; set; }

    /// <summary>us, europe, canada or australia.</summary>
    [JsonPropertyName("storageRegion")] public string? StorageRegion { get; set; }

    [JsonPropertyName("overageEnabled")] public bool OverageEnabled { get; set; } = true;

    /// <summary>Whether usage exceeds the plan and overage charges are accruing.</summary>
    [JsonPropertyName("inOverage")] public bool InOverage { get; set; }

    /// <summary>Whether the latest charge failed and the subscription is past due.</summary>
    [JsonPropertyName("delinquent")] public bool Delinquent { get; set; }

    [JsonPropertyName("upcomingInvoice")] public UpcomingInvoice? UpcomingInvoice { get; set; }

    [JsonPropertyName("planCosts")] public PlanCosts? PlanCosts { get; set; }

    /// <summary>Credits granted each billing cycle. Null with no subscription or when it is unknown.</summary>
    [JsonPropertyName("monthlyCreditAllowance")] public int? MonthlyCreditAllowance { get; set; }

    /// <summary>free, direct or aws_marketplace.</summary>
    [JsonPropertyName("billingMethod")] public string? BillingMethod { get; set; }

    /// <summary>Only present for AWS Marketplace subscribers.</summary>
    [JsonPropertyName("awsContractDetails")] public AwsContractDetails? AwsContractDetails { get; set; }

    /// <summary>Only present on on-prem deployments, for super admins.</summary>
    [JsonPropertyName("onpremCreditPool")] public OnPremCreditPool? OnPremCreditPool { get; set; }

    [JsonPropertyName("featureFlags")] public Dictionary<string, bool>? FeatureFlags { get; set; }
}

public sealed class UpcomingInvoice
{
    [JsonPropertyName("currency")] public string? Currency { get; set; }

    [JsonPropertyName("amountRemaining")] public decimal AmountRemaining { get; set; }

    [JsonPropertyName("amountPaid")] public decimal AmountPaid { get; set; }

    [JsonPropertyName("total")] public decimal Total { get; set; }

    /// <summary>The date the invoice will be charged.</summary>
    [JsonPropertyName("endDate")] public DateTimeOffset EndDate { get; set; }

    [JsonPropertyName("startDate")] public DateTimeOffset StartDate { get; set; }
}

public sealed class PlanCosts
{
    /// <summary>Pay-as-you-go price per credit, in USD.</summary>
    [JsonPropertyName("perCreditAmount")] public decimal? PerCreditAmount { get; set; }

    /// <summary>Total recurring charge, in USD.</summary>
    [JsonPropertyName("recurringAmount")] public decimal RecurringAmount { get; set; }

    /// <summary>monthly, annual or null.</summary>
    [JsonPropertyName("recurringFrequency")] public string? RecurringFrequency { get; set; }
}

public sealed class AwsContractDetails
{
    [JsonPropertyName("customerId")] public string? CustomerId { get; set; }

    [JsonPropertyName("productCode")] public string? ProductCode { get; set; }

    [JsonPropertyName("entitledCredits")] public int EntitledCredits { get; set; }

    [JsonPropertyName("contractEndDate")] public DateTimeOffset? ContractEndDate { get; set; }

    [JsonPropertyName("linkedAt")] public DateTimeOffset? LinkedAt { get; set; }

    [JsonPropertyName("subscriptionStatus")] public string? SubscriptionStatus { get; set; }
}

public sealed class OnPremCreditPool
{
    [JsonPropertyName("totalCredits")] public int TotalCredits { get; set; }

    [JsonPropertyName("creditsRemaining")] public int CreditsRemaining { get; set; }

    [JsonPropertyName("lastUpdatedAt")] public DateTimeOffset? LastUpdatedAt { get; set; }
}
