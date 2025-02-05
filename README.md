# CountriesAPI

This project provides an API with two endpoints, one which retrieves all the 250 known countries and one which is given an array of integers and finds the second largest integer in the specific array.

#### Technologies Used: 
- ASP.Net Core 8
- EntityFramework - FluentApi
- MS SQL Server

#### APIs Used: 
[RestCountries](https://restcountries.com/)

---

## Endpoints
### 1. Countries

**Method**:  
`GET`

- Retrieves all 250 countries from the Rest Countries API and uses a DTO to present only their common names, capitals and borders.
- Saves the response to a database using MS SQL Server and utilizes caching for faster responses.
  
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

### 2. Second Largest

**Method**:  
`Post`

- Retrieves the array of integers from json body and returns the second largest number from it

**Request Example**:
```json
{
  "requestArrayObj": [
    1,2,3,4,5,6,7,8,9
  ]
}
```
**Returns**
```bash
8
```
**URL**:  
https://localhost:7299/api/SecondLargest

---

## Setup

1. Clone the repository:
https://github.com/Gikonst/CountriesApiProject.git

2. Go to appsettings.json:

Paste under "AllowedHosts": "*",:
  ```json
"ConnectionStrings": {
  "DefaultConnection": "YOUR_CONNECTION_STRING"
}
  ```
# Enjoy the project.
