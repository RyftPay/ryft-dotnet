# Ryft .NET SDK

[![Build & Test](https://github.com/RyftPay/ryft-dotnet/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/RyftPay/ryft-dotnet/actions/workflows/build-and-test.yml) [![Integration Test](https://github.com/RyftPay/ryft-dotnet/actions/workflows/build-and-integration-test.yml/badge.svg)](https://github.com/RyftPay/ryft-dotnet/actions/workflows/build-and-integration-test.yml) [![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

The Ryft .Net SDK allows you to consume our payments API within your .Net applications


## Prerequisites

The SDK supports the following targets:
 - `.NET 8.0` and above
 - `.NET Framework 4.8` and above
 - `.netstandard2.0`

**Note** that it has been tested against `.NET 8.0` and `.NET Framework 4.8`.

These targets or later are recommended.

## Installation

The SDK is available on [NuGet](https://www.nuget.org/packages/RyftPay.Net)

### with NuGet
`PM> Install-Package RyftPay.Net -Version x.x.x`

## Usage

Each resource from our API is provided individually.
For example, to begin interfacing with our `/payment-sessions` resources, initialise the API client:

#### Initialisation

All API clients require an instance of `IRyftApiClient`, which can be constructed in several ways:

```csharp
var apiClient = new RyftApiClient();

// or with your own HttpClient
var apiClient = new RyftApiClient(new HttpClient());

// or with IHttpClientFactory
var apiClient = new RyftApiClient(httpClientFactory);
```

You API key can be supplied on either the `RyftApiClient` or per-request.

```csharp
var apiClient = new RyftApiClient(
    requestSettings: new ClientRequestSettings { ApiKey = "<your API key>" }
);
var paymentSessionsApiClient = new PaymentSessionsApiClient(apiClient);
```

#### Making requests

```csharp
var request = new CreatePaymentSessionRequest(500, "GBP")
{
  CaptureFlow = CaptureFlow.Manual,
  CustomerEmail = "test@ryftpay.com"
};
var paymentSession = await paymentSessionsApiClient.CreateAsync(request);

// request with API key supplied

var paymentSession = await paymentSessionsApiClient.CreateAsync(
    request,
    requestSettings: new ClientRequestSettings { ApiKey = "<your API key>" }
);
```

## Handling Webhook Events

> Note that the SDK does not support `Event` objects persisted prior to August 2025

### Verifying the signature (Recommended)

Every webhook event is delivered with a `Signature` header which you can use to verify the integrity of the message.

This header value is derived from calculating a `HMAC-SHA256` of the raw response body alongside your webhook secret.

You can leverage our built-in class to perform this check as follows:

```csharp
string signature = Request.Headers['Signature'];
string webhookSecret = "<dervie this from your backend (e.g. env var)>";
string payload = "<supply the unmodified raw string (JSON) from the request>";
var webhookHandler = new WebhookHandler();
bool isValid = webhookHandler.IsSignatureValid(webhookSecret, signature, payload);
```

### Parsing the event

To parse the incoming event, you can again leverage the `WebhookHandler` class as follows:

```csharp
string payload = "<supply the unmodified raw string (JSON) from the request>";
var webhookHandler = new WebhookHandler();
try
{
    var @event = webhookHandler.ConstructEvent(payload);
    // you can then access the underlying API response model based on the event type, e.g.
    if (@event.EventType == EventTypes.CustomerCreated)
    {
        var customer = @event.Data.Object as Customer;
    }
    // always return a 200 status code to confirm you have received the event successfully
    return Ok();
}
catch (RyftDotNetException e)
{
    // the event could not be parsed/constructed
}
```

# Notes on design decisions

## Enumeration Types

We consider adding new enums to our API as non-breaking and non-major upgrades.
Keep this in mind when using the SDK.

We have intentionally:
 - avoided using strict `Enum` values for use on request and response models
 - opted for [enumeration classes](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types) instead.

This allows for requests to be more easily discover which values are available whilst at the same time, new values can be returned from our API without the SDK erroring.
We will release a minor version update when new values are introduced.

## Constructors vs Properties

Constructor parameters map to required fields on our API reference.
Property setters are utilised for optional parameters.

e.g. When creating a payment session, `amount` and `currency` are required fields.

```csharp
var request = new CreatePaymentSessionRequest(500, "GBP");
```

To supply any additional (optional) parameters, use the properties available:

```csharp
var request = new CreatePaymentSessionRequest(500, "GBP")
{
  CaptureFlow = CaptureFlow.Manual,
  CustomerEmail = "test@ryftpay.com"
};
```

## Contributing

We welcome contributors, please see our [Contributing guidelines](CONTRIBUTING.md)

## Code of Conduct

Please refer to [Code of Conduct](CODE_OF_CONDUCT.md)

## Licensing

[MIT](LICENSE)

