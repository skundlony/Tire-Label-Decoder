# Tire Label Decoder

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [How to use](#how-to-use)

## General info
Simple qrcode and qrcode data decoder for tires based on public EPREL API. Feel free to contribute.

## Technologies
- .NET Framework 4.8
- ZXing.Net
- Newtonsoft.Json

## How to use

#### GetByQrCodeUrl
Reads QR Code, getting link and looking in API for information.
Example url `https://eprel.ec.europa.eu/screen/product/tyres/381801`
```
var tireLabel = new TireLabelDecoder().GetByQrCodeUrl(url);
```

#### GetByQrData
Reads QR Code Data. Web pages often stores it in source code. Using QrCode data is faster. We do not need to read QR Code.
Example QR Code Data references to above url - `381801` 
```
var tireLabel = new TireLabelDecoder().GetByQrData(qrData);
```
