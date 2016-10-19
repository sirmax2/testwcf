@echo off
set url=http://localhost:4321/TestService
set contentType=text/xml; charset=utf-8
set data=^<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"^>^<s:Body^>^<hola xmlns=\"http://tempuri.org/\"/^>^</s:Body^>^</s:Envelope^>
set soapaction=http://tempuri.org/ITestService/hola

curl -X POST -d "%data%" %url% -H "SOAPAction: %soapaction%" -H "Content-Type: %contentType%" -D headers.txt
echo.
echo.
type headers.txt
del headers.txt
