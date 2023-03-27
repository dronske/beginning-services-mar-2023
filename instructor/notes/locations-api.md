# Locations API

localhost:1337/status

## GET /status

Should return something like this:


```json
{
        "contactInfo": {
          "name": "Andrew Mervkin",
          "phone": "888-1212",
          "email": "merv@pumpkin.com"
        },
        uptime: {
          days: 13,
          hours: 12,
          minutes: 38
        }
      }
```