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

## GET /locations

```json
{
  "_embedded": [
  {
    id: '1',
    name: "Aladdin's Eatery",
    description:
      'On Mayfield, good lunch time - lots of options for vegetarians',
    addedBy: 'Bob',
    addedOn: '2023-01-01',
  },
  {
    id: '2',
    name: "McDonald's",
    description: 'On SOM, burgers. No description needed.',
    addedBy: 'Sue',
    addedOn: '2023-03-01',
  },
]
}


```