namespace Ticket360.Infrastructure.BackgroundJobs;

public class HangfireStorageSettings
{
    public string? StorageProvider { get; set; }
    public string? ConnectionString { get; set; }
}