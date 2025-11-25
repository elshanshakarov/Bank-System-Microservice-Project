using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionEventService.Domain.Entities;

public class TransactionEvent
{
    public string EventId { get; set; }
    public string CustomerId { get; set; }
    public string Type { get; set; }        // deposit / withdraw / transfer
    public decimal Amount { get; set; }
    public string Source { get; set; }      // ATM, MobileApp, WebApp
    public DateTime Timestamp { get; set; }
}