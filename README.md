# CountriesAPI

This project provides an API with two endpoints, one which retrieves all the 250 known countries and one which is given an array of integers and finds the second largest integer in the specific array.

APIs Used: [RestCountries]([https://restcountries.com/])

---

## Endpoints
### Countries

**Method**:  
`GET`

- Retrieves all 250 countries from the Rest Countries API and uses a DTO to present only their common names, capitals and borders.
- Saves the response to a Database Table using MS SQL Server and utilizes caching for faster responses.
  
**Example Result**:
```json
[
  {
    "name": {
            "common": "Switzerland"
        },
        "capital": [
            "Bern"
        ],
        "borders": [
            "AUT",
            "FRA",
            "ITA",
            "LIE",
            "DEU"
        ]
    },
    {
        "name": {
            "common": "Sierra Leone"
        },
        "capital": [
            "Freetown"
        ],
        "borders": [
            "GIN",
            "LBR"
        ]
    },
]
```
**URL**:  
https://localhost:7299/api/Countries

### Second Largest

**Method**:  
`Post`

- Retrieves the array of integers from json body and returns the second largest number from it

**Example**:
```json
{
  "requestArrayObj": [
    1,2,3,4,5,6,7,8,9
  ]
}
```
**Returns**
```bash
9
```
**URL**:  
https://localhost:7299/api/SecondLargest

---

## Setup

1. Clone the repository:
https://github.com/Gikonst/ApiAggregationAssignment.git

2. Go to appsettings.json:

Paste under "AllowedHosts": "*",:
  ```json
"ConnectionStrings": {
  "DefaultConnection": "YOUR_CONNECTION_STRING"
}
  ```
# You are ready to launch the project.
