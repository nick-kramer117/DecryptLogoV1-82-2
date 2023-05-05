<h1 align="center">Hi there, I`m,
	<a href="https://notabug.org/Nick_Kramer" target="_blank">
	Nick Kramer.
	</a> 
</h1>

<h3 align="center"> Porject: DecryptLogoV1-82-2. </h3>

<p align="left">
	Description: This program allows you to take the password to unload a project from PLC Siemens LOGO! 8.
</p>

`LICENCIA` = **GPLv3**.

### Vulnerability description.
The PLC project password is requested by the host by sending a TCP packet "4bc001e000000000000000000000047657450726748656164000010270000" (size28 bytes) to port 10005. In response, the PLC sends a packet containing the header "4b0004600000000000000000000000" (size 16 bytes) and the encrypted password (size 48 bytes).

### Program description.
This program sends a "password request" packet, receives a response from the PLC, the packet with the password, removes the "header", and decrypts the remaining data. PLC IP address is stored in the console. After that it checks if the IP address is correct, if it is, the following information will be shown to the console:
* "Size msg:" - Size of the received packet (with header).
* "msg view:" - Representation of the PLC response in HEX format.
* "Password size:" Password size.
* "Password:" - Password.

### Software usage recommendation.
1. Make sure that your device is communicating with the PLC;
2. Check for an open port 10005.
3. Run this program.
4. Enter the IP address of the PLC correctly and press "Enter".

This vulnerability has been tested on a Siemens LOGO PLC (Model: 6ED1052-1MD08-0BA0).

### Recommendations to minimize the risk of this vulnerability:
1. Isolate the PLC from the global network (Internet);
2. Limit access of network equipment, to the PLC on port 10005.
3. The password must not be associated with anything (for example Admin). It is desirable to create passwords using random password generators.

## Important! This software is designed to diagnose the safety of automation components based on a LOGO PLC.
