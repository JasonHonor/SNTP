# SNTP
An SNTP client library, console app and service.

Library usage sample:

            var client = new NtpClient(timeServer);
            var response = client.SendAsync().Result;

            var clockOffset = response.GetSystemClockOffset();
