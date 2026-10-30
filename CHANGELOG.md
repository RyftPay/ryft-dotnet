# Changelog

## 1.9.0

This release includes the following:
 - Adds `AuthenticationParametersRequest`, for sending the result of 3DS performed with your own 3DS server (MPI), or the cryptogram of a wallet network token. `Eci` is required with card details or a stored card and optional with a wallet network token
 - Adds `AuthenticationParameters` to `AttemptPaymentRequest` (secret API key only), for sending your own 3DS result
 - Adds `AuthenticationParameters` to `CreatePaymentSessionRequest`, for sending the cryptogram of `AttemptPayment.WalletNetworkToken`
 - Adds `WalletNetworkTokenRequest` and `WalletNetworkToken` to `AttemptPaymentRequest` and `CreatePaymentSessionAttemptPaymentRequest`, for Apple Pay and Google Pay network tokens you have decrypted yourself
 - `CreatePaymentSessionAttemptPaymentRequest.PaymentMethod` is now optional, as `WalletNetworkToken` can be sent instead

## 1.8.0

This release includes the following:
 - Adds `Verification` to `PayoutMethod`, exposing the payee verification status, `NameOnAccount`, and `RejectionReason`

## 1.7.0

This release includes the following:
 - Adds `Policy` to `ThreeDsSettingsRequest` and `PaymentSessionThreeDsSettings`, for the payment session `paymentSettings.threeDs.policy` field

## 1.6.0

This release includes the following:
 - Adds `StartsAfter` to `ListPlatformFeesRequest`, for paging platform fees
 - Adds `ListPlatformFeeRefundsRequest` so `ListRefundsAsync` can supply `ascending`, `limit` and `startsAfter`

## 1.5.1

This release includes the following:
 - Fixes `GetRateAsync`/`GetRateRequest` to correctly require `buyCurrency`, `sellCurrency`, and `amount`, matching the API's actual requirements

## 1.5.0

This release includes the following:
 - Adds support for the Conversions API via `ConversionApiClient` - create, get, list, and get-rate

## 1.4.1

This release includes the following:
 - Adds missing `Documents` property to `UpdateAccountBusinessRequest`

## 1.4.0

This release includes the following:
 - Adds support for payment session 3DS configuration via `paymentSettings.threeDs`

## 1.3.0

This release includes the following:
 - The PaymentSession response now includes Card BIN data where applicable


## 1.2.0

This release includes the following:
 - the SDK now supports the new /in-person API resources
 - fixes the hashCode implementation within the `Customer` model

## 1.1.0

This release includes the following:
- `cvc` can now be optional for MOTO payments
- `miscPassThrough` field added to the `payment-sessions` API
- fixed incorrect type and JSON conversion for `AmountVariance` type

## 1.0.0

Initial Release!
